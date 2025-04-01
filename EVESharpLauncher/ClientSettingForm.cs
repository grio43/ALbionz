using SharedComponents.EVE;
using SharedComponents.EVE.ClientSettings;
using SharedComponents.EVE.ClientSettings.SharedComponents.EVE.ClientSettings;
using SharedComponents.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SharedComponents.Extensions;
using System.Diagnostics;

namespace EVESharpLauncher
{
    public partial class ClientSettingForm : Form
    {
        #region Fields

        private const int CONTROL_WIDTH = 600;
        private EveAccount _eA;
        private int _questorSettingGroupChangedCounter;
        private List<EveAccount> _questorSettingSyncList;

        #endregion Fields

        #region Constructors

        public ClientSettingForm(EveAccount eveAccount)
        {
            _eA = eveAccount;

            InitializeComponent();
            Text = string.Format("ClientSetting [{0}]", _eA.CharacterName);

            if (_eA.ClientSetting == null)
                _eA.ClientSetting = new ClientSetting();
            Height = (int)(Screen.FromControl(this).Bounds.Height * 0.7);
            Width = (int)(Screen.FromControl(this).Bounds.Width * 0.5);
        }

        #endregion Constructors

        #region Methods

        public void AddBoolProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var panel = new TableLayoutPanel()
            {
                RowCount = 1,
                ColumnCount = 1,
                Width = pWidth
            };
            var checkbox = new CheckBox()
            {
                Text = p.Name,
                AutoSize = true,
                Padding = new Padding(3, 0, 0, 0)
            };
            var binding = new Binding("Checked", ds, p.Name);
            panel.Controls.Add(checkbox, 0, 0);
            checkbox.DataBindings.Add(binding);
            var toolTip = new ToolTip();
            toolTip.SetToolTip(checkbox, GetDescriptionAttributeValue(p));

            panel.Height = checkbox.Height;
            pa.Controls.Add(panel);
        }

