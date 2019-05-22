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
            
            chk_connect.Checked = Properties.Settings.Default.EnableConnectNotify;
            chk_disconnect.Checked = Properties.Settings.Default.EnableDisconnectNotify;
            num_balloontiptime.Value = Properties.Settings.Default.TipShowTime;
            txt_clickeventpath.Text = Properties.Settings.Default.ClickPath;
            txt_clickeventpatharg.Text = Properties.Settings.Default.ClickPathArg;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            serialNotifyIcon = new NotifyIcon();
            serialNotifyIcon.Visible = true;
            serialNotifyIcon.Icon = Properties.Resources.serialnotify;
            serialNotifyIcon.ContextMenuStrip = cms_notify;

            FormClosing += (_sender, _e) =>
            {
                Properties.Settings.Default.EnableConnectNotify = chk_connect.Checked;
                Properties.Settings.Default.EnableDisconnectNotify = chk_disconnect.Checked;
                Properties.Settings.Default.TipShowTime = num_balloontiptime.Value;
                Properties.Settings.Default.ClickPath = txt_clickeventpath.Text;
                Properties.Settings.Default.ClickPathArg = txt_clickeventpatharg.Text;

                Hide();
                ShowInTaskbar = false;
                _e.Cancel = true;
            };

            Application.ApplicationExit += (_sender, _e) =>
            {
                serialNotifyIcon.Dispose();
                Properties.Settings.Default.Save();
            };

            serialNotifyIcon.DoubleClick += (_sender, _e) =>
            {
                ShowInTaskbar = true;
                Visible = true;
                Activate();
            };

            serialNotifyIcon.BalloonTipClicked += (_sender, _e) =>
            {
                var arg = txt_clickeventpatharg.Text;
                var portinfo = serialNotifyIcon.Tag as PortInfo;
                if (portinfo != null)
                {
                    arg = arg.Replace("{PortNum}", $"{portinfo.PortNum}");
                }

                var app = new ProcessStartInfo(
                    txt_clickeventpath.Text,
                    arg);
                var p = Process.Start(app);
                p.WaitForInputIdle();
                NativeMethods.SetForegroundCenterWindow(p.MainWindowHandle);
            };
        }

        private bool IsPort(IntPtr lparam)
            => NativeMethods.Get_DEV_BROADCAST_HDR(lparam).dbch_devicetype == NativeMethods.DBT_DEVTYP_PORT;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_DEVICECHANGE)
            {
                PortInfo pInfo;
                switch (m.WParam.ToInt32())
                {
                    case NativeMethods.DBT_DEVICEARRIVAL when (chk_connect.Checked && IsPort(m.LParam)):
                        pInfo = new PortInfo(NativeMethods.GetPortName(m.LParam));

                        serialNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                        serialNotifyIcon.BalloonTipTitle = "Serial port device connected";
                        serialNotifyIcon.BalloonTipText = pInfo.PortName;
                        serialNotifyIcon.ShowBalloonTip((int)num_balloontiptime.Value);
                        serialNotifyIcon.Tag = pInfo;
                        break;

                    case NativeMethods.DBT_DEVICEREMOVECOMPLETE when (chk_disconnect.Checked && IsPort(m.LParam)):
                        pInfo = new PortInfo(NativeMethods.GetPortName(m.LParam));

                        serialNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                        serialNotifyIcon.BalloonTipTitle = "Serial port device disconnected";
                        serialNotifyIcon.BalloonTipText = pInfo.PortName;
                        serialNotifyIcon.ShowBalloonTip((int)num_balloontiptime.Value);
                        serialNotifyIcon.Tag = pInfo;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txt_clickeventpath.Text);
        }
    }
}
