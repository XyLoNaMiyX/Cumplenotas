
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace UpdateChecker
{
    public partial class UpdateChecker : Form
    {
        class r : Cumplenotas.Properties.Resources { }

        #region Variables and setup

        public UpdateChecker(string filepath, string shortname)
        {
            InitializeComponent();

            CurrentVersion = GetVersionFromFile(filepath);
            FileShortname = shortname;
            Architecture = GetArchitecture(filepath);
        }

        int GetVersionFromFile(string file) {
            var versionInfo = FileVersionInfo.GetVersionInfo(file);
            string version = versionInfo.ProductVersion;

            return Int32.Parse(version.Replace(".", ""));
        }

        string GetArchitecture(string file) {
            var assembly = AssemblyName.GetAssemblyName(file);
            string sassembly = assembly.ProcessorArchitecture.ToString().ToLower();

            if (sassembly.Contains("64"))
                return "64";

            else if (sassembly.Contains("86"))
                return "86";

            else
                return "";

        }

        int CurrentVersion;
        int NewVersion = 0;
        string FileShortname;
        string Filename = "Unknown";
        string Architecture;

        #endregion

        #region Check button

        private void checkB_Click(object sender, EventArgs e)
        {
            if (checkB.Text == r.UC1)
                DownloadUpdate();
            else if (checkB.Text == r.UC2)
                this.Close();
            else
                CheckUpdates();
        }

        #endregion

        #region Check updates

        void CheckUpdates()
        {
            checkingPB.MarqueeAnimationSpeed = 10;
            infoL.Text = r.UC3;

            Uri uri = new Uri ("http://lonamiwebs.github.io/_DOWNLOADS/checkupdates.php?q=" + FileShortname);
            string lwa = "permission=lwAccess";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);

                try { wc.UploadStringAsync(uri, lwa); }
                catch { }
            }
        }


        void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null) {
                infoL.Text = r.UC4;
                return;
            }

            checkingPB.MarqueeAnimationSpeed = 0;
            checkingPB.Style = ProgressBarStyle.Continuous;

            NewVersion = Int32.Parse(e.Result);
            if (NewVersion > CurrentVersion) {
                infoL.Text = r.UC5;
                checkB.Text = r.UC1;
            } else {
                infoL.Text = r.UC6;
                checkB.Text = r.UC2;
            }
        }

        #endregion

        #region Update

        void DownloadUpdate() {
            SetTextUpdating(0);
            checkB.Text = r.UC7;

            checkB.Enabled = false;

            string fileurl = new WebClient().DownloadString(
                "http://lonamiwebs.github.io/_DOWNLOADS/getfileurl.php?q=" + FileShortname + Architecture);

            Uri uri = new Uri(fileurl);
            Filename = fileurl.Split('/')[fileurl.Split('/').Length - 1].Replace("%20", "");

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                wc.DownloadFileAsync(uri, Filename);
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double percentage = (double)e.BytesReceived / (double)e.TotalBytesToReceive * 100d;
            SetTextUpdating(percentage);
            checkingPB.Value = e.ProgressPercentage;
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string path = Path.GetFullPath(Filename);
            if (MessageBox.Show(r.UC8 + "\r\n" + path + "\r\n\r\n" + r.UC9, r.UC10,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                Process.Start(new ProcessStartInfo() { FileName = "explorer.exe",
                    Arguments = "/e, /select, \"" + path + "\""});

            this.Close();
        }

        void SetTextUpdating(double percentage)
        {
            string cv = String.Join(".", CurrentVersion.ToString("D" + 4).ToCharArray());
            string nv = String.Join(".", NewVersion.ToString("D" + 4).ToCharArray());
            infoL.Text = r.UC11 + " " + cv + "\r\n" +
                r.UC12 + nv + "... " + percentage.ToString("F") + "%";
        }

        #endregion
    }
}
