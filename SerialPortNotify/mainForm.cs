using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortNotify
{
    public partial class mainForm : Form
    {
        private NotifyIcon serialNotifyIcon;

        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var mutex = new Mutex(false, "SerialPortNotify_Mutex", out bool createNew);
            if (!createNew)
            {
                Application.Exit();
            }

           Icon = Properties.Resources.serialnotify;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            serialNotifyIcon = new NotifyIcon();
            serialNotifyIcon.Visible = true;
            serialNotifyIcon.Icon = Properties.Resources.serialnotify;
            serialNotifyIcon.ContextMenuStrip = cms_notify;

            Deactivate += (_sender, _e) => Hide();
            FormClosing += (_sender, _e) =>
            {
                Hide();
                _e.Cancel = true;
            };

            Application.ApplicationExit += (_sender, _e) 
                => serialNotifyIcon.Dispose();

            serialNotifyIcon.DoubleClick += (_sender, _e) =>
            {
                Visible = true;
                Activate();
            };

            serialNotifyIcon.BalloonTipClicked += (_sender, _e) =>
            {

            };
        }

        private bool IsPort(IntPtr lparam)
            => NativeMethods.Get_DEV_BROADCAST_HDR(lparam).dbch_devicetype == NativeMethods.DBT_DEVTYP_PORT;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_DEVICECHANGE)
            {
                string portName = string.Empty;
                switch (m.WParam.ToInt32())
                {
                    case NativeMethods.DBT_DEVICEARRIVAL when (chk_connect.Checked && IsPort(m.LParam)):
                        portName = NativeMethods.GetPortName(m.LParam);
                        serialNotifyIcon.ShowBalloonTip(
                            (int)num_balloontiptime.Value, "Serial port device connected", portName, ToolTipIcon.Info);
                        break;

                    case NativeMethods.DBT_DEVICEREMOVECOMPLETE when (chk_disconnect.Checked && IsPort(m.LParam)):
                        portName = NativeMethods.GetPortName(m.LParam);
                        serialNotifyIcon.ShowBalloonTip(
                            (int)num_balloontiptime.Value, "Serial port device disconnected", portName, ToolTipIcon.Warning);
                        break;

                    default:
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void Tsmi_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Lnk_regedit_Click(object sender, EventArgs e)
        {
            RegistryMan.OpenRegistryEditor(RegistryMan.REG_KEYS.STARTUP);
        }

        private void Btn_registration_Click(object sender, EventArgs e)
        {
            RegistryMan.SetValue(RegistryMan.REG_KEYS.STARTUP, "SerialPortNotify", Application.ExecutablePath);
        }

        private void Btn_deregistration_Click(object sender, EventArgs e)
        {
            RegistryMan.DeleteValue(RegistryMan.REG_KEYS.STARTUP, "SerialPortNotify");
        }
    }
}
