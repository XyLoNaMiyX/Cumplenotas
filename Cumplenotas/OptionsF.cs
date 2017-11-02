using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

using Cumplenotas.Properties;

namespace Cumplenotas
{
    public partial class OptionsF : Form
    {
        public OptionsF()
        {
            InitializeComponent();
        }

        MainF f = (MainF)Application.OpenForms["MainF"];

        private void OptionsF_Load(object sender, EventArgs e)
        {
            smallqNUD.Value = (decimal)MainF.options.LittleShow;
            decimal value = MainF.options.NotificationTimeout / 1000m;
            notifDelayNUD.Value = value;

            startWithWinCB.Checked = MainF.options.StartWidthWindows;
        }

        private void startWithWinCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!startWithWinCB.Checked)
                if (
                MessageBox.Show(Resources.warnwin, Resources.warnwint,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                    startWithWinCB.Checked = true;

            MainF.StartWithWindows(startWithWinCB.Checked);
        }

        private void acceptB_Click(object sender, EventArgs e)
        {
            MainF.Options opts = new MainF.Options();

            opts.LittleShow = (int)smallqNUD.Value;

            decimal delay = notifDelayNUD.Value * 1000;
            opts.NotificationTimeout = (int)delay;

            opts.StartWidthWindows = startWithWinCB.Checked;

            MainF.options = opts;
            f.SaveOptions();

            this.Close();
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supportL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://lonamiwebs.github.io/contacto.php?t=software&q=cun");
        }

        private void saveBackupB_Click(object sender, EventArgs e)
        {
            f.SaveBackup();
        }
    }
}
