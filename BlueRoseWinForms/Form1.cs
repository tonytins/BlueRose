using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;

namespace BlueRoseWinForms
{
    public partial class Form1 : Form
    {

        public string freeSONews = "http://forum.freeso.org/threads/road-to-live-release.801/";

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
#if (!DEBUG)
            NotImplementedException notImp = new NotImplementedException();

            MessageBox.Show(notImp.Message);
#elif DEBUG
            WebClient client = new WebClient();

            try
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(clDownProgChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(clDownFileCompleted);

                client.DownloadFileAsync(BlueRose.webURL("http://servo.freeso.org/repository/download/ProjectDollhouse_TsoClient/262:id/dist-196.zip"), Environment.CurrentDirectory);

                btnUpdate.Text = "Downloading";
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                btnUpdate.Text = "ERROR";
                btnUpdate.Enabled = false;
            }
#endif

        }

        void clDownProgChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            dwnPrgBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void clDownFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;
        }

        private void dwnPrgBar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
