using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using BlueRoseShared;

namespace BlueRoseWinForms
{
    public partial class Form1 : Form
    {

        public string freeSONews = "http://forum.freeso.org/threads/road-to-live-release.801/";

        public Form1()
        {
            InitializeComponent();
            WebPage(freeSONews);
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
            WebPage("http://forum.freeso.org/threads/blue-rose-launcher.966/");
        }

        private void freeSONewsBtn_Click(object sender, EventArgs e)
        {
            WebPage(freeSONews);
        }

        private void WebPage(string url)
        {
            try
            {
                fsoWeb.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                fsoWeb.Navigate(new Uri("http://forum.freeso.org/", UriKind.RelativeOrAbsolute));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            try
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(clDownProgChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(clDownFileCompleted);

                client.DownloadFileAsync(new Uri("http://servo.freeso.org/repository/download/ProjectDollhouse_TsoClient/262:id/dist-196.zip"), Environment.CurrentDirectory);

                btnUpdate.Text = "Downloading";
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                btnUpdate.Text = "ERROR";
                btnUpdate.Enabled = false;
            }

            
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
