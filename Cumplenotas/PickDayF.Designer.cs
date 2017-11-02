namespace Cumplenotas
{
    partial class PickDayF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickDayF));
            this.dateMC = new System.Windows.Forms.MonthCalendar();
            this.addB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.personTB = new System.Windows.Forms.TextBox();
            this.extraL = new System.Windows.Forms.Label();
            this.extraTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateMC
            // 
            resources.ApplyResources(this.dateMC, "dateMC");
            this.dateMC.MaxSelectionCount = 1;
            this.dateMC.Name = "dateMC";
            // 
            // addB
            // 
            resources.ApplyResources(this.addB, "addB");
            this.addB.Name = "addB";
            this.addB.UseVisualStyleBackColor = true;
            this.addB.Click += new System.EventHandler(this.addB_Click);
            // 
            // cancelB
            // 
            resources.ApplyResources(this.cancelB, "cancelB");
            this.cancelB.Name = "cancelB";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // personTB
            // 
            resources.ApplyResources(this.personTB, "personTB");
            this.personTB.Name = "personTB";
            this.personTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.personTB_KeyDown);
            // 
            // extraL
            // 
            resources.ApplyResources(this.extraL, "extraL");
            this.extraL.Name = "extraL";
            // 
            // extraTB
            // 
            resources.ApplyResources(this.extraTB, "extraTB");
            this.extraTB.Name = "extraTB";
            // 
            // PickDayF
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.extraTB);
            this.Controls.Add(this.extraL);
            this.Controls.Add(this.personTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.addB);
            this.Controls.Add(this.dateMC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PickDayF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PickDayF_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dateMC;
        private System.Windows.Forms.Button addB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox personTB;
        private System.Windows.Forms.Label extraL;
        private System.Windows.Forms.TextBox extraTB;
    }
}