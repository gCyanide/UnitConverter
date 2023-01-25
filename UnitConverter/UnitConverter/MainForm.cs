using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Threading;

namespace UnitConverter
{
    public partial class MainForm : Form
    {
        // Import DLL for the widget's ability to change text out of the main form.
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        // Import DLL for the widget's global hotkey hook.
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        // Widget hotkey IDs (readonly).
        readonly int UniqueHotkeyId = 1;
        readonly int HotKeyCode = (int)Keys.Oemtilde;

        // XML related: serializer.
        public XmlSerializer xmlSerializer = new(typeof(Units));
        // XML related: global collection.
        public Units units;

        public MainForm()
        {
            InitializeComponent();

            // Reading all XML data after the form is loaded.
            using (FileStream filestream = new("units.xml", FileMode.Open))
            {
                units = xmlSerializer.Deserialize(filestream) as Units;
            }

            // Register Tilde as hotkey.
            Boolean TildeRegistered = RegisterHotKey(
                this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
            );
            
            if (TildeRegistered)
            {
                Console.WriteLine("Widget hotkey registred successfully.");
            }
            else
            {
                Console.WriteLine("Widget hotkey couldn't be registred.");
            }

            // This code block is necessary due to index -1 error.
            AreaFromLB.SelectedIndex = 0;
            AreaToLB.SelectedIndex = 0;
            LengthFromLB.SelectedIndex = 0;
            LengthToLB.SelectedIndex = 0;
            TemperatureFromLB.SelectedIndex = 0;
            TemperatureToLB.SelectedIndex = 0;
            TimeFromLB.SelectedIndex = 0;
            TimeToLB.SelectedIndex = 0;
            VolumeFromLB.SelectedIndex = 0;
            VolumeToLB.SelectedIndex = 0;
            WeightFromLB.SelectedIndex = 0;
            WeightToLB.SelectedIndex = 0;
            EncodingFromCB.SelectedIndex = 0;
            EncodingToCB.SelectedIndex = 0;
        }

        #region Form Base Events
        /// <summary>
        /// [EVENT]: Minimizes the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// [EVENT]: Minimizes the main window to tray.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseToTrayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GeneralNotifyIcon.Visible = true;
        }

