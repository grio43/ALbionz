/*
 * ---------------------------------------
 * User: duketwo
 * Date: 31.01.2014
 * Time: 12:00
 *
 * ---------------------------------------
 */

using SharedComponents.EVE;
using SharedComponents.Extensions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace EVESharpLauncher
{
    /// <summary>
    ///     Description of TorManager.
    /// </summary>
    public class EveManager : IDisposable
    {
        #region Fields

        private static readonly int MAX_MEMORY = 3500;
        private static readonly int MAX_STARTS = 12;
        private static EveManager _instance = new EveManager();
        private static Thread eveKillThread;
        private static Thread eveManagerThread = null;
        private static bool isAborting = false;
        private static Random _rnd = new Random();
        private DateTime nextEveStart = DateTime.MinValue;

        #endregion Fields

        #region Constructors

        public EveManager()
        {

        }

        #endregion Constructors

        #region Properties

        public static EveManager Instance => _instance;
        private int _nextStartSeconds;

        private bool IsAnyEveProcessAlive
        {
            get { return Cache.Instance.EveAccountSerializeableSortableBindingList.List.Any(e => e.EveProcessExists()); }
        }

        #endregion Properties

        #region Methods

        public void Dispose()
        {
            if (!isAborting)
            {
                Cache.Instance.Log("Stopping EveManager.");
                isAborting = true;
            }
        }

        public void KillEveInstances()
        {
            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.Where(a => a.EveProcessExists()).ToList().RandomPermutation())
                eA.KillEveProcess(true);
        }

        public void KillEveInstancesDelayed()
        {
            if (eveKillThread == null || !eveKillThread.IsAlive)
            {
                Cache.Instance.Log("Stopping all eve instances delayed.");
                eveKillThread = new Thread(KillEveInstancesDelayedThread);
                eveKillThread.Start();
            }
        }

        private void EnsurePatternsExist()
        {
            try
            {
                foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
                {
                    if (eA.PatternManagerEnabled && !eA.IsProcessAlive() && String.IsNullOrEmpty(eA.Pattern))
                    {
                        var newPattern = PatternManager.Instance.GenerateNewPattern(eA.PatternManagerHoursPerWeek, eA.PatternManagerDaysOffPerWeek, eA.PatternManagerExcludedHours.ToArray());
                        Cache.Instance.Log($"There is no pattern for [{eA.AccountName}]. New Pattern will be [{newPattern}]");
                        eA.Pattern = newPattern;
                    }
                }
            }
            catch (Exception ex)
            {
                Cache.Instance.Log("ex");
            }
        }

        public void StartEveManager()
        {
            if (eveManagerThread == null || !eveManagerThread.IsAlive)
            {
                EnsurePatternsExist();
                Cache.Instance.Log("Starting EveManager.");
                nextEveStart = DateTime.MinValue;
                eveManagerThread = new Thread(EveManagerThread);
                isAborting = false;
                _nextStartSeconds = _rnd.Next(10, 50);
                eveManagerThread.Start();
            }
        }

        private void EveManagerThread()
        {
            while (true && !isAborting)
                try
                {
                    #region 24hrs

                    if (Cache.Instance.EveSettings.Last24HourTS.AddHours(24) < DateTime.UtcNow)
                        Cache.Instance.EveSettings.Last24HourTS = DateTime.UtcNow;

                    #endregion 24hrs

                    #region 1hrs

                    if (Cache.Instance.EveSettings.LastHourTS.AddHours(1) < DateTime.UtcNow)
                    {
                        Cache.Instance.EveSettings.LastHourTS = DateTime.UtcNow;

                        foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List)
                        {
                            if (eA.PatternManagerEnabled && !eA.IsProcessAlive() && (eA.PatternManagerLastUpdate.AddHours((7 * 24) - 2) < DateTime.UtcNow || String.IsNullOrEmpty(eA.Pattern)))
                            {
                                eA.PatternManagerLastUpdate = DateTime.UtcNow;
                                var newPattern = PatternManager.Instance.GenerateNewPattern(eA.PatternManagerHoursPerWeek, eA.PatternManagerDaysOffPerWeek, eA.PatternManagerExcludedHours.ToArray());
                                Cache.Instance.Log($"PatternManagerLastUpdate for [{eA.AccountName}] is older than 7 days or is empty. Updating. New Pattern will be [{newPattern}]");
                                eA.Pattern = newPattern;
                            }

                            if (!eA.IsProcessAlive() && eA.LastPatternTimeUpdate.AddHours(24) < DateTime.UtcNow)
                            {
                                eA.LastPatternTimeUpdate = DateTime.UtcNow;
                                Cache.Instance.Log(string.Format("Generating new timespan for [{0}]", eA.AccountName));
                                eA.Starts = 0;
                                eA.GenerateNewTimeSpan();
                            }
                        }
                    }

                    #endregion 1hrs

                    foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList()
                        .Where(eA => eA != null && !eA.SelectedController.Equals("None") && eA.FilledPattern != string.Empty).RandomPermutation())
                    {
                        if (eA.EveProcessExists())
                        {
                            var p = Process.GetProcessById(eA.Pid);

                            if ((p.WorkingSet64 / (1024 * 1024) > MAX_MEMORY) && eA.IsDocked && !eA.IsInAbyss)
                            {
                                var msg =
                                    string.Format("Eve instance [{0}] memory working set reached the definied limit of [{1}]. Current working set size [{2}]",
                                        eA.AccountName, MAX_MEMORY, (p.WorkingSet64 / 1024 / 1024).ToString());
                                Cache.Instance.Log(msg);
                                eA.KillEveProcess();
                            }

                            if (eA.IsDocked && eA.ClientSettingsSerializationErrors > EveAccount.MAX_SERIALIZATION_ERRORS && !eA.IsInAbyss)
                            {
                                Cache.Instance.Log("Client settings serialization error! Disabling this instance.");
                                eA.IsActive = false;
                                eA.KillEveProcess();
                            }

                            if (!eA.IsProcessAlive())
                            {
                                Cache.Instance.Log(string.Format("Stopping not responding eve instance. [{0}]", eA.AccountName));
                                eA.KillEveProcess();
                            }
                        }

                        if ((!eA.EveProcessExists() && eA.Starts <= MAX_STARTS && eA.ShouldBeRunning && DateTime.UtcNow >= nextEveStart) || (!eA.EveProcessExists() && eA.ShouldBeRunning && eA.IsInAbyss))
                            if (eA.IsActive || eA.IsInAbyss)
                            {
                                _nextStartSeconds = _rnd.Next(10, 50);
                                nextEveStart = DateTime.UtcNow.AddSeconds(_rnd.Next(Cache.Instance.EveSettings.TimeBetweenEVELaunchesMin,
                                    Cache.Instance.EveSettings.TimeBetweenEVELaunchesMax));
                                Cache.Instance.Log(String.Format(
                                    $"Starting Eve process [{eA.AccountName}]. Next launch will be in {(nextEveStart - DateTime.UtcNow).TotalSeconds} seconds."));
                                eA.StartEveInject();
                            }

                        if (!eA.ShouldBeRunning && eA.EveProcessExists())
                            eA.KillEveProcess();
                    }
                }
                catch (Exception ex)
                {
                    Cache.Instance.Log("Exception: " + ex.StackTrace);

                    if (ex is ThreadAbortException)
                        isAborting = true;
                    else
                        continue;
                }
                finally
                {
                    for (var i = 0; i < 25; i++)
                    {
                        if (isAborting)
                            break;

                        Thread.Sleep(100);
                    }
                }

            Cache.Instance.Log("Stopped EveManager.");
        }

        private void KillEveInstancesDelayedThread()
        {
            while (IsAnyEveProcessAlive)
            {
                foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList().RandomPermutation())
                    if (eA.EveProcessExists())
                        eA.KillEveProcess();
                Thread.Sleep(1000);
            }

            Cache.Instance.Log("Finished stopping all eve instances.");
        }

        #endregion Methods
    }
}