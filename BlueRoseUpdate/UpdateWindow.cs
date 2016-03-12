using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ZACKUpdater;
using System.Threading;

namespace SimplyUpdate
{
    public partial class UpdateWindow : Form
    {
        Uri address = new Uri(@"https://dl.dropboxusercontent.com/u/42345729/bluerose.zip");
        static string program = "BlueRoseLauncher.exe";
        public static string[] updateParmas { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            useLessProgressBar.Style = ProgressBarStyle.Marquee;
            useLessProgressBar.MarqueeAnimationSpeed = 50;

            try
            {
                UpdateInfo.SelfUpdate(program, address, "update.zip");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                try
                {
                    Process launcherProcess = new Process();

                    launcherProcess.StartInfo.FileName = program;
                    launcherProcess.StartInfo.UseShellExecute = true;
                    launcherProcess.Start();
                    Application.Exit();
                }
                catch
                {
                    try
                    {
                        Application.Exit();
                    }
                    catch
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
        
    }
}
