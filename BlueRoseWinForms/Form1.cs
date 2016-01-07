using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            catch
            {
                MessageBox.Show("Page Not Found.");
                fsoWeb.Navigate(new Uri("http://forum.freeso.org/", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
