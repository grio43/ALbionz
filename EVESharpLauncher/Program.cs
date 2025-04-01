/*
 * Created by SharpDevelop.
 * User: dserver
 * Date: 02.12.2013
 * Time: 09:09
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using SharedComponents.EVE;
using SharedComponents.Utility;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using SharedComponents.SharedMemory;
using System.Threading.Tasks;
using SharedComponents.SQLite;

namespace EVESharpLauncher
{
    /// <summary>
    ///     Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        #region Constructors

        /// <summary>
        ///     Program entry point.
        /// </summary>
        static Program()
        {
            Debug.WriteLine("Init");
        }

        #endregion Constructors

        #region Methods

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        private static void HandleException(Exception e)
        {
            Console.WriteLine(e);
            Debug.WriteLine(e);
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Cache.IsServer = true;
            Task.Run(() =>
            {
                try
                {
                    LauncherHash.GetLauncherHash();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });
            Cache.Instance.Log($"Starting E# Launcher.");
            var path = Util.AssemblyPath.Replace(@"\", string.Empty).Replace(@"/", string.Empty);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            try
            {
                using (var pLock = (ProcessLock)CrossProcessLockFactory.CreateCrossProcessLock(100, path))
                {
                    ReadConn conn = ReadConn.Open();
                    SharpLogLiteHandler.Instance.StartListening();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                if (ex is CrossProcessLockFactoryMutexException)
                    MessageBox.Show("There is already one instance running from the this assemblypath.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Cache.Instance.Log("Exception: " + ex);
            }
        }

        #endregion Methods
    }
}