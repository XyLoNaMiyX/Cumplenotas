namespace Cumplenotas
{
    partial class MainF
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainF));
            this.birthdaysL = new System.Windows.Forms.Label();
            this.bdLB = new System.Windows.Forms.ListBox();
            this.bdlbCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editbdTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addbdTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.delbdTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.showAllCB = new System.Windows.Forms.CheckBox();
            this.addbdB = new System.Windows.Forms.Button();
            this.editbdB = new System.Windows.Forms.Button();
            this.deletebdB = new System.Windows.Forms.Button();
            this.optionsB = new System.Windows.Forms.Button();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkUpdatesB = new System.Windows.Forms.Button();
            this.bdlbCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // birthdaysL
            // 
            resources.ApplyResources(this.birthdaysL, "birthdaysL");
            this.birthdaysL.Name = "birthdaysL";
            // 
            // bdLB
            // 
            resources.ApplyResources(this.bdLB, "bdLB");
            this.bdLB.ContextMenuStrip = this.bdlbCMS;
            this.bdLB.FormattingEnabled = true;
            this.bdLB.Name = "bdLB";
            this.bdLB.SelectedIndexChanged += new System.EventHandler(this.bdLB_SelectedIndexChanged);
            this.bdLB.DoubleClick += new System.EventHandler(this.bdLB_DoubleClick);
            this.bdLB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bdLB_KeyDown);
            this.bdLB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bdLB_MouseDown);
            // 
            // bdlbCMS
            // 
            resources.ApplyResources(this.bdlbCMS, "bdlbCMS");
            this.bdlbCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editbdTSMI,
            this.toolStripSeparator1,
            this.addbdTSMI,
            this.delbdTSMI});
            this.bdlbCMS.Name = "bdlbCMS";
            this.bdlbCMS.Opening += new System.ComponentModel.CancelEventHandler(this.bdlbCMS_Opening);
            // 
            // editbdTSMI
            // 
            resources.ApplyResources(this.editbdTSMI, "editbdTSMI");
            this.editbdTSMI.Name = "editbdTSMI";
            this.editbdTSMI.Click += new System.EventHandler(this.editbdTSMI_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // addbdTSMI
            // 
            resources.ApplyResources(this.addbdTSMI, "addbdTSMI");
            this.addbdTSMI.Name = "addbdTSMI";
            this.addbdTSMI.Click += new System.EventHandler(this.addbdTSMI_Click);
            // 
            // delbdTSMI
            // 
            resources.ApplyResources(this.delbdTSMI, "delbdTSMI");
            this.delbdTSMI.Name = "delbdTSMI";
            this.delbdTSMI.Click += new System.EventHandler(this.delbdTSMI_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // showAllCB
            // 
            resources.ApplyResources(this.showAllCB, "showAllCB");
            this.showAllCB.Name = "showAllCB";
            this.showAllCB.UseVisualStyleBackColor = true;
            this.showAllCB.CheckedChanged += new System.EventHandler(this.showAllCB_CheckedChanged);
            // 
            // addbdB
            // 
            resources.ApplyResources(this.addbdB, "addbdB");
            this.addbdB.Name = "addbdB";
            this.addbdB.UseVisualStyleBackColor = true;
            this.addbdB.Click += new System.EventHandler(this.addbdTSMI_Click);
            // 
            // editbdB
            // 
            resources.ApplyResources(this.editbdB, "editbdB");
            this.editbdB.Name = "editbdB";
            this.editbdB.UseVisualStyleBackColor = true;
            this.editbdB.Click += new System.EventHandler(this.editbdTSMI_Click);
            // 
            // deletebdB
            // 
            resources.ApplyResources(this.deletebdB, "deletebdB");
            this.deletebdB.Name = "deletebdB";
            this.deletebdB.UseVisualStyleBackColor = true;
            this.deletebdB.Click += new System.EventHandler(this.delbdTSMI_Click);
            // 
            // optionsB
            // 
            resources.ApplyResources(this.optionsB, "optionsB");
            this.optionsB.Name = "optionsB";
            this.optionsB.UseVisualStyleBackColor = true;
            this.optionsB.Click += new System.EventHandler(this.optionsB_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.appNotifyIcon, "appNotifyIcon");
            this.appNotifyIcon.DoubleClick += new System.EventHandler(this.appNotifyIcon_DoubleClick);
            // 
            // checkUpdatesB
            // 
            resources.ApplyResources(this.checkUpdatesB, "checkUpdatesB");
            this.checkUpdatesB.Name = "checkUpdatesB";
            this.checkUpdatesB.UseVisualStyleBackColor = true;
            this.checkUpdatesB.Click += new System.EventHandler(this.checkUpdatesB_Click);
            // 
            // MainF
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkUpdatesB);
            this.Controls.Add(this.optionsB);
            this.Controls.Add(this.deletebdB);
            this.Controls.Add(this.editbdB);
            this.Controls.Add(this.addbdB);
            this.Controls.Add(this.showAllCB);
            this.Controls.Add(this.bdLB);
            this.Controls.Add(this.birthdaysL);
            this.Name = "MainF";
            this.Load += new System.EventHandler(this.MainF_Load);
            this.Resize += new System.EventHandler(this.MainF_Resize);
            this.bdlbCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label birthdaysL;
        private System.Windows.Forms.ListBox bdLB;
        private System.Windows.Forms.ContextMenuStrip bdlbCMS;
        private System.Windows.Forms.ToolStripMenuItem editbdTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addbdTSMI;
        private System.Windows.Forms.ToolStripMenuItem delbdTSMI;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox showAllCB;
        private System.Windows.Forms.Button addbdB;
        private System.Windows.Forms.Button editbdB;
        private System.Windows.Forms.Button deletebdB;
        private System.Windows.Forms.Button optionsB;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.Button checkUpdatesB;
    }
}

