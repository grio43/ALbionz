extern alias SC;

using EVESharpCore.Cache;
using EVESharpCore.Controllers.ActionQueue.Actions.Base;
using EVESharpCore.Framework;
using EVESharpCore.Logging;
using SC::SharedComponents.EVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVESharpCore.Controllers.Debug
{
    public partial class DebugHardware : Form
    {
        #region Constructors

        public DebugHardware()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void button2_Click(object sender, EventArgs e)
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

                    DirectContainer shipsCargo = ESCache.Instance.DirectEve.GetShipsCargo();
                    if (shipsCargo == null)
                    {
                        action.QueueAction();
                        return;
                    }

                    List<DirectItem> charges = shipsCargo.Items.Where(i => i.CategoryId == (int)CategoryID.Charge).ToList();
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)contextMenuStrip1.Items[1];
                    toolStripMenuItem.DropDownItems.Clear();

                    foreach (var c in charges)
                        {
                        toolStripMenuItem.DropDownItems.Add($"{c.TypeName} ({c.Quantity})", null, new EventHandler(delegate (object s, EventArgs ev)
                        {
                            Int64 itemId = 0;
                            try
                            {
                                int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                                itemId = Convert.ToInt64(selectedRow.Cells["ItemId"].Value);
                            }
                            catch (Exception exception)
                            {
                                Log.WriteLine(exception.ToString());
                                throw;
                            }

                            ModifyButtons();
                            ActionQueueAction ac = null;
                            ac = new ActionQueueAction(new Action(() =>
                            {
                                try
                                {
                                    ModuleCache module = ESCache.Instance.Modules.Find(m => m.ItemId.Equals(itemId));
                                    DirectItem charge = ESCache.Instance.CurrentShipsCargo.Items.Find(i => i.TypeId == c.TypeId && i.Quantity == c.Quantity);
                                    if (module != null && charge != null)
                                    {
                                        Log.WriteLine($"Changing ammo.");
                                        module._module.ChangeAmmo(charge);
                                    }
                                    ModifyButtons(true);
                                }
                                catch (Exception ex)
                                {
                                    Log.WriteLine(ex.ToString());
                                }
                            }));
                            ac.Initialize().QueueAction();
                        }));
                    }

                    var resList = ESCache.Instance.Modules.Select(d => new
                    {
                        d.TypeId,
                        d.GroupId,
                        d.TypeName,
                        d.IsReloadingAmmo,
                        d._module.CanBeReloaded,
                        d.IsActivatable,
                        d.IsInLimboState,
                        d.Duration,
                        d.IsActive,
                        d._module.EffectId,
                        d._module.EffectName,
                        d._module.EffectCategory,
                        d._module.IsEffectOffensive,
                        d.TargetId,
                        d.IsDeactivating,
                        d.ItemId,
                        ChargeTypeId = d.Charge != null && d.Charge.PyItem.IsValid ? d.Charge.TypeId : 0,
                        ChargeTypeName = d.Charge != null && d.Charge.PyItem.IsValid ? d.Charge.TypeName : string.Empty,
                        ChargeQty = d._module.ChargeQty,
                        ChargeGroupId = d.Charge != null && d.Charge.PyItem.IsValid ? d.Charge.GroupId : 0,
                        ChargeCategoryId = d.Charge != null && d.Charge.PyItem.IsValid ? d.Charge.CategoryId : 0,
                    }).ToList();
                    Task.Run(() =>
                    {
                        return Invoke(new Action(() =>
                        {
                            dataGridView1.DataSource = resList;
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

        private void ModifyButtons(bool enabled = false)
        {
            Invoke(new Action(() =>
            {
                foreach (object b in Controls)
                    if (b is Button button)
                        button.Enabled = enabled;
            }));
        }

        private void printAllItemAttributesToolStripMenuItem_Click(object sender, EventArgs e)
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

                    Int64 itemId = 0;
                    try
                    {
                        int index = dataGridView1.SelectedCells[0].OwningRow.Index;
                        DataGridViewRow selectedRow = dataGridView1.Rows[index];
                        itemId = Convert.ToInt64(selectedRow.Cells["ItemId"].Value);

                        ModuleCache module = ESCache.Instance.Modules.Find(m => m.ItemId.Equals(itemId));
                        foreach (var attribute in module._module.Attributes.GetAttributes())
                        {
                            Log.WriteLine($"Key: {attribute.Key} Value: {attribute.Value}");
                        }
                    }
                    catch (Exception exception)
                    {
                        Log.WriteLine(exception.ToString());
                        throw;
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

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
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

                    ESCache.Instance.DirectEve.ExecuteCommand(DirectCmd.CmdReloadAmmo);
                    ModifyButtons(true);
                }
                catch (Exception ex)
                {
                    Log.WriteLine(ex.ToString());
                }
            }));
            action.Initialize().QueueAction();
        }

        #endregion Methods

        private void clickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedCells[0].OwningRow.Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            var itemId = Convert.ToInt64(selectedRow.Cells["ItemId"].Value);

            ActionQueueAction.Run(() =>
            {
                var module = ESCache.Instance.Modules.Find(m => m.ItemId.Equals(itemId));
                if (module != null)
                {
                    Log.WriteLine($"Executed module click. Module {module.TypeName} {module.TypeId}");
                    module.Click();
                }
            });
        }

        private void BtnShowPublicIP_Click(object sender, EventArgs e)
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

                    Task.Run(() =>
                    {
                        return Invoke(new Action(() =>
                        {
                            Log.WriteLine("BtnShowPublicIP_Click: executed: this is not yet ready for use: todo: fix");
                            ESCache.Instance.EveAccount.HWSettings.Proxy.CheckSocks5InternetConnectivity(new EveAccount("TestAccount", "TestChar", "TestPassword", DateTime.UtcNow, DateTime.UtcNow, "test@gmail.com", "password"));
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
    }
}