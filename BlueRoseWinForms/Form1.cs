using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Ionic.Zip;
using System.Text.RegularExpressions;
using System.Threading;

namespace BlueRoseWinForms
{
    public partial class Form1 : Form
    {

        public string freeSONews = "http://forum.freeso.org/threads/road-to-live-release.801/";
        private string errorBtn = "ERROR";
        WebClient client = new WebClient();
        Uri dlAddress = new Uri(@"http://servo.freeso.org/guestAuth/downloadArtifacts.html?buildTypeId=ProjectDollhouse_TsoClient&buildId=lastSuccessful");

        public Form1()
        {
            try
            {
                InitializeComponent();

            } catch (Exception ex)
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

        private void brNewsBtn_Click(object sender, EventArgs e)
        {
            fsoWeb.Url = BlueRose.webPage("http://forum.freeso.org/threads/blue-rose-launcher.966/");
        }

        private void freeSONewsBtn_Click(object sender, EventArgs e)
        {
            fsoWeb.Url = BlueRose.webPage(freeSONews);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
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
                BlueRose.garbageCollection();

                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(clientDownProgChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(clientDownFileCompleted);

                client.DownloadFileAsync(dlAddress, BlueRose.dlFile());

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

        void clientDownProgChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            dwnPrgBar.Value = e.ProgressPercentage;
        }

        void clientDownFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            // http://www.codeproject.com/Articles/11556/Converting-Wildcards-to-Regexes
            // ---------------------------------------------------

            Wildcard wildZip = new Wildcard("*.zip", RegexOptions.IgnoreCase);
            Wildcard wildCard = new Wildcard("*.*", RegexOptions.IgnoreCase);

            // Get a list of files in the My Documents folder
            string[] files = System.IO.Directory.GetFiles(Environment.CurrentDirectory);

            foreach (string file in files)
            {
                if (wildZip.IsMatch(file))
                {
                    try
                    {
                        using (ZipFile zip = ZipFile.Read(file))
                        {
                            foreach (ZipEntry ex in zip)
                            {
                                btnUpdate.Text = "Unpacking";
                                ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                            }

                            devBtn.Enabled = true;
                            playBtn.Enabled = true;
                            btnUpdate.Text = "Update";
                            btnUpdate.Enabled = true;
                            dwnPrgBar.Value = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            // ---------------------------------------------------

            devBtn.Enabled = true;
            playBtn.Enabled = true;
            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;

            BlueRose.garbageCollection();

        }

        private void dwnPrgBar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
