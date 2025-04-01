extern alias SC;
using EVESharpCore.Cache;
using EVESharpCore.Controllers.ActionQueue.Actions.Base;
using EVESharpCore.Framework;
using EVESharpCore.Logging;
using EVESharpCore.Questor.BackgroundTasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SC::SharedComponents.Utility;
using SC::SharedComponents.EVE;
using EVESharpCore.Lookup;

namespace EVESharpCore.Controllers.Debug
{
    public partial class DebugScan : Form
    {
        #region Constructors

        public DebugScan()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Fields

        private ActionQueueAction _autoProbeAction;

        private bool _onlyLoadPScanResults;

        #endregion Fields

        #region Methods

        private void btnDScan_Click(object sender, EventArgs e)
        {
            ModifyButtons();
            DateTime waitUntil = DateTime.MinValue;
            bool executedScan = false;
            ActionQueueAction action = null;
            action = new ActionQueueAction(new Action(() =>
            {
                try
                {
                    if (waitUntil > DateTime.UtcNow)
                    {
                        action.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.directionalScannerWindow == null)
                    {
                        action.QueueAction();
                        return;
                    }

                    if (executedScan)
                    {
                        List<DirectDirectionalScanResult> list = ESCache.Instance.directionalScannerWindow.DirectionalScanResults.ToList();
                        Log.WriteLine($"Scan executed. Loading {list.Count} results to datagridview.");
                        var resList = list.Select(d => new {d.TypeId, d.GroupId, d.TypeName, d.Distance, d.Name}).ToList();
                        Task.Run(() =>
                        {
                            return Invoke(new Action(() =>
                            {
                                dataGridView1.DataSource = resList;
                                ModifyButtons(true);
                            }));
                        });
                    }
                    else
                    {
                        if (!ESCache.Instance.directionalScannerWindow.IsDirectionalScanning())
                        {
                            Log.WriteLine("Executed directional scan.");
                            ESCache.Instance.directionalScannerWindow.DirectionalScan();
                            executedScan = true;
                            action.QueueAction();
                            waitUntil = DateTime.UtcNow.AddSeconds(2);
                            return;
                        }
                        action.QueueAction();
                        return;
                    }

                    ModifyButtons(true);
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            }));

            action.Initialize().QueueAction();
        }

        private void btnPScan_Click(object sender, EventArgs e)
        {
            ModifyButtons();
            DateTime waitUntil = DateTime.MinValue;
            bool executedScan = false;
            ActionQueueAction action = null;
            action = new ActionQueueAction(new Action(() =>
            {
                try
                {
                    if (waitUntil > DateTime.UtcNow)
                    {
                        action.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.probeScannerWindow == null)
                    {
                        ESCache.Instance.DirectEve.ExecuteCommand(DirectCmd.CmdToggleSolarSystemMap);
                        action.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.probeScannerWindow.pyProbeScannerPalette == null)
                    {
                        action.QueueAction();
                        return;
                    }

                    if ((executedScan || _onlyLoadPScanResults) && !Scanner.IsProbeScanning())
                    {
                        Log.WriteLine($"Probe scan finished.");
                        List<DirectSystemScanResult> list = Scanner.FilteredSystemScanResults.ToList();
                        Log.WriteLine($"Scan executed. Loading {list.Count} results to datagridview.");
                        var resList = list.Select(d => new {d.Id, d.Deviation, d.SignalStrength, d.PreviousSignalStrength, d.TypeName, d.GroupName, d.ScanGroup, d.IsPointResult, d.IsSphereResult, d.IsMultiPointResult, PosVector3 = d.Pos.ToString(), DataVector3 = d.Data.ToString()}).ToList();
                        Task.Run(() =>
                        {
                            return Invoke(new Action(() =>
                            {
                                dataGridView1.DataSource = resList;
                                ModifyButtons(true);
                                _onlyLoadPScanResults = false;
                            }));
                        });
                    }
                    else
                    {
                        if (!Scanner.IsProbeScanning())
                        {
                            Log.WriteLine("Executed probe scan.");
                            Scanner.ProbeScan();
                            executedScan = true;
                            action.QueueAction();
                            waitUntil = DateTime.UtcNow.AddSeconds(1);
                            return;
                        }
                        action.QueueAction();
                        return;
                    }

                    ModifyButtons(true);
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            }));

            action.Initialize().QueueAction();
        }

        private void btnShowProbes_Click(object sender, EventArgs e)
        {
            ModifyButtons();
            DateTime waitUntil = DateTime.MinValue;
            ActionQueueAction action = null;
            action = new ActionQueueAction(new Action(() =>
            {
                try
                {
                    if (waitUntil > DateTime.UtcNow)
                    {
                        action.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.probeScannerWindow == null)
                    {
                        ESCache.Instance.DirectEve.ExecuteCommand(DirectCmd.CmdToggleSolarSystemMap);
                        action.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.probeScannerWindow.pyProbeScannerPalette == null)
                    {
                        action.QueueAction();
                        return;
                    }

                    var resList = Scanner.GetProbes().Select(d => new {d.ProbeId, PosVector3 = d.Pos.ToString(), DestVector3 = d.DestinationPos.ToString(), d.Expiry, d.RangeAu}).ToList();

                    Task.Run(() =>
                    {
                        return Invoke(new Action(() =>
                        {
                            dataGridView2.DataSource = resList;
                            ModifyButtons(true);
                        }));
                    });
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            }));

            action.Initialize().QueueAction();
        }

        private void btnLoadPScanResults_Click(object sender, EventArgs e)
        {
            _onlyLoadPScanResults = true;
            btnPScan.PerformClick();
        }

        private void btnAutoProbe_Click(object sender, EventArgs e)
        {
            ModifyButtons();
            DateTime waitUntil = DateTime.MinValue;
            Scanner.LastScanAction = DateTime.UtcNow;

            _autoProbeAction = new ActionQueueAction(new Action(() =>
            {
                try
                {
                    if (_autoProbeAction == null)
                    {
                        ModifyButtons(true);
                        Log.WriteLine("AutoProbeAction finished.");
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: Start");
                    if (waitUntil > DateTime.UtcNow)
                    {
                        _autoProbeAction.QueueAction();
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: InStation [" + ESCache.Instance.InStation + "]");

                    if (ESCache.Instance.InStation)
                    {
                        Log.WriteLine("That doesn't work in stations.");
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: InSpace [true]");

                    if (ESCache.Instance.InWarp)
                    {
                        if (DirectEve.Interval(10000)) Log.WriteLine("Waiting, in warp.");
                        _autoProbeAction.QueueAction();
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: InWarp [" + ESCache.Instance.InWarp + "]");

                    if (ESCache.Instance.probeScannerWindow == null)
                    {
                        ESCache.Instance.DirectEve.ExecuteCommand(DirectCmd.CmdToggleSolarSystemMap);
                        _autoProbeAction.QueueAction();
                        return;
                    }

                    if (ESCache.Instance.probeScannerWindow.pyProbeScannerPalette == null)
                    {
                        _autoProbeAction.QueueAction();
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: pyProbeScannerPalette found");

                    if (!Scanner.LaunchProbesIfNeeded())
                    {
                        if (DebugConfig.DebugProbeScanner) Log.WriteLine("if (!Scanner.LaunchProbesIfNeeded())");
                        _autoProbeAction.QueueAction();
                        waitUntil = DateTime.UtcNow.AddSeconds(2);
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: Probes Launched!");

                    if (!Scanner.PullProbesIfNeeded())
                    {
                        if (DebugConfig.DebugProbeScanner) Log.WriteLine("if (!Scanner.PullProbesIfNeeded())");
                        _autoProbeAction.QueueAction();
                        waitUntil = DateTime.UtcNow.AddSeconds(2);
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: PullProbesIfNeeded: not needed");

                    // TODO: use cloaks

                    if (Scanner.IsProbeScanning())
                    {
                        if (DirectEve.Interval(10000)) Log.WriteLine("Probe scan active, waiting.");
                        _autoProbeAction.QueueAction();
                        waitUntil = DateTime.UtcNow.AddSeconds(2.5);
                        return;
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: IsProbeScanning: false");

                    List<DirectSystemScanResult> list = Scanner.FilteredSystemScanResults.ToList();
                    Log.WriteLine($"Loading {list.Count} results to datagridview.");
                    var resList = list.Select(d => new { d.Id, d.Deviation, d.SignalStrength, d.PreviousSignalStrength, d.TypeName, d.GroupName, d.ScanGroup, d.IsPointResult, d.IsSphereResult, d.IsMultiPointResult, PosVector3 = d.Pos.ToString(), DataVector3 = d.Data.ToString() }).ToList();
                    Task.Run(() =>
                    {
                        return Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = resList;
                            _onlyLoadPScanResults = false;
                        }));
                    });

                    //IEnumerable<DirectSystemScanResult> tempSystemScanResults = Scanner.FilteredSystemScanResults.Where(r => r.ScanGroup == ScanGroup.Signature && !r.IsGasSite && !r.IsRelicSite && !r.IsDataSite && r.SignalStrength < 1).OrderByDescending(i => i.IsWormhole).ThenByDescending(i => i.IsPointResult).ThenByDescending(i => i.IsSphereResult);
                    IEnumerable<DirectSystemScanResult> tempSystemScanResults = Scanner.FilteredSystemScanResults.Where(r => r.ScanGroup == ScanGroup.Signature && r.SignalStrength < 1).OrderByDescending(i => i.SignalStrength);
                    Log.WriteLine("tempSystemScanResults.Count [" + tempSystemScanResults.Count() + "]");
                    foreach (DirectSystemScanResult tempSystemScanResult in tempSystemScanResults)
                    {
                        Log.WriteLine("ScanResult: [" + tempSystemScanResult.Id + "] SignalStrength [" + Math.Round(tempSystemScanResult.SignalStrength, 4) + "] groupId [" + tempSystemScanResult.GroupID + "][" + tempSystemScanResult.GroupName + "] typeId [" + tempSystemScanResult.TypeID + "][" + tempSystemScanResult.TypeName + "]");
                    }

                    if (DebugConfig.DebugProbeScanner) Log.WriteLine("AutoProbeAction: 8");

                    DirectSystemScanResult result = tempSystemScanResults.FirstOrDefault();
                    if (result != null)
                    {
                        Log.WriteLine("[" + result.Id + "] SignalStrength [" + Math.Round(result.SignalStrength, 4) + "] groupId [" + result.GroupID + "][" + result.GroupName + "] typeId [" + result.TypeID + "][" + result.TypeName + "]");
                        if (false)
                        {
                            /**
                            Vector3 nextPlanetToScanFrom = Scanner.NextPlanetToScanFrom;
                            Log.WriteLine("First sig or sig has changed: Reposition and Set 16AU Range");
                            mapViewWindow.SetMaxProbeRange();
                            //mapViewWindow.MoveProbesTo(result.Pos);
                            mapViewWindow.MoveProbesTo(nextPlanetToScanFrom);
                            mapViewWindow.ProbeScan();
                            //Scanner.UpdatePreviousTempScanResults(result);
                            //_currentSig = result.Id;
                            _autoProbeAction.QueueAction();
                            waitUntil = DateTime.UtcNow.AddSeconds(2);
                            return;
                            **/
                        }
                        else
                        {
                            if (Scanner.IsAnyProbeAtMinRange)
                            {
                                Vec3 nextPlanetToScanFrom = result.vec3NextPlanetToScanFrom;
                                Log.WriteLine("[" + result.Id + "] SignalStrength [" + Math.Round(result.SignalStrength, 4) + "] Probe reached minimum range. moving planets [" + result.Id + "] groupId [" + result.GroupID + "][" + result.GroupName + "] typeId [" + result.TypeID + "][" + result.TypeName + "]");
                                Scanner.RefreshUI();
                                Scanner.SetMaxProbeRange();
                                Scanner.MoveProbesTo(nextPlanetToScanFrom);
                                lblStatus.Text = "Status: nextPlanetToScanFrom [" + Scanner.strNextPlanetToScanFrom + "] there are [" + Scanner.PlanetsLeftToScanFromString + "] more planets. Analyze Pushed [" + Scanner.ProbeScansInThisSystem + "] times";
                                Scanner.ProbeScan();
                                _autoProbeAction.QueueAction();
                                waitUntil = DateTime.UtcNow.AddSeconds(2);
                                return;
                            }
                            else
                            {
                                if (result.SignalStrength == 0)
                                {
                                    string strOldPlanet = Scanner.strNextPlanetToScanFrom;
                                    Vec3 nextPlanetToScanFrom = result.vec3NextPlanetToScanFrom;
                                    Log.WriteLine("[" + result.Id + "] SignalStrength [" + Math.Round(result.SignalStrength, 4) + "] Reposition and Set 16AU Range: skip planet [" + strOldPlanet + "]! moving on to [" + Scanner.strNextPlanetToScanFrom + "]");
                                    Scanner.SetMaxProbeRange();
                                    //mapViewWindow.MoveProbesTo(result.Pos);
                                    Scanner.MoveProbesTo(nextPlanetToScanFrom);
                                }
                                else
                                {
                                    Log.WriteLine("[" + result.Id + "] SignalStrength [" + Math.Round(result.SignalStrength, 4) + "] Decreasing Probe Range [" + result.Id + "] SignalStrength [" + result.SignalStrength + "] IsMultiPointResult [" + result.IsMultiPointResult + "] IsPointResult [" + result.IsPointResult + "] IsSphereResult[" + result.IsSphereResult + "] groupId [" + result.GroupID + "][" + result.GroupName + "] typeId [" + result.TypeID + "][" + result.TypeName + "]");
                                    Scanner.RefreshUI();
                                    Scanner.DecreaseProbeRange();
                                    Scanner.MoveProbesTo(result.Pos);
                                }

                                Scanner.ProbeScan();
                                waitUntil = DateTime.UtcNow.AddSeconds(2);
                                _autoProbeAction.QueueAction();
                                return;
                            }
                        }
                    }
                    try
                    {
                        Log.WriteLine("finished auto probing in SolarSystemID [" + ESCache.Instance.DirectEve.Session.SolarSystemId + "].");
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLine("Exception [" + ex + "]");
                    }

                    if (Scanner.FilteredSystemScanResults != null && Scanner.FilteredSystemScanResults.Count() > 0)
                    {
                        Log.WriteLine("--------------Filtered-----------------");
                        foreach (DirectSystemScanResult SystemScanResult in Scanner.FullyScannedFilteredSystemScanResults)
                        {
                            Log.WriteLine("[" + SystemScanResult.Id + "] SignalStrength [" + Math.Round(SystemScanResult.SignalStrength ,4) + "] groupId [" + SystemScanResult.GroupID + "][" + SystemScanResult.GroupName + "] typeId [" + SystemScanResult.TypeID + "][" + SystemScanResult.TypeName + "]");
                        }

                        Log.WriteLine("-------------Unfiltered----------------");
                        foreach (DirectSystemScanResult SystemScanResult in Scanner.SystemScanResults)
                        {
                            Log.WriteLine("[" + SystemScanResult.Id + "] SignalStrength [" + Math.Round(SystemScanResult.SignalStrength, 4) + "] groupId [" + SystemScanResult.GroupID + "][" + SystemScanResult.GroupName + "] typeId [" + SystemScanResult.TypeID + "][" + SystemScanResult.TypeName + "]");
                        }
                    }
                    else Log.WriteLine("if (!FullyScannedFilteredSystemScanResults.Any())");

                    ModifyButtons(true);
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            }));

            _autoProbeAction.Initialize().QueueAction();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _autoProbeAction = null;
            if (ControllerManager.Instance.TryGetController<ActionQueueController>(out var ac))
                ac.RemoveAllActions();
            ModifyButtons(true);
        }

        private void ModifyButtons(bool enabled = false)
        {
            Invoke(new Action(() =>
            {
                foreach (object b in Controls)
                    if (b is Button button && !((Button) b).Text.Equals("Cancel"))
                    {
                        button.Enabled = enabled;
                    }
            }));
        }

        #endregion Methods

    }
}