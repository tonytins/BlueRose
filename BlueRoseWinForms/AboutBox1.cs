using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BlueRoseWinForms
{
    partial class AboutBox1 : Form
    {
        string blueRoseFile = "bluerose.zip";

        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", "Blue Rose Launcher");
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBRUpdate_Click(object sender, EventArgs e)
        {

            WebClient client = new WebClient();

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(brDownloadCompleted);
#if !(DEBUG)
            client.DownloadFileAsync(BlueRose.webURL(@"https://dl.dropboxusercontent.com/u/42345729/BlueRoseStable.zip"),
                blueRoseFile);
#elif DEBUG
            client.DownloadFileAsync(BlueRose.webURL(@"https://dl.dropboxusercontent.com/u/42345729/BlueRoseBeta.zip"),
                blueRoseFile);
#endif
        }

        void brDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            btnBRUpdate.Text = "Unpacking";

            string firstUnpack = blueRoseFile;
            string secondUnpack = "BlueRoseLauncher.zip";

            using (ZipFile buildUnpack = ZipFile.Read(firstUnpack))
            {
                foreach (ZipEntry ex in buildUnpack)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            using (ZipFile instUnpack = new ZipFile(secondUnpack))
            {
                foreach(ZipEntry ex in instUnpack)
                {
                    ex.Extract(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }

#if !(DEBUG)
            Process.Start("BlueRoseStable.exe");
#elif DEBUG
            Process.Start("BlueRoseBeta.exe");
#endif
            Environment.Exit(0);
        }
    }
}
