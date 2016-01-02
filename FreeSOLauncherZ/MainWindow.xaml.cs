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

namespace FreeSOLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string appTitle = "FreeSO";

        public MainWindow()
        {
            InitializeComponent();
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/road-to-live-release.801/", UriKind.RelativeOrAbsolute));

        }
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("FreeSO.exe");
                Thread.Sleep(5000); // Wait 5 seconds before closing
                Application.Current.Shutdown();
            }
            catch
            {
                MessageBox.Show("Place the launcher into the same directory as FreeSO.", appTitle + " not found");
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon", appTitle);
        }

        private void LauncherNews_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/freesolauncherz.966/", UriKind.RelativeOrAbsolute));
        }

        
        private void FSONews_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/road-to-live-release.801/", UriKind.RelativeOrAbsolute));
        }
    }
}
