// Copyright(C) 2016  Blue Rose Project

// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Ionic.Zip;
using System.Diagnostics;
using BlueRose.Distro;

namespace BlueRose
{
    public partial class BlueRoseGUI : Form
    {
        private string errorBtn = "ERROR";
        WebClient client = new WebClient();
        string netBuild = "#" + BlueRose.distNum();
        string buildFile = "fsobuild";

        public BlueRoseGUI()
        {
            try
            {
                InitializeComponent();

                this.MaximizeBox = false;
                this.MinimizeBox = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            BlueRose.StartFSO("FreeSO.exe");
        }

        private void devBtn_Click(object sender, EventArgs e)
        {
            BlueRose.StartFSO("FSO.IDE.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BlueRose.GC();

            try
            {
                localBuild.Text = BlueRose.readBuild(buildFile);
                onlineBuildLabel.Text = "#" + BlueRose.distNum();
            }
            catch
            {
                onlineBuildLabel.Text = "Offline";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                BlueRose.GC();
                
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(freeSODownloadCompleted);

                client.DownloadFileAsync(BlueRose.teamCityUri(), "teamcity.zip");

                localBuild.Text = "...";

                btnUpdate.Text = "Downloading";
                btnUpdate.Enabled = false;
                devBtn.Enabled = false;
                playBtn.Enabled = false;

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = errorBtn;
                btnUpdate.Enabled = false;
            }
            
            
        }

        void freeSODownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            btnUpdate.Text = "Installing";

            try
            {
                TeamCity.tcUnpack();

                btnUpdate.Enabled = true;
                devBtn.Enabled = true;
                playBtn.Enabled = true;

                localBuild.Text = BlueRose.readBuild(buildFile);

                btnUpdate.Text = "Update FreeSO";
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                btnUpdate.Text = errorBtn;
                localBuild.Text = "?";
                btnUpdate.Enabled = false;
            }

        }

        private void dwnPrgBar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateLauncher_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo newProccess = new ProcessStartInfo("SimplyUpdate.exe");
                newProccess.UseShellExecute = true;
                newProccess.Verb = "runas";
                Process.Start(newProccess);
                try
                {
                    Application.Exit();
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void onlineBuildLabel_Click(object sender, EventArgs e)
        {
            try
            {
                onlineBuildLabel.Text = "#" + BlueRose.distNum();
            }
            catch
            {
                onlineBuildLabel.Text = "FAILED";
            }
        }
    }
}
