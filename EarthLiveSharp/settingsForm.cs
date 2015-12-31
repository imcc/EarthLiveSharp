using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            Cfg.Load();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CbImageSource.SelectedIndex = Cfg.SourceSelect == "origin" ? 0 : 1;
            TxtUpdateMinutes.Value = Cfg.Interval;
            TxtMaxImageNumber.Value = Cfg.MaxNumber;
            CbAutoStart.Checked = Cfg.Autostart;
            LblVersion.Text = Cfg.Version;
            CbDisplayMode.SelectedIndex = Cfg.DisplayMode;
        }

        //private void button_select_folder_Click(object sender, EventArgs e)
        //{
        //    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        //    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
        //    folderBrowserDialog1.SelectedPath = Cfg.ImageFolder;
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        Cfg.ImageFolder = folderBrowserDialog1.SelectedPath;
        //    }
        //    folderBrowserDialog1.Dispose();
        //}

        private void LbtnCheckUpdate_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bitdust/EarthLiveSharp/releases");
        }

        private void LbtnReadMore_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bitdust/EarthLiveSharp/issues/2");
        }
        

        private void BtnApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Save()
        {
            Cfg.SourceSelect = CbImageSource.Text;
            Cfg.Interval = (int)(TxtUpdateMinutes.Value);
            Cfg.MaxNumber = (int)(TxtMaxImageNumber.Value);
            Cfg.Autostart = CbAutoStart.Checked;
            Cfg.DisplayMode = CbDisplayMode.SelectedIndex;
            Cfg.Save();

            Autostart.Set(Cfg.Autostart);
        }

       
    }
}
