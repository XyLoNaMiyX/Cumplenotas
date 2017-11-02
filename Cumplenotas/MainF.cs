using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

using Cumplenotas.Properties;

namespace Cumplenotas
{
    public partial class MainF : Form
    {

        #region Classes

        public class Options
        {
        	public int LittleShow, NotificationTimeout;

        	public bool ShowAll, StartWidthWindows;

            public Options()
            {
                LittleShow = 5;
                ShowAll = false;
                NotificationTimeout = 4000;
                StartWidthWindows = true;
            }
        }

        public class Birthday
        {
        	public DateTime Date;
        	public string Person, Extra;

            public Birthday(DateTime date, string person, string extra)
            {
                Date = date;
                Person = person;
                Extra = extra;
            }
        }

        #endregion

        #region Variables

        public static List<Birthday> bds = new List<Birthday>();

        public static Options options = new Options();

        public static string cunp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            @"\LonamiWebs\Cumplenotas";
        string pw = "lW S#ftW4r€";

        bool minimize, doneloading;

        #endregion

        #region Set up

        public MainF(string[] args)
        {
            InitializeComponent();

            if (args.Length > 0)
                if (args[0] == "-minimized")
                    minimize = true;
        }

        void MainF_Load(object sender, EventArgs e)
        {
            LoadOptions();

            if (minimize)
                WindowState = FormWindowState.Minimized;

            CheckState();
        }

        #endregion

        #region Load and save options

        void LoadOptions() {
            try {
                string json = File.ReadAllLines(cunp + @"\opciones.cun")[0];
                json = Crypter.Decrypt(json, pw);
                options = JsonConvert.DeserializeObject<Options>(json);

                showAllCB.Checked = options.ShowAll;
                StartWithWindows(options.StartWidthWindows);

                if (File.Exists(cunp + @"\cumples.🎉🎁"))
                    LoadList();

                doneloading = true;
            }
            catch { SaveOptions(); LoadOptions(); }
        }

        public void SaveOptions() {
            try
            {
                Directory.CreateDirectory(cunp);
                string json = JsonConvert.SerializeObject(options);
                json = Crypter.Encrypt(json, pw);
                File.WriteAllText(cunp + @"\opciones.cun", json);
            }
            catch { }
        }

        #endregion

        #region Birthdays

        void IsTodayBirtdhay() {
            var tbds = new List<Birthday>();
            foreach (Birthday bd in bds)
                if (DateTime.Now.Month == bd.Date.Month && DateTime.Now.Day == bd.Date.Day)
                    tbds.Add(bd);

           ShowBirtdhay(tbds);
        }

        void ShowBirtdhay(List<Birthday> tbds) {
            if (tbds.Count == 1)
            {
                string greeting = Resources.greeting;
                if (tbds[0].Person.Substring(tbds[0].Person.Length - 1) == "a")
                    greeting = Resources.greetinga;

                notifyIcon.BalloonTipTitle = Resources.onebd;
                notifyIcon.BalloonTipText = Resources.onebdi1 + " " + tbds[0].Person + 
                    Resources.onebdi2 + " " + greeting + "!";
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(options.NotificationTimeout);
            }
            else if (tbds.Count > 1)
            {
                notifyIcon.BalloonTipTitle = Resources.morebd + " " + tbds.Count + " " + Resources.morebd2;
                string text = Resources.morebdi1 + " ";
                for (int i = 0; i < tbds.Count; i++)
                {
                    if (i == tbds.Count - 1)
                        text += " " + Resources.and + " " + tbds[i].Person;
                    else if (i == 0)
                        text += tbds[i].Person;
                    else
                        text += ", " + tbds[i].Person;
                }

                text += ".\r\n\r\n" + Resources.morebdi2;
                notifyIcon.BalloonTipText = text;

                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(options.NotificationTimeout + options.NotificationTimeout / 2);
            }
            else
                if (minimize)
                    Close();
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
        }

        #endregion

        #region List control

        void showAllCB_CheckedChanged(object sender, EventArgs e)
        {
            if (doneloading)
            {
                RefreshList();
                options.ShowAll = showAllCB.Checked;
                SaveOptions();
            }
        }

        public void RefreshList()
        {
            if (showAllCB.Checked)
                RefreshList(0);
            else
                RefreshList(options.LittleShow);
        }

        void RefreshList(int toshow) {
            List<Birthday> birthdays = SortBirthdays(bds);

            bdLB.Items.Clear();
            if (toshow == 0)
                foreach (Birthday bd in birthdays)
                    bdLB.Items.Add(bd.Date.ToString("dd MMMM") + ", " + bd.Person);
            else
                for (int i = 0; i < options.LittleShow; i++)
                    if (i < bds.Count)
                        bdLB.Items.Add(birthdays[i].Date.ToString("dd MMMM") + ", " + birthdays[i].Person);
        }