        public void AddEnumProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var groupbox1 = new GroupBox()
            {
                Text = p.Name
            };
            var combobox = new ComboBox();
            groupbox1.Width = pWidth;
            combobox.Dock = DockStyle.Fill;
            groupbox1.Height = combobox.Height + 20;
            groupbox1.Controls.Add(combobox);
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.DataSource = Enum.GetValues(p.PropertyType);
            combobox.DataBindings.Add(new Binding("SelectedItem", ds, p.Name));
            combobox.MouseWheel += Combobox_MouseWheel;
            var toolTip = new ToolTip();
            toolTip.SetToolTip(combobox, GetDescriptionAttributeValue(p));
            pa.Controls.Add(groupbox1);
        }

        private void Combobox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private Type GetListType(IEnumerable enumerable)
        {
            try
            {
                var type = enumerable.GetType();
                var enumerableType = type
                    .GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    .First();
                return enumerableType.GetGenericArguments()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void AddIntOrStringProperty(Panel pa, object ds, PropertyInfo p, ConvertEventHandler con, int pWidth = CONTROL_WIDTH)
        {
            var panel = new TableLayoutPanel();
            panel.RowCount = 1;
            panel.ColumnCount = 2;
            var textbox = new TextBox();
            panel.Height = textbox.Height + 4;
            panel.Width = pWidth;
            var label = new Label()
            {
                Text = p.Name,
                AutoSize = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            textbox.Dock = DockStyle.Fill;

            var toolTip = new ToolTip();
            toolTip.SetToolTip(label, GetDescriptionAttributeValue(p));
            toolTip.SetToolTip(textbox, GetDescriptionAttributeValue(p));

            panel.Controls.Add(label, 0, 0);
            panel.Controls.Add(textbox, 1, 0);
            pa.Controls.Add(panel);
            var binding = new Binding("Text", ds, p.Name);
            if (con != null)
                binding.Parse += con;
            textbox.DataBindings.Add(binding);
            textbox.TextChanged += delegate (object sender, EventArgs args)
            {
                if (p.Name.Equals(nameof(_eA.ClientSetting.QuestorMainSetting.QuestorSettingGroup)))
                {
                    if (_questorSettingGroupChangedCounter > 0)
                    {
                        p.SetValue(ds,
                            Convert.ChangeType(textbox.Text, p.PropertyType),
                            null);
                        ReloaderQuestorGroupSnyc();
                    }

                    _questorSettingGroupChangedCounter++; // counter to allow ignoring the inital change
                }
            };
        }

        public void AddMultiSelectProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var groupbox1 = new GroupBox()
            {
                Text = p.Name
            };
            var tableLayout = new TableLayoutPanel();
            tableLayout.RowCount = 2;
            tableLayout.ColumnCount = 1;
            tableLayout.Dock = DockStyle.Fill;
            groupbox1.Width = pWidth;
            groupbox1.Height = 300;
            groupbox1.Controls.Add(tableLayout);
            var combobox = new ComboBox();
            combobox.Dock = DockStyle.Fill;
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.DataSource = Enum.GetValues(GetBindingListType(p.GetValue(ds)));
            tableLayout.Controls.Add(combobox, 0, 0);
            var listbox = new ListBox();
            listbox.Dock = DockStyle.Fill;
            listbox.DataSource = p.GetValue(ds) as IList;
            tableLayout.Controls.Add(listbox, 0, 1);
            var contextMenu = new ContextMenuStrip();
            var toolTip = new ToolTip();
            toolTip.SetToolTip(groupbox1, GetDescriptionAttributeValue(p));
            toolTip.SetToolTip(combobox, GetDescriptionAttributeValue(p));
            toolTip.SetToolTip(listbox, GetDescriptionAttributeValue(p));

            combobox.SelectedIndexChanged += delegate (object sender, EventArgs args)
            {
                var selected = (Enum)combobox.SelectedItem;
                var list = p.GetValue(ds) as IList;
                if (list == null)
                    return;
                if (list.Contains(selected))
                    return;
                list.Add(selected);
                listbox.DataSource = null;
                listbox.DataSource = list;
            };
            listbox.MouseDown += delegate (object sender, MouseEventArgs args)
            {
                if (args.Button == MouseButtons.Right)
                {
                    var index = listbox.IndexFromPoint(args.Location);
                    if (index != -1)
                    {
                        listbox.SelectedIndex = index;
                        contextMenu.Show(listbox, args.Location);
                    }
                }
            };
            contextMenu.Items.Add("Delete", null, delegate (object o, EventArgs eventArgs)
            {
                var selected = listbox.SelectedItem;
                var list = p.GetValue(ds) as IList;
                if (list == null)
                    return;
                list.Remove(selected);
                listbox.DataSource = null;
                listbox.DataSource = list;
            });
            contextMenu.Items.Add("Move Up", null, delegate (object o, EventArgs eventArgs)
            {
                var selected = listbox.SelectedItem;
                var list = p.GetValue(ds) as IList;
                if (list == null)
                    return;
                var index = list.IndexOf(selected);
                if (index == 0)
                    return;
                list.Remove(selected);
                list.Insert(index - 1, selected);
                listbox.DataSource = null;
                listbox.DataSource = list;
            });
            contextMenu.Items.Add("Move Down", null, delegate (object o, EventArgs eventArgs)
            {
                var selected = listbox.SelectedItem;
                var list = p.GetValue(ds) as IList;
                if (list == null)
                    return;
                var index = list.IndexOf(selected);
                if (index == list.Count - 1)
                    return;
                list.Remove(selected);
                list.Insert(index + 1, selected);
                listbox.DataSource = null;
                listbox.DataSource = list;
            });
            pa.Controls.Add(groupbox1);
        }

        public void AddControlListProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var groupbox = new GroupBox()
            {
                Text = p.Name,
                Width = pa.Width - 10,
                Height = pa.Height,
                Dock = DockStyle.Top,
                Padding = new Padding(5)
            };

            var toolTip = new ToolTip();
            toolTip.SetToolTip(groupbox, GetDescriptionAttributeValue(p));

            var list = p.GetValue(ds) as IEnumerable;
            var listType = GetListType(list);

            if (listType == null)
            {
                pa.Controls.Add(groupbox);
                return;
            }

            var tabControl = new TabControl()
            {
                Dock = DockStyle.Fill,
                Multiline = true
            };

            var buttonsPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 35,
                Padding = new Padding(5)
            };

            var addButton = new Button()
            {
                Text = "Add Item",
                Width = 80,
                Dock = DockStyle.Left
            };

            var deleteButton = new Button()
            {
                Text = "Delete Item",
                Width = 80,
                Dock = DockStyle.Right,
                Enabled = false,
            };

            addButton.Click += (sender, e) =>
            {
                try
                {
                    var newItem = Activator.CreateInstance(listType);
                    var addMethod = list.GetType().GetMethod("Add");
                    addMethod.Invoke(list, new[] { newItem });
                    int newIndex = tabControl.TabCount + 1;
                    AddItemTab(tabControl, newItem, list, listType, pWidth - 20, newIndex);
                    deleteButton.Enabled = tabControl.TabCount > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding item: {ex.Message}");
                }
            };

            deleteButton.Click += (sender, e) =>
            {
                if (tabControl.SelectedTab != null)
                {
                    try
                    {
                        var selectedTab = tabControl.SelectedTab;
                        var item = selectedTab.Tag;
                        var removeMethod = list.GetType().GetMethod("Remove");
                        removeMethod.Invoke(list, new[] { item });
                        tabControl.TabPages.Remove(selectedTab);
                        UpdateTabNames(tabControl);
                        deleteButton.Enabled = tabControl.TabCount > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error removing item: {ex.Message}");
                    }
                }
            };

            tabControl.SelectedIndexChanged += (sender, e) =>
            {
                deleteButton.Enabled = tabControl.TabCount > 0;
            };

            buttonsPanel.Controls.Add(addButton);
            buttonsPanel.Controls.Add(deleteButton);
            groupbox.Controls.Add(tabControl);
            groupbox.Controls.Add(buttonsPanel);
            pa.Controls.Add(groupbox);

            foreach (var item in list)
            {
                int newIndex = tabControl.TabCount + 1;
                AddItemTab(tabControl, item, list, listType, pWidth - 20, newIndex);
            }

            deleteButton.Enabled = tabControl.TabCount > 0;
        }

        public void AddSelectableTypeProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoSize = true;

            var label = new Label()
            {
                Text = p.Name,
                AutoSize = true,
            };

            var comboBox = new ComboBox()
            {
                Width = pWidth - 20,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            var toolTip = new ToolTip();
            toolTip.SetToolTip(label, GetDescriptionAttributeValue(p));


            flowLayoutPanel.Controls.Add(label);
            flowLayoutPanel.Controls.Add(comboBox);
            pa.Controls.Add(flowLayoutPanel);


            var selectableTypes = GetSelectableTypeAttributeValue(p);
            if (selectableTypes != null && selectableTypes.Count > 0)
            {
                // Add types to the combobox
                foreach (var type in selectableTypes)
                {
                    comboBox.Items.Add(type);
                }

                // Set the display member to show the type name
                comboBox.DisplayMember = "Name";

                // Set the current value
                var currentValue = p.GetValue(ds);
                if (currentValue != null)
                {
                    var currentType = currentValue.GetType();
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var type = comboBox.Items[i] as Type;
                        if (type == currentType)
                        {
                            comboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // Handle selection change
                comboBox.SelectedIndexChanged += (sender, e) =>
                {
                    if (comboBox.SelectedItem != null)
                    {
                        var selectedType = comboBox.SelectedItem as Type;
                        if (selectedType != null)
                        {
                            try
                            {
                                // Create a new instance of the selected type
                                var newInstance = Activator.CreateInstance(selectedType);
                                p.SetValue(ds, newInstance);

                                // Clear the TabControl
                                flowLayoutPanel.Controls.Clear();
                                flowLayoutPanel.Controls.Add(label);
                                flowLayoutPanel.Controls.Add(comboBox);

                                EnumeratePropertiesAndAddControlsToPanel(flowLayoutPanel, newInstance);
                                flowLayoutPanel.Refresh();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error creating instance of {selectedType.Name}: {ex.Message}");
                            }
                        }
                    }
                };

                // Initialize the TabControl with the current value
                if (currentValue != null)
                {
                    // Use TraversePropertiesRecursive to populate the TabControl
                    var propertyList = new List<Tuple<PropertyInfo, int>>();
                    EnumeratePropertiesAndAddControlsToPanel(flowLayoutPanel, currentValue);
                    flowLayoutPanel.Refresh();
                }
            }
        }



        private void AddItemTab(TabControl tabControl, object item, IEnumerable list, Type listType, int pWidth, int itemIndex)
        {
            var tabPage = new TabPage($"Item {itemIndex}");
            tabPage.Width = pWidth;
            tabPage.Tag = item;

            bool hasTabAttributes = item.GetType().GetProperties().Any(p => GetTabAttributeValue(p) != null);

            if (hasTabAttributes)
            {
                var nestedTabControl = new TabControl()
                {
                    Dock = DockStyle.Fill,
                    Width = pWidth,
                    Multiline = true,
                };

                tabPage.Controls.Add(nestedTabControl);
                var propertyList = new List<Tuple<PropertyInfo, int>>();
                TraversePropertiesRecursive(propertyList, item, 0, nestedTabControl);
            }
            else
            {
                var propertiesPanel = new Panel()
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    Width = pWidth,
                    Padding = new Padding(10)
                };

                tabPage.Controls.Add(propertiesPanel);
                EnumeratePropertiesAndAddControlsToPanel(propertiesPanel, item, pWidth);
            }

            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }

        private void UpdateTabNames(TabControl tabControl)
        {
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                tabControl.TabPages[i].Text = $"Item {i + 1}";
            }
        }

        public void AddListProperty(Panel pa, object ds, PropertyInfo p, int pWidth = CONTROL_WIDTH)
        {
            var groupbox1 = new GroupBox()
            {
                Text = p.Name
            };
            var datagrid1 = new DataGridView()
            {
                Dock = DockStyle.Fill,
                SelectionMode = DataGridViewSelectionMode.CellSelect
            };
            datagrid1.CellMouseDown += delegate (object sender, DataGridViewCellMouseEventArgs args)
            {
                if (args.RowIndex != -1 && args.ColumnIndex != -1)
                    if (args.Button == MouseButtons.Right)
                    {
                        var clickedCell = (sender as DataGridView).Rows[args.RowIndex].Cells[args.ColumnIndex];
                        datagrid1.CurrentCell = clickedCell;
                        var relativeMousePosition = datagrid1.PointToClient(Cursor.Position);
                        var contextMenuStrip = new ContextMenuStrip();
                        contextMenuStrip.Items.Add("Delete", null, delegate (object o, EventArgs eventArgs)
                        {
                            try
                            {
                                datagrid1.Rows.RemoveAt(args.RowIndex);
                            }
                            catch (Exception)
                            {
                            }
                        });
                        contextMenuStrip.Show(datagrid1, relativeMousePosition);
                    }
            };
            groupbox1.Width = pWidth;
            groupbox1.Height = 300;
            var toolTip = new ToolTip();
            toolTip.SetToolTip(groupbox1, GetDescriptionAttributeValue(p));
            groupbox1.Controls.Add(datagrid1);
            pa.Controls.Add(groupbox1);
            datagrid1.DataSource = p.GetValue(ds);


            // Below code for DataGridViewComboBoxColumns  
            // Enum Types are automatically converted to DataGridViewComboBoxColumns, set [Browsable(false)] attribute!
            var list = p.GetValue(ds) as IEnumerable;
            var objList = new List<object>();
            foreach (var obj in list)
            {
                objList.Add(obj);
            }

            var listType = GetListType(list);
            List<PropertyInfo> propInfosAdded = new List<PropertyInfo>();
            if (listType != null)
            {
                var n = 0;
                foreach (var propInfo in listType.GetProperties())
                {
                    if (propInfo.PropertyType.IsEnum && !IsBrowsableAttribute(propInfo))
                    //if (propInfo.PropertyType.IsEnum)
                    {
                        var enumOrdering = propInfo.GetCustomAttribute<EnumOrderingAttribute>()?.Order ?? EnumOrderingAttribute.EnumOrdering.None;

                        propInfosAdded.Add(propInfo);
                        var cmb = new DataGridViewComboBoxColumn();
                        var items = Enum.GetNames(propInfo.PropertyType).ToList();
                        if (enumOrdering == EnumOrderingAttribute.EnumOrdering.Name)
                            items.Sort();
                        if (enumOrdering == EnumOrderingAttribute.EnumOrdering.Value)
                            items = items.OrderBy(x => (int)Enum.Parse(propInfo.PropertyType, x)).ToList();

                        cmb.DataSource = items;
                        cmb.Name = propInfo.Name.ToString();
                        cmb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        datagrid1.Columns.Insert(n, cmb);
                    }
                    n++;
                }
            }

            datagrid1.CellValueChanged += delegate (object sender, DataGridViewCellEventArgs args)
            {
                var dgv = (DataGridView)sender;
                if (datagrid1.SelectedCells.Count == 0)
                    return;
                var c = datagrid1.SelectedCells[0];
                var index = c.OwningRow.Index;
                if (propInfosAdded.Any(px => px.Name == c.OwningColumn.Name) && c.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                    var propInfo = propInfosAdded.FirstOrDefault(px => px.Name == c.OwningColumn.Name);
                    try
                    {
                        if (index < objList.Count)
                        {
                            var k = c as DataGridViewComboBoxCell;
                            var item = objList[index];
                            var enumValue = Enum.Parse(propInfo.PropertyType, k.Value.ToString());
                            item.GetType().GetProperty(propInfo.Name).SetValue(item, enumValue);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                datagrid1.AutoResizeColumns();
            };

            datagrid1.RowsAdded += delegate (object sender, DataGridViewRowsAddedEventArgs args)
            {
                foreach (DataGridViewRow r in datagrid1.Rows)
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if (propInfosAdded.Any(px => px.Name == c.OwningColumn.Name) && c.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                        {
                            var propInfo = propInfosAdded.FirstOrDefault(px => px.Name == c.OwningColumn.Name);
                            var index = c.OwningRow.Index;
                            try
                            {
                                if (index < objList.Count)
                                {
                                    var k = c as DataGridViewComboBoxCell;
                                    var item = objList[index];
                                    var itemVal = item.GetType().GetProperty(propInfo.Name).GetValue(item);
                                    k.Value = itemVal.ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
            };

            foreach (DataGridViewRow r in datagrid1.Rows) // load value
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (propInfosAdded.Any(px => px.Name == c.OwningColumn.Name) && c.OwningColumn.GetType() == typeof(DataGridViewComboBoxColumn))
                    {
                        var propInfo = propInfosAdded.FirstOrDefault(px => px.Name == c.OwningColumn.Name);
                        var index = c.OwningRow.Index;
                        try
                        {
                            if (index < objList.Count)
                            {
                                var k = c as DataGridViewComboBoxCell;
                                var item = objList[index];
                                var itemVal = item.GetType().GetProperty(propInfo.Name).GetValue(item);
                                k.Value = itemVal.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
        }

        public void EnumeratePropertiesAndAddControlsToPanel(Panel pa, object ds, int pWidth = CONTROL_WIDTH)
        {
            foreach (var property in ds.GetType().GetProperties())
            {
                if (!IsBrowsableAttribute(property))
                    continue;

                if (property.PropertyType == typeof(bool))
                    AddBoolProperty(pa, ds, property, pWidth);

                if (property.PropertyType == typeof(int))
                    AddIntOrStringProperty(pa, ds, property, delegate (object sender, ConvertEventArgs args)
                    {
                        Int32.TryParse((string)args.Value, out var result);
                        args.Value = result;
                    }, pWidth);


                if (property.PropertyType == typeof(long)) // TODO: fix me
                {
                    AddIntOrStringProperty(pa, ds, property, delegate (object sender, ConvertEventArgs args)
                    {
                        long.TryParse((string)args.Value, out var result);
                        args.Value = result;
                    }, pWidth);
                }

                if (property.PropertyType == typeof(string))
                    AddIntOrStringProperty(pa, ds, property, null, pWidth);

                if (GetSelectableTypeAttributeValue(property) != null)
                {
                    AddSelectableTypeProperty(pa, ds, property, pWidth);
                    continue;
                }

                if (property.PropertyType.IsEnum)
                {
                    AddEnumProperty(pa, ds, property, pWidth);
                    continue;
                }

                if (GetBindingListType(property.GetValue(ds))?.IsEnum ?? false)
                {
                    AddMultiSelectProperty(pa, ds, property, pWidth);
                    continue;
                }

                if (IsBindingList(property.GetValue(ds)) && property.GetCustomAttribute<ControlListAttribute>() != null)
                {
                    AddControlListProperty(pa, ds, property, pWidth);
                    continue;
                }

                if (IsBindingList(property.GetValue(ds)))
                {
                    AddListProperty(pa, ds, property, pWidth);
                    continue;
                }
            }
        }

        public String GetDescriptionAttributeValue(PropertyInfo p)
        {
            var attributes = p.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? "No description." : ((DescriptionAttribute)attributes[0]).Description;
        }

        public string GetTabAttributeValue(PropertyInfo p)
        {
            var a = p.GetCustomAttributes(typeof(TabPageAttribute), false);
            var b = p.GetCustomAttributes(typeof(TabRootAttribute), false);
            return a.Length == 0 ? b.Length == 0 ? null : ((TabRootAttribute)b[0]).Name : ((TabPageAttribute)a[0]).Name;
        }

        public ICollection<Type> GetSelectableTypeAttributeValue(PropertyInfo p)
        {
            var a = p.GetCustomAttribute<SelectableTypeAttribute>(false);
            return a?.Types;
        }

        public bool HasTabPageAttribute(PropertyInfo p)
        {
            var b = p.GetCustomAttributes(typeof(TabPageAttribute), false);
            return b.Length != 0;
        }

        public bool HasTabRootAttribute(PropertyInfo p)
        {
            var b = p.GetCustomAttributes(typeof(TabRootAttribute), false);
            return b.Length != 0;
        }

        public bool IsBindingList(object o)
        {
            return o is IBindingList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(BindingList<>));
        }

        public Type GetBindingListType(object o)
        {
            if (!IsBindingList(o))
                return null;
            return o.GetType().GetGenericArguments()[0];
        }

        public bool IsBrowsableAttribute(PropertyInfo p)
        {
            var attributes = p.GetCustomAttributes(typeof(BrowsableAttribute), false);
            return attributes.Length == 0 ? true : ((BrowsableAttribute)attributes[0]).Browsable;
        }

        public bool IsList(object o)
        {
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        public void ReloaderQuestorGroupSnyc()
        {
            _questorSettingSyncList = new List<EveAccount>();
            if (!String.IsNullOrEmpty(_eA.ClientSetting.QuestorMainSetting.QuestorSettingGroup))
            {
                var group = _eA.ClientSetting.QuestorMainSetting.QuestorSettingGroup;
                foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList().Where(e =>
                    e != _eA && e.ClientSetting != null && !string.IsNullOrEmpty(e.ClientSetting.QuestorMainSetting.QuestorSettingGroup) &&
                    e.ClientSetting.QuestorMainSetting.QuestorSettingGroup.Equals(group)))
                    _questorSettingSyncList.Add(eA);
            }

            Text = string.Format("ClientSetting [{0}]", _eA.CharacterName);
            if (_questorSettingSyncList.Count > 0)
                Text += $" Sync [{string.Join(",", _questorSettingSyncList.Select(e => e.CharacterName))}]";

            if (_questorSettingSyncList.Any(ev => ev.ClientSetting != null && ev != _eA))
                _eA.CS.QMS.QuestorSetting = _questorSettingSyncList.FirstOrDefault(ev => ev.ClientSetting != null && ev != _eA).CS.QMS.QS;

            foreach (var eA in _questorSettingSyncList.Where(ev => ev.ClientSetting != null))
                eA.CS.QMS.QuestorSetting = _eA.ClientSetting.QuestorMainSetting.QuestorSetting;

            foreach (var eA in Cache.Instance.EveAccountSerializeableSortableBindingList.List.ToList().Where(e =>
                e != _eA && e.ClientSetting != null && !_questorSettingSyncList.Contains(e)
                && _eA.ClientSetting.QuestorMainSetting.QuestorSetting == e.ClientSetting.QuestorMainSetting.QuestorSetting))
                eA.ClientSetting = eA.ClientSetting.Clone();
        }

        public void SetupControls()
        {
            tabControl1.TabPages.Clear();
            ReloaderQuestorGroupSnyc();
            TraversePropertiesRecursive(new List<Tuple<PropertyInfo, int>>(), _eA.ClientSetting, -1, tabControl1);
            tabControl1.SelectedIndex = 0;

        }

        public List<Tuple<PropertyInfo, int>> TraversePropertiesRecursive(List<Tuple<PropertyInfo, int>> list, object obj, int depth,
                                                                                                                            TabControl parentTabControl)
        {
            depth++;
            var properties = obj.GetType().GetProperties().ToList();
            TabPage mainTabPage = null;
            foreach (var property in properties)
            {
                if (GetTabAttributeValue(property) != null)
                {
                    if (!parentTabControl.TabPages.ContainsKey(GetTabAttributeValue(property)))
                    {
                        var page = new TabPage(GetTabAttributeValue(property));
                        parentTabControl.TabPages.Add(page);

                        Console.WriteLine($"Selecting tab (1) {page.Text}");
                        parentTabControl.SelectTab(page);
                    }

                    var flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.Dock = DockStyle.Fill;
                    flowLayoutPanel.AutoScroll = true;

                    list.Add(new Tuple<PropertyInfo, int>(property, depth));
                    var tabControl = parentTabControl;
                    if (HasTabRootAttribute(property))
                    {
                        var tabc = new TabControl();
                        var page = new TabPage("Main");
                        mainTabPage = page;
                        tabc.TabPages.Add(page);

                        tabc.Dock = DockStyle.Fill;
                        page.Controls.Add(flowLayoutPanel);
                        parentTabControl.TabPages[parentTabControl.TabPages.Count - 1].Controls.Add(tabc);
                        tabControl = tabc;
                    }

                    if (HasTabPageAttribute(property))
                    {
                        parentTabControl.TabPages[parentTabControl.TabPages.Count - 1].Controls.Add(flowLayoutPanel);
                    }

                    var flowPanelTabPageParent = flowLayoutPanel.Parent as TabPage;
                    var flowPanelTabControlParent = flowPanelTabPageParent.Parent as TabControl;

                    flowPanelTabControlParent.SelectTab(flowPanelTabPageParent);
                    //Console.WriteLine($"Selecting tab (2) {flowPanelTabPageParent.Text}");

                    EnumeratePropertiesAndAddControlsToPanel(flowLayoutPanel, property.GetValue(obj), parentTabControl.Width - 40);
                    TraversePropertiesRecursive(list, property.GetValue(obj), depth, tabControl);

                    try
                    {

                        if (mainTabPage != null)
                            tabControl.SelectTab(mainTabPage);
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }


                    //var tabList = parentTabControl.TabPages.Cast<TabPage>().ToList();
                    //tabList.Sort((x, y) => string.Compare(x.Text, y.Text));
                    //parentTabControl.TabPages.Clear();
                    //parentTabControl.TabPages.AddRange(tabList.ToArray());
                }
            }

            return list;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Util.XmlSerialize(_eA.ClientSetting));
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = Util.XmlDeserialize(Clipboard.GetText(), _eA.ClientSetting.GetType());
                if (result is ClientSetting setting)
                {
                    _eA.ClientSetting = setting;
                    Cache.Instance.Log($"Settings imported.");
                    SetupControls();
                }
            }
            catch (Exception ex)
            {
                Cache.Instance.Log($"Exception {ex}");
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupControls();
        }

        #endregion Methods

        private void ClientSettingForm_Shown(object sender, EventArgs e)
        {

        }

        private void ClientSettingForm_Load(object sender, EventArgs e)
        {
            using (new DisposableStopwatch(t =>
            {

                //Cache.Instance.Log($"{1000000 * t.Ticks / Stopwatch.Frequency}  µs elapsed.");
                Cache.Instance.Log($"{(1000000 * t.Ticks / Stopwatch.Frequency) / 1000} ms elapsed.");

            }))
            {
                SetupControls();
            }
        }
    }
}