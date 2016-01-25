using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Ionic.Zip;

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
            BlueRose.GC();
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

                client.DownloadFileAsync(BlueRose.dlAddress("servo.freeso.org", "ProjectDollhouse_TsoClient"),
                    "freeso.zip");

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
            btnUpdate.Text = "Unpacking";

            string firstUnpack = "freeso.zip";

            using (ZipFile buildUnpack = ZipFile.Read(firstUnpack))
            {
                foreach (ZipEntry ex in buildUnpack)
                {

                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }


            // http://www.codeproject.com/Articles/11556/Converting-Wildcards-to-Regexes
            // ---------------------------------------------------

            BlueRose.wildZip();

            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;
            devBtn.Enabled = true;
            playBtn.Enabled = true;

            // ---------------------------------------------------

        }

        private void dwnPrgBar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }
    }
}
