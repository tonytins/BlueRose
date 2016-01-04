//  Copyright(C) 2016  Zack Casey

//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.

//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License along
//  with this program; if not, write to the Free Software Foundation, Inc.,
//  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

using System;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using SysIO = System.IO;
using System.Text;

namespace BlueRoseLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string appTitle = "Blue Rose";
        public string freeSONews = "http://forum.freeso.org/threads/road-to-live-release.801/";

        public MainWindow()
        {
            InitializeComponent();
            WebMain.Navigate(new Uri(freeSONews, UriKind.RelativeOrAbsolute));

        }
        
        private void StartIDE_Click(object sender, RoutedEventArgs e)
        {
            StartFSO("FSO.IDE.exe");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            StartFSO("FreeSO.exe");
        }

        /// <summary>
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        private void StartFSO(string fso)
        {
            string notFoundTitle = "Not found";
            string openAL3264 = @"C:\Program Files (x86)\OpenAL";
            string openAL = @"C:\Program Files\OpenAL";

            bool openALDir = SysIO.Directory.Exists(openAL3264) || SysIO.Directory.Exists(openAL);

            try
            {
                if (!openALDir)
                {
                    MessageBox.Show("OpenAL not found!\nGo to openal.org/downloads and get the Windows installer...", notFoundTitle);
                }
                else
                {
                    Process fsoProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo(fso)
                    };
                    fsoProcess.Start();
                }

            }
            catch
            {
                MessageBox.Show("Could not detect FreeSO in this folder.", notFoundTitle);
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon", appTitle);
        }

        private void LauncherNews_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/blue-rose-launcher.966/", UriKind.RelativeOrAbsolute));
        }

        
        private void FSONews_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri(freeSONews, UriKind.RelativeOrAbsolute));
        }

    }
}