        /// <summary>
        /// [EVENT]: Calls the HeaderContextMenuStrip when the OptionsButton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            HeaderContextMenuStrip.Show(OptionsButton, 0, 40);
        }

        /// <summary>
        /// [EVENT]: Allows to move the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderMenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        /// <summary>
        /// [EVENT]: Allows key navigation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) MainTabControl.SelectTab(0);
            else if (e.KeyCode == Keys.F2) MainTabControl.SelectTab(1);
            else if (e.KeyCode == Keys.F3) MainTabControl.SelectTab(2);
            else if (e.KeyCode == Keys.F4) MainTabControl.SelectTab(3);
            else if (e.KeyCode == Keys.F5) MainTabControl.SelectTab(4);
            else if (e.KeyCode == Keys.F6) MainTabControl.SelectTab(5);
            else if (e.KeyCode == Keys.F7) MainTabControl.SelectTab(6);
            else if (e.KeyCode == Keys.F8) RoundUpTSMI.Checked = !RoundUpTSMI.Checked;
        }
        #endregion

        #region Header Context Menu Strip Events
        /// <summary>
        /// [EVENT]: Opens AreaTabPage when AreaTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(0);
        }

        /// <summary>
        /// [EVENT]: Opens LengthTabPage when LengthTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LengthTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(1);
        }

        /// <summary>
        /// [EVENT]: Opens TemperatureTabPage when TemperatureTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemperatureTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(2);
        }

        /// <summary>
        /// [EVENT]: Opens TimeTabPage when TimeTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(3);
        }

        /// <summary>
        /// [EVENT]: Opens VolumeTabPage when VolumeTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(4);
        }

        /// <summary>
        /// [EVENT]: Opens WeightTabPage when WeightTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeightTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(5);
        }

        /// <summary>
        /// [EVENT]: Opens EncodingTabPage when EncodingTSMI is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncodingTSMI_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectTab(6);
        }

        /// <summary>
        /// [EVENT]: Enables or disables rounding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundUpTSMI_Click(object sender, EventArgs e)
        {
            RoundUpTSMI.Checked = !RoundUpTSMI.Checked;
        }

        /// <summary>
        /// [EVENT]: Displays the About message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutTSMI_Click(object sender, EventArgs e)
        {
            AboutForm aF = new();
            aF.ShowDialog();
        }
        #endregion

        #region Tray Events
        /// <summary>
        /// [EVENT]: Opens the main window when the tray icon is double clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneralNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            GeneralNotifyIcon.Visible = false;
        }

        /// <summary>
        /// [EVENT]: Opens the main windows when the Open tray menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayOpenTSMI_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            GeneralNotifyIcon.Visible = false;
        }

        /// <summary>
        /// [EVENT]: Closes the application when the Exit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitTSMI_Click(object sender, EventArgs e)
        {
            GeneralNotifyIcon.Visible = false;
            Environment.Exit(1);
        }
        #endregion

        #region Misc Control Events
        /// <summary>
        /// [EVENT]: Displays other conversion options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoreButton_Click(object sender, EventArgs e)
        {
            MaskedTextBox MtbFrom = MainTabControl.SelectedTab.Controls
                    .OfType<MaskedTextBox>()
                    .Where(mtb => mtb.Name.Contains("From"))
                    .FirstOrDefault();

            Double Input = Convert.ToDouble(MtbFrom.Text);

            MaskedTextBox MtbTo = MainTabControl.SelectedTab.Controls
                .OfType<MaskedTextBox>()
                .Where(mtb => mtb.Name.Contains("To"))
                .FirstOrDefault();

            ListBox From = MainTabControl.SelectedTab.Controls.OfType<ListBox>()
                .Where(LB => LB.Name.Contains(MainTabControl.SelectedTab.Name.Replace("TabPage", ""))
                          && LB.Name.Contains("From")).FirstOrDefault();

            ListBox To = MainTabControl.SelectedTab.Controls.OfType<ListBox>()
                .Where(LB => LB.Name.Contains(MainTabControl.SelectedTab.Name.Replace("TabPage", ""))
                          && LB.Name.Contains("To")).FirstOrDefault();

            String unitFromName = From.GetItemText(From.SelectedItem).Replace(" ", "").Split('(')[0];
            String unitToName = To.GetItemText(To.SelectedItem).Replace(" ", "").Split('(')[0];

            Unit unitFrom = units.AllUnits
                .Where(unit => unit.Name == unitFromName)
                .FirstOrDefault();

            String AllValues = Input + " " + unitFromName + ":\r\n";

            Double result = Double.NaN;
            if (unitFrom.Type == "Temperature")
            {
                if (unitFrom.Name == "Celsius")
                {
                    result = 1.0;
                    AllValues += "• to Celsius: " + result + "\r\n";
                    result = Input * (9.0 / 5.0) + 32.0;
                    AllValues += "• to Fahrenheit: " + result + "\r\n";
                    result = Input + 273.15;
                    AllValues += "• to Kelvin: " + result + "\r\n";
                }
                else if (unitFrom.Name == "Fahrenheit")
                {
                    result = (Input - 32.0) * (5.0 / 9.0);
                    AllValues += "• to Celsius: " + result + "\r\n";
                    result = 1.0;
                    AllValues += "• to Fahrenheit: " + result + "\r\n";
                    result = (Input - 32.0) * (5.0 / 9.0) + 273.15;
                    AllValues += "• to Kelvin: " + result + "\r\n";
                }
                else if (unitFrom.Name == "Kelvin")
                {
                    result = Input - 273.15;
                    AllValues += "• to Celsius: " + result + "\r\n";
                    result = (Input - 273.15) * (9.0 / 5.0) + 32;
                    AllValues += "• to Fahrenheit: " + result + "\r\n";
                    result = 1.0;
                    AllValues += "• to Kelvin: " + result + "\r\n";
                }
            }
            else
            {
                for (int i = 0; i < To.Items.Count; i++)
                {
                    result = Double.NaN;
                    if (unitFrom.Type != "Temperature")
                    {
                        result = unitFrom.ConvertTo[i].ConvertValue * Input;
                    }

                    if (RoundUpTSMI.Checked)
                    {
                        AllValues += "• to " + To.Items[i] + ": " + (result).ToString("N3") + "\r\n";
                    }
                    else
                    {
                        AllValues += "• to " + To.Items[i] + ": " + (result).ToString() + "\r\n";
                    }
                }
            }

            GeneralToolTip.Show(AllValues, (Button)sender);
        }

        /// <summary>
        /// [EVENT]: Encodes the text from the top TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncodeButton_Click(object sender, EventArgs e)
        {
            Encoding EncFrom = Encoding.GetEncoding(EncodingFromCB.GetItemText(EncodingFromCB.SelectedItem));
            Encoding EncTo = Encoding.GetEncoding(EncodingToCB.GetItemText(EncodingToCB.SelectedItem));
            byte[] FromBytes = EncFrom.GetBytes(EncodingFromTB.Text);

            byte[] ToBytes = Encoding.Convert(EncFrom, EncTo, FromBytes);

            EncodingToTB.Text = EncTo.GetString(ToBytes);
        }

        /// <summary>
        /// [EVENT]: Decodes the text from the bottom TextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecodeButton_Click(object sender, EventArgs e)
        {
            Encoding EncFrom = Encoding.GetEncoding(EncodingFromCB.GetItemText(EncodingFromCB.SelectedItem));
            Encoding EncTo = Encoding.GetEncoding(EncodingToCB.GetItemText(EncodingToCB.SelectedItem));
            byte[] ToBytes = EncFrom.GetBytes(EncodingFromTB.Text);

            byte[] FromBytes = Encoding.Convert(EncTo, EncFrom, ToBytes);

            EncodingFromTB.Text = EncFrom.GetString(FromBytes);
        }
        #endregion

        #region Universal Convertion Functions
        /// <summary>
        /// [EVENT]: Passes the values to the Converter when the text in MaskedTextBoxes changes
        /// or an index of ListBoxes changes.
        /// </summary>
        /// <param name="sender">Might be a ListBox or a MaskedTextBox.</param>
        /// <param name="e"></param>
        private void Universal_TextOrIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MaskedTextBox MtbFrom = MainTabControl.SelectedTab.Controls
                    .OfType<MaskedTextBox>()
                    .Where(mtb => mtb.Name.Contains("From"))
                    .FirstOrDefault();

                Double Input = Convert.ToDouble(MtbFrom.Text);

                MaskedTextBox MtbTo = MainTabControl.SelectedTab.Controls
                    .OfType<MaskedTextBox>()
                    .Where(mtb => mtb.Name.Contains("To"))
                    .FirstOrDefault();

                ListBox From = MainTabControl.SelectedTab.Controls.OfType<ListBox>()
                    .Where(LB => LB.Name.Contains(MainTabControl.SelectedTab.Name.Replace("TabPage", ""))
                              && LB.Name.Contains("From")).FirstOrDefault();

                ListBox To = MainTabControl.SelectedTab.Controls.OfType<ListBox>()
                    .Where(LB => LB.Name.Contains(MainTabControl.SelectedTab.Name.Replace("TabPage", ""))
                              && LB.Name.Contains("To")).FirstOrDefault();

                UniversalConverter(Input, From, To, MtbTo);
            }
            catch (Exception ex)
            {
                // Debug info:
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Converts the value based on the user input and the selected indexes of the ListBox.
        /// </summary>
        /// <param name="Input">(Double) User input value to convert.</param>
        /// <param name="From">(ListBox) ListBox (from) to select values.</param>
        /// <param name="To">(ListBox) ListBox (to) to display values.</param>
        /// <param name="MtbTo">(MaskedTextBox) MaskedTextBox (to) to display values.</param>
        private void UniversalConverter(Double Input, ListBox From, ListBox To, MaskedTextBox MtbTo)
        {
            try
            {
                String unitFromName = From.GetItemText(From.SelectedItem).Replace(" ", "").Split('(')[0];
                String unitToName = To.GetItemText(To.SelectedItem).Replace(" ", "").Split('(')[0];

                Unit unitFrom = units.AllUnits
                    .Where(unit => unit.Name == unitFromName)
                    .FirstOrDefault();

                Double convertValue = Convert.ToDouble(unitFrom.ConvertTo
                    .Where(value => value.Name == unitToName)
                    .FirstOrDefault().ConvertValue);

                Double result = Double.NaN;
                if (unitFrom.Type != "Temperature")
                { 
                    result = convertValue * Input;
                }
                else
                {
                    if (unitFrom.Name == "Celsius")
                    {
                        if (unitToName == "Fahrenheit")
                        {
                            result = Input * (9.0 / 5.0) + 32.0;
                        }
                        else if (unitToName == "Kelvin")
                        {
                            result = Input + 273.15;
                        }
                        else
                        {
                            result = 1.0;
                        }
                    }
                    else if (unitFrom.Name == "Fahrenheit")
                    {
                        if (unitToName == "Celsius")
                        {
                            result = (Input - 32.0) * (5.0 / 9.0);
                        }
                        else if (unitToName == "Kelvin")
                        {
                            result = (Input - 32.0) * (5.0 / 9.0) + 273.15;
                        }
                        else
                        {
                            result = 1.0;
                        }
                    }
                    else if (unitFrom.Name == "Kelvin")
                    {
                        if (unitToName == "Celsius")
                        {
                            result = Input - 273.15;
                        }
                        else if (unitToName == "Fahrenheit")
                        {
                            result = (Input - 273.15) * (9.0 / 5.0) + 32;
                        }
                        else
                        {
                            result = 1.0;
                        }
                    }
                }

                if (RoundUpTSMI.Checked)
                {
                    MtbTo.Text = (result).ToString("N3");
                }
                else
                {
                    MtbTo.Text = (result).ToString();
                }
            }
            catch (Exception ex)
            {
                // Debug info:
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        #endregion

        #region Widget Hook (WndProc & Events)
        // Had to override winapi call to make a global hook.
        protected override void WndProc(ref Message m)
        {
            // If hotkey detected...
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1)
            {
                // Press Tilde to show widget, press again to hide it.
                if (!WidgetContextMenuStrip.Visible)
                {
                    WidgetContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y + 40);
                    WidgetConvertion();
                }
                else
                {
                    WidgetContextMenuStrip.Hide();
                }
            }

            base.WndProc(ref m);
        }

        /// [EVENT]: Occurs when Tilde (widget hotkey) is pressed.
        private void WidgetTSMI_Click(object sender, EventArgs e)
        {
            // Values types (check units.xml).
            // TODO: add dynamic types.
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            ToolStripMenuItem from = (ToolStripMenuItem)WidgetContextMenuStrip
                .Items.OfType<ToolStripMenuItem>()
                .Where(from => from.Name.Contains("From")).FirstOrDefault();

            ToolStripMenuItem to = (ToolStripMenuItem)WidgetContextMenuStrip
                .Items.OfType<ToolStripMenuItem>()
                .Where(to => to.Name.Contains("To")).FirstOrDefault();

            if (tsmi.Name.Contains("From"))
            {
                ToolStripMenuItem category = (ToolStripMenuItem)tsmi.OwnerItem;
                String categoryName = category.Name.Replace("WidgetFrom", "");
                foreach (ToolStripMenuItem unitFrom in category.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    unitFrom.Checked = false;
                }
                foreach (ToolStripMenuItem otherCategory in to.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    otherCategory.Checked = false;
                    otherCategory.Enabled = otherCategory.Name.Contains(categoryName);
                }
                tsmi.Checked = true;
                category.Checked = true;
                from.Checked = true;
            }
            else if (tsmi.Name.Contains("To"))
            {
                ToolStripMenuItem category = (ToolStripMenuItem)tsmi.OwnerItem;
                foreach (ToolStripMenuItem unitFrom in category.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    unitFrom.Checked = false;
                }
                tsmi.Checked = true;
                category.Checked = true;
                to.Checked = true;
            }
        }

        /// <summary>
        /// Converts value in focused control according to widget settings.
        /// </summary>
        private void WidgetConvertion()
        {
            try
            {
                var element = AutomationElement.FocusedElement;
                if (element != null)
                {
                    if (element.TryGetCurrentPattern(TextPattern.Pattern, out object pattern))
                    {
                        var tp = (TextPattern)pattern;
                        var selection = tp.GetSelection().FirstOrDefault();
                        if (selection != null && WidgetFromTSMI.Checked && WidgetToTSMI.Checked)
                        {
                            Double input = Double.NaN;
                            try
                            {
                                String nameFrom = WidgetFromTSMI.DropDownItems
                                    .OfType<ToolStripMenuItem>()
                                    .Where(category => category.Checked).FirstOrDefault().DropDownItems
                                    .OfType<ToolStripMenuItem>()
                                    .Where(unit => unit.Checked).FirstOrDefault().Name
                                    .Replace("WidgetFrom", "").Replace("TSMI", "");

                                String nameTo = WidgetToTSMI.DropDownItems
                                    .OfType<ToolStripMenuItem>()
                                    .Where(category => category.Checked).FirstOrDefault().DropDownItems
                                    .OfType<ToolStripMenuItem>()
                                    .Where(unit => unit.Checked).FirstOrDefault().Name
                                    .Replace("WidgetTo", "").Replace("TSMI", "");

                                Unit unitFrom = units.AllUnits.Where(exact => exact.Name == nameFrom).FirstOrDefault();
                                Value valueTo = unitFrom.ConvertTo.Where(val => val.Name == nameTo).FirstOrDefault();
                                
                                input = Convert.ToDouble(selection.GetText(-1));

                                Double result = Double.NaN;

                                if (unitFrom.Type != "Temperature")
                                {
                                    result = input * valueTo.ConvertValue;
                                }
                                else
                                {
                                    result = Double.NaN;
                                    if (unitFrom.Name == "Celsius")
                                    {
                                        if (valueTo.Name == "Fahrenheit")
                                        {
                                            result = input * (9.0 / 5.0) + 32.0;
                                        }
                                        else if (valueTo.Name == "Kelvin")
                                        {
                                            result = input + 273.15;
                                        }
                                        else
                                        {
                                            result = 1.0;
                                        }
                                    }
                                    else if (unitFrom.Name == "Fahrenheit")
                                    {
                                        if (valueTo.Name == "Celsius")
                                        {
                                            result = (input - 32.0) * (5.0 / 9.0);
                                        }
                                        else if (valueTo.Name == "Kelvin")
                                        {
                                            result = (input - 32.0) * (5.0 / 9.0) + 273.15;
                                        }
                                        else
                                        {
                                            result = 1.0;
                                        }
                                    }
                                    else if (unitFrom.Name == "Kelvin")
                                    {
                                        if (valueTo.Name == "Celsius")
                                        {
                                            result = input - 273.15;
                                        }
                                        else if (valueTo.Name == "Fahrenheit")
                                        {
                                            result = (input - 273.15) * (9.0 / 5.0) + 32;
                                        }
                                        else
                                        {
                                            result = 1.0;
                                        }
                                    }
                                }

                                if (RoundUpTSMI.Checked)
                                {
                                    SendKeys.SendWait(result.ToString("N3"));
                                }
                                else
                                {
                                    SendKeys.SendWait(result.ToString());
                                }
                            }
                            catch (NullReferenceException ex)
                            {
                                Console.WriteLine("Oops, an error occurred (probably category is not selected yet.\r\n" + ex.Message + "\r\n" + ex.StackTrace + ex);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Debug info:
                Console.WriteLine("Couldn't convert string to double, returning.\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                // Debug info:
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        #endregion
    }
}