        List<Birthday> SortBirthdays(List<Birthday> birthdays)
        {
            //http://www.dotnetperls.com/sort-datetime

            //Sorted normally.
            birthdays.Sort((a, b) => a.Date.Month.CompareTo(b.Date.Month));

            var sortedBds = new List<Birthday>();

            //Sorting first the next months, next the last months
            foreach (Birthday bd in birthdays)
                if (bd.Date.Month >= DateTime.Today.Month)
                    sortedBds.Add(bd);

            foreach (Birthday bd in birthdays)
                if (bd.Date.Month < DateTime.Today.Month)
                    sortedBds.Add(bd);

            return sortedBds;
        }

        void LoadList() {
            try
            {
                string json = File.ReadAllLines(cunp + @"\cumples.🎉🎁")[0];
                json = Crypter.Decrypt(json, pw);
                bds = JsonConvert.DeserializeObject<List<Birthday>>(json);

                RefreshList();

                IsTodayBirtdhay();
            }
            catch {
                DialogResult r = MessageBox.Show(Resources.errloading, Resources.errloadingt,
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);

                if (r == DialogResult.Retry)
                    LoadList();
                else {
                    File.Copy(cunp + @"\cumples.🎉🎁", cunp + @"\cumples.bak.🎉🎁");
                    SaveList();
                }
            }

            try { RefreshList(); }
            catch { }
        }

        public void SaveList() {
            Directory.CreateDirectory(cunp);
            string json = JsonConvert.SerializeObject(bds);
            json = Crypter.Encrypt(json, pw);
            File.WriteAllText(cunp + @"\cumples.🎉🎁", json);
        }

        #endregion

        #region Context Menu Strip

        void editbdTSMI_Click(object sender, EventArgs e)
        {
            Edit();
        }

        void bdLB_DoubleClick(object sender, EventArgs e)
        {
            if (bdLB.SelectedIndex >= 0)
                Edit();
        }

        void Edit() {

            int i = SelectedPerson(bdLB.SelectedIndex);
            new PickDayF(bds[i], i).Show();
        }

        void addbdTSMI_Click(object sender, EventArgs e)
        {
           new PickDayF().Show();
        }

        void delbdTSMI_Click(object sender, EventArgs e)
        {
            Delete();
        }

        void Delete() {
            int i = SelectedPerson(bdLB.SelectedIndex);
            DialogResult r = MessageBox.Show(Resources.remove1 + " " +
                bds[i].Person + Resources.remove2, Resources.removet, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                bds.RemoveAt(i);
                RefreshList();
                SaveList();
            }
        }

        int SelectedPerson(int index) {
            string name = bdLB.Items[index].ToString().Split(',')[1].Substring(1);
            for (int i = 0; i < bds.Count; i++)
                if (name == bds[i].Person)
                    return i;

            return -1;
        }

        void bdLB_MouseDown(object sender, MouseEventArgs e)
        {
            bdLB.SelectedIndex = bdLB.IndexFromPoint(e.Location);
        }

        void bdlbCMS_Opening(object sender, CancelEventArgs e)
        {
            CheckEnabled();
        }

        void bdLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnabled();
        }

        public void CheckEnabled()
        {
            if (bdLB.SelectedIndex >= 0)
            {
                editbdTSMI.Enabled = true;
                delbdTSMI.Enabled = true;
                editbdB.Enabled = true;
                deletebdB.Enabled = true;
            }
            else
            {
                editbdTSMI.Enabled = false;
                delbdTSMI.Enabled = false;
                editbdB.Enabled = false;
                deletebdB.Enabled = false;
            }
        }

        #endregion

        #region Others

        void bdLB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Edit();

            if (e.KeyCode == Keys.Delete)
                Delete();
        }

        void optionsB_Click(object sender, EventArgs e)
        {
            new OptionsF().Show();
        }

        public static void StartWithWindows(bool startwithwindows)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                (@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (startwithwindows)
                rk.SetValue("Cumplenotas", Application.ExecutablePath.ToString() + " -minimized");
            else
                rk.DeleteValue("Cumplenotas", false);
        }

        void MainF_Resize(object sender, EventArgs e)
        {
            CheckState();
        }

        void CheckState() {
            if (WindowState == FormWindowState.Minimized)
            {
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(1000);
                ShowInTaskbar = false;
            }
            else
            {
                appNotifyIcon.Visible = false;
                ShowInTaskbar = true;
            }
        }

        void appNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            appNotifyIcon.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        public void SaveBackup() {
            try
            {
                string[] lines = new string[bds.Count];

                for (int i = 0; i < bds.Count; i++)
                    lines[i] = bds[i].Person + ", " + bds[i].Date.ToString("dd MMMM");

                File.WriteAllLines(cunp + @"\" + DateTime.Today.ToString("dd-MM-yyyy") + ".backup", lines);

                MessageBox.Show(Resources.backup1 + " " + MainF.cunp +
                    "\r\n\r\n" + Resources.backup2,
                    Resources.backupt, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                if (
                MessageBox.Show(Resources.backuper, Resources.backupert,
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                == DialogResult.Retry)
                    SaveBackup();
            }
        }

        #endregion

        void checkUpdatesB_Click(object sender, EventArgs e)
        {
            new UpdateChecker.UpdateChecker(System.Reflection.Assembly.GetExecutingAssembly().Location, "cun").Show();
        }
    }
}
