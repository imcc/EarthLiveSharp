using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using EarthLiveSharp.Properties;

namespace EarthLiveSharp
{
    // It's a terrible mistake to mix the UI and business logic together.
    public partial class MainForm : Form
    {
        private bool _serviceRunning;
        private MenuItem _startService, _stopService, _settingsMenu, _quitService;
        private readonly ContextMenu _trayMenu = new ContextMenu();

        public MainForm()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            BtnStart.Text = Resources.MainForm_Start_Service;
            BtnStop.Text = Resources.MainForm_Stop_Service;
            BtnSetting.Text = Resources.MainForm_Setting;
            LblStatus.Text = Resources.MainForm_Not_Running;

            CreateContextMenu();
            MyNotifyIcon.ContextMenu = _trayMenu;
        }

        private void CreateContextMenu()
        {
            _startService = new MenuItem(Resources.MainForm_Start_Service);
            _stopService = new MenuItem(Resources.MainForm_Stop_Service);
            _settingsMenu = new MenuItem(Resources.MainForm_Setting);
            _quitService = new MenuItem(Resources.MainForm_Quit);

            _trayMenu.MenuItems.Add(_startService);
            _trayMenu.MenuItems.Add(_stopService);
            _trayMenu.MenuItems.Add(_settingsMenu);
            _trayMenu.MenuItems.Add(_quitService);

            _startService.Click += StartService_Click;
            _stopService.Click += StopService_Click;
            _settingsMenu.Click += SettingsMenu_Click;
            _quitService.Click += QuitService_Click;

            ContextMenuSetter();
        }

        private void StartService_Click(object sender, EventArgs e)
        {
            StartLogic();
        }
        private void StopService_Click(object sender, EventArgs e)
        {
            StopLogic();
        }
        private void SettingsMenu_Click(object sender, EventArgs e)
        {
            OpenSettingForm();
        }
        private void QuitService_Click(object sender, EventArgs e)
        {
            var confirmIfQuitting = MessageBox.Show(
                Resources.MainForm_Are_you_sure_you_want_to_quit,
                Resources.MainForm_Stop_Service, MessageBoxButtons.YesNo);
            if (confirmIfQuitting == DialogResult.Yes)
            {
                StopLogic();
                Application.Exit();
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            OpenSettingForm();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartLogic();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopLogic();
        }

        private static void OpenSettingForm()
        {
            var frmSetting = new SettingsForm();
            frmSetting.ShowDialog();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Scraper.ImageHost = Cfg.GetRandomCdnUrl();
            Scraper.UpdateImage();
            SetWallpaper();
        }

        private void MyNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BtnStop.Enabled = false;
            if (Cfg.Autostart)
            {
                BtnStart.PerformClick();
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                Hide();
                if (!Cfg.Autostart)
                {
                    MyNotifyIcon.ShowBalloonTip(1000, "", Resources.MainForm_Service_is_running, ToolTipIcon.Info);
                }
            }
        }

        private void LlImageFrom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var info = new System.Diagnostics.ProcessStartInfo("http://himawari8.nict.go.jp/");
            //System.Diagnostics.Process.Start(info);
            System.Diagnostics.Process.Start("http://himawari8.nict.go.jp/");
        }

        //All logic pertaining to stopping the service
        private void StopLogic()
        {
            if (_serviceRunning)
            {
                //notifyIcon1.ShowBalloonTip(200, "", "EarthLive# Service Stopped", ToolTipIcon.Warning);
                MyTimer.Stop();
                BtnStart.Enabled = true;
                BtnStop.Enabled = false;
                BtnSetting.Enabled = true;
                LblStatus.Text = Resources.MainForm_Not_Running;
                LblStatus.ForeColor = Color.DarkRed;
                _serviceRunning = false;
            }
            else if (!_serviceRunning) { MessageBox.Show(Resources.MainForm_Service_is_not_currently_running); }
            ContextMenuSetter();
        }

        //All logic pertaining to starting the service
        private void StartLogic()
        {
            if (!_serviceRunning)
            {
                //notifyIcon1.ShowBalloonTip(200, "", "EarthLive# Service Started", ToolTipIcon.Warning);
                Cfg.Load();
                var testUrl = Cfg.GetImageHostUrl();
                Scraper.ImageHost = testUrl;
                
                Scraper.MaxNumber = Cfg.MaxNumber;
                Scraper.UpdateImage();

                BtnStart.Enabled = false;
                BtnStop.Enabled = true;
                BtnSetting.Enabled = false;

                MyTimer.Interval = Cfg.Interval * 1000 * 60;
                MyTimer.Start();

                SetWallpaper();

                _serviceRunning = true;
                LblStatus.Text = Resources.MainForm_Running;
                LblStatus.ForeColor = Color.DarkGreen;
            }
            else if (_serviceRunning) { MessageBox.Show(Resources.MainForm_Service_already_running); }
            ContextMenuSetter();
        }

        private static void SetWallpaper()
        {
            if (Scraper.SavedPath.Length > 0)
            {
                switch (Cfg.DisplayMode)
                {
                    case 0:
                        Wallpaper.SetDefaultStyle();
                        Wallpaper.Set(Scraper.SavedPath);
                        break;
                    case 1:
                        Wallpaper.Set(Scraper.SavedPath);
                        break;
                    case 2:
                        //
                        break;
                }
            }
        }

        //checks if service running and changes context menu based on result.
        private void ContextMenuSetter()
        {
            if (_serviceRunning)
            {
                _startService.Enabled = false;
                _stopService.Enabled = true;
            }
            else
            {
                _stopService.Enabled = false;
                _startService.Enabled = true;
            }
        }

    }
}
