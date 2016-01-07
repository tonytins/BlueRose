using System;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using SysIO = System.IO;
using System.Text;
using System.Windows.Forms;

namespace BlueRoseShared
{
    class BlueRose
    {

        public string blueRoseNews = "http://forum.freeso.org/threads/blue-rose-launcher.966/";

        /// <summary>
        /// If FreeSO isn't found, alert the user.
        /// If OpenAL isn't installed, show downloads address.
        /// </summary>
        /// <param name="fso"></param>
        public static void StartFSO(string fso)
        {
            string notFoundTitle = "Not found";
            string openAL3264 = @"C:\Program Files (x86)\OpenAL";
            string openAL = @"C:\Program Files\OpenAL";

            bool openALDir = SysIO.Directory.Exists(openAL3264) || SysIO.Directory.Exists(openAL);

            try
            {
                if (!openALDir)
                {
                    MessageBox.Show("OpenAL not found!" + Environment.NewLine + "Go to openal.org/downloads and get the Windows installer...", notFoundTitle);
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
    }
}
