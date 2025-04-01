using EVESharpCore.Cache;
using EVESharpCore.Controllers.ActionQueue.Actions;
using EVESharpCore.Controllers.ActionQueue.Actions.Base;
using EVESharpCore.Framework;
using EVESharpCore.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVESharpCore.Controllers.Debug
{
    public partial class DebugWindows : Form
    {
        #region Constructors

        public DebugWindows()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            if (ControllerManager.Instance.TryGetController<ActionQueueController>(out var c))
                c.RemoveAllActions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModifyButtons();
            DateTime waitUntil = DateTime.MinValue;
            ActionQueueAction action = null;
            action = new ActionQueueAction(() =>
            {
                try
                {
                    if (waitUntil > DateTime.UtcNow)
                    {
                        action.QueueAction();
                        return;
                    }

                    List<DirectWindow> windows = ESCache.Instance.DirectEve.Windows;
                    var res = windows.Select(n => new {n.Name, n.Caption, n.Html, n.WindowId, n.IsDialog, n.IsKillable, n.IsModal, n.Guid, n.ViewMode}).ToList();

                    Task.Run(() =>
                    {
                        return Invoke(new Action(() =>
                        {
                            DebugWindowsDataGridView2.DataSource = res;
                            ModifyButtons(true);
                        }));
                    });
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            });
            action.Initialize().QueueAction();
        }

        private void copyIdToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                long id = (long) DebugWindowsDataGridView2.SelectedRows[0].Cells["Id"].Value;
                Thread thread = new Thread(() => Clipboard.SetText(id.ToString()));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ModifyButtons(bool enabled = false)
        {
            Invoke(new Action(() =>
            {
                foreach (object b in Controls)
                    if (b is Button button)
                        button.Enabled = enabled;
            }));
        }

        private void monitorEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                long id = (long) DebugWindowsDataGridView2.SelectedRows[0].Cells["Id"].Value;
                new MonitorPyObjectAction(() =>
                {
                    return ESCache.Instance.DirectEve.EntitiesById[id].Ball;

                    //}, new List<string>() { }).Initialize().QueueAction();
                }, new List<string> {"__dict__", "__iroot__", "modelLoadSignal"}).Initialize().QueueAction();
                new MonitorEntityAction(() => { return ESCache.Instance.DirectEve.EntitiesById[id]; }).Initialize().QueueAction();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        #endregion Methods
    }
}