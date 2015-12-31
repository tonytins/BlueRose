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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Net;

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
        
        /// <summary>
        /// If the process is not available, throw an error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// TODO: figure best way to download latest build
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soon", appTitle);
        }

        private void LauncherNews_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/freesolauncherz.966/", UriKind.RelativeOrAbsolute));
        }

        private void FSONEws_Click(object sender, RoutedEventArgs e)
        {
            WebMain.Navigate(new Uri("http://forum.freeso.org/threads/road-to-live-release.801/", UriKind.RelativeOrAbsolute));
        }
    }
}
