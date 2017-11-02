namespace Cumplenotas
{
    partial class OptionsF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsF));
            this.notifDelayL = new System.Windows.Forms.Label();
            this.acceptB = new System.Windows.Forms.Button();
            this.startWithWinCB = new System.Windows.Forms.CheckBox();
            this.notifDelayNUD = new System.Windows.Forms.NumericUpDown();
            this.smallqNUD = new System.Windows.Forms.NumericUpDown();
            this.smallqL = new System.Windows.Forms.Label();
            this.cancelB = new System.Windows.Forms.Button();
            this.spamL = new System.Windows.Forms.Label();
            this.supportL = new System.Windows.Forms.LinkLabel();
            this.saveBackupB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.notifDelayNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallqNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // notifDelayL
            // 
            resources.ApplyResources(this.notifDelayL, "notifDelayL");
            this.notifDelayL.Name = "notifDelayL";
            // 
            // acceptB
            // 
            resources.ApplyResources(this.acceptB, "acceptB");
            this.acceptB.Name = "acceptB";
            this.acceptB.UseVisualStyleBackColor = true;
            this.acceptB.Click += new System.EventHandler(this.acceptB_Click);
            // 
            // startWithWinCB
            // 
            resources.ApplyResources(this.startWithWinCB, "startWithWinCB");
            this.startWithWinCB.Name = "startWithWinCB";
            this.startWithWinCB.UseVisualStyleBackColor = true;
            this.startWithWinCB.CheckedChanged += new System.EventHandler(this.startWithWinCB_CheckedChanged);
            // 
            // notifDelayNUD
            // 
            resources.ApplyResources(this.notifDelayNUD, "notifDelayNUD");
            this.notifDelayNUD.DecimalPlaces = 1;
            this.notifDelayNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.notifDelayNUD.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.notifDelayNUD.Name = "notifDelayNUD";
            this.notifDelayNUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // smallqNUD
            // 
            resources.ApplyResources(this.smallqNUD, "smallqNUD");
            this.smallqNUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.smallqNUD.Name = "smallqNUD";
            this.smallqNUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // smallqL
            // 
            resources.ApplyResources(this.smallqL, "smallqL");
            this.smallqL.Name = "smallqL";
            // 
            // cancelB
            // 
            resources.ApplyResources(this.cancelB, "cancelB");
            this.cancelB.Name = "cancelB";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // spamL
            // 
            resources.ApplyResources(this.spamL, "spamL");
            this.spamL.Name = "spamL";
            // 
            // supportL
            // 
            resources.ApplyResources(this.supportL, "supportL");
            this.supportL.Name = "supportL";
            this.supportL.TabStop = true;
            this.supportL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.supportL_LinkClicked);
            // 
            // saveBackupB
            // 
            resources.ApplyResources(this.saveBackupB, "saveBackupB");
            this.saveBackupB.Name = "saveBackupB";
            this.saveBackupB.UseVisualStyleBackColor = true;
            this.saveBackupB.Click += new System.EventHandler(this.saveBackupB_Click);
            // 
            // OptionsF
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveBackupB);
            this.Controls.Add(this.supportL);
            this.Controls.Add(this.spamL);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.smallqNUD);
            this.Controls.Add(this.smallqL);
            this.Controls.Add(this.notifDelayNUD);
            this.Controls.Add(this.startWithWinCB);
            this.Controls.Add(this.acceptB);
            this.Controls.Add(this.notifDelayL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OptionsF";
            this.Load += new System.EventHandler(this.OptionsF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notifDelayNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallqNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notifDelayL;
        private System.Windows.Forms.Button acceptB;
        private System.Windows.Forms.CheckBox startWithWinCB;
        private System.Windows.Forms.NumericUpDown notifDelayNUD;
        private System.Windows.Forms.NumericUpDown smallqNUD;
        private System.Windows.Forms.Label smallqL;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Label spamL;
        private System.Windows.Forms.LinkLabel supportL;
        private System.Windows.Forms.Button saveBackupB;
    }
}