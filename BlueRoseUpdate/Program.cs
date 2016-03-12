using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplyUpdate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            UpdateWindow.updateParmas = args;
            /*
            Ping pinger = new Ping();
            bool pingable = false;
            PingReply reply = pinger.Send(@"https://www.google.com");
            if (pingable = reply.Status == IPStatus.Success)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UpdateWindow());
            }
            else if (pingable = reply.Status == IPStatus.DestinationNetworkUnreachable)
            {
                ProcessStartInfo launcherProcess = new ProcessStartInfo();
                launcherProcess.FileName = "BlueRoseLauncher.exe";
                launcherProcess.UseShellExecute = true;
                Process.Start(launcherProcess);
                Environment.Exit(0);
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UpdateWindow());

        }

        public static bool isOnline()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(@"https://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }

        public static string ConvertStringArrayToStringJoin(string[] array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            string result = string.Join(".", array);
            return result;
        }
    }
}
