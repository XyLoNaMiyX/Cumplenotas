using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cumplenotas.Properties;

namespace Cumplenotas
{
    public partial class PickDayF : Form
    {
        public PickDayF()
        {
            InitializeComponent();
        }

        public PickDayF(MainF.Birthday bd, int index)
        {
            InitializeComponent();
            this.Text = Resources.editof + " " + bd.Person;
            addB.Text = Resources.save;
            personTB.Text = bd.Person;
            dateMC.SelectionStart = bd.Date;
            extraTB.Text = bd.Extra;
            i = index;
            currentBD = bd;
        }

        MainF f = (MainF)Application.OpenForms["MainF"];
        MainF.Birthday currentBD = new MainF.Birthday(DateTime.Now, "null", "null");
        int i = -1;

        private void addB_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Accept()
        {
            if (i < 0)
            {
                foreach (MainF.Birthday birthday in MainF.bds)
                    if (birthday.Person == personTB.Text)
                    {
                        MessageBox.Show(Resources.samename, Resources.samenamet,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        personTB.Focus();
                        return;
                    }

                MainF.Birthday bd = new MainF.Birthday(dateMC.SelectionStart, personTB.Text, extraTB.Text);
                MainF.bds.Add(bd);
                f.SaveList();
                f.RefreshList();
                this.Close();
            }
            else
            {
                foreach (MainF.Birthday birthday in MainF.bds)
                    if (birthday.Person == personTB.Text)
                        if (birthday.Person != currentBD.Person)
                        {
                            MessageBox.Show(Resources.samename, Resources.samenamet,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            personTB.Focus();
                            return;
                        }

                MainF.Birthday bd = new MainF.Birthday(dateMC.SelectionStart, personTB.Text, extraTB.Text);
                MainF.bds[i] = bd;
                f.SaveList();
                f.RefreshList();
                this.Close();
            }
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Accept();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                catch { }
            }
        }

        private void PickDayF_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.CheckEnabled();
        }
    }
}
