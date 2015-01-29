namespace AderantFit
{
    partial class AderantFitBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AderantFitBaseForm));
            this.LBdata = new System.Windows.Forms.ListBox();
            this.LBLlistbox = new System.Windows.Forms.Label();
            this.BTNschedule = new System.Windows.Forms.Button();
            this.BTNadd = new System.Windows.Forms.Button();
            this.BTNedit = new System.Windows.Forms.Button();
            this.CBsession = new System.Windows.Forms.CheckBox();
            this.CBtotal = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBLrate = new System.Windows.Forms.Label();
            this.LBLprofit = new System.Windows.Forms.Label();
            this.LBLmoney = new System.Windows.Forms.Label();
            this.LBLinput4 = new System.Windows.Forms.Label();
            this.TBinput4 = new System.Windows.Forms.TextBox();
            this.LBLinput5 = new System.Windows.Forms.Label();
            this.TBinput5 = new System.Windows.Forms.TextBox();
            this.BTNup = new System.Windows.Forms.Button();
            this.BTNdown = new System.Windows.Forms.Button();
            this.LBLfilter = new System.Windows.Forms.Label();
            this.BTNclear = new System.Windows.Forms.Button();
            this.BTNdeselect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LBdata
            // 
            this.LBdata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LBdata.ForeColor = System.Drawing.Color.DarkRed;
            this.LBdata.FormattingEnabled = true;
            this.LBdata.ItemHeight = 16;
            this.LBdata.Location = new System.Drawing.Point(12, 46);
            this.LBdata.Name = "LBdata";
            this.LBdata.ScrollAlwaysVisible = true;
            this.LBdata.Size = new System.Drawing.Size(265, 212);
            this.LBdata.TabIndex = 0;
            // 
            // LBLlistbox
            // 
            this.LBLlistbox.AutoSize = true;
            this.LBLlistbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLlistbox.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLlistbox.Location = new System.Drawing.Point(8, 22);
            this.LBLlistbox.Name = "LBLlistbox";
            this.LBLlistbox.Size = new System.Drawing.Size(102, 20);
            this.LBLlistbox.TabIndex = 2;
            this.LBLlistbox.Text = "Label Listbox";
            // 
            // BTNschedule
            // 
            this.BTNschedule.BackColor = System.Drawing.Color.DarkRed;
            this.BTNschedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BTNschedule.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTNschedule.Location = new System.Drawing.Point(283, 129);
            this.BTNschedule.Name = "BTNschedule";
            this.BTNschedule.Size = new System.Drawing.Size(168, 39);
            this.BTNschedule.TabIndex = 4;
            this.BTNschedule.Text = "Schedule";
            this.BTNschedule.UseVisualStyleBackColor = false;
            this.BTNschedule.Click += new System.EventHandler(this.BTNschedule_Click);
            // 
            // BTNadd
            // 
            this.BTNadd.BackColor = System.Drawing.Color.DarkRed;
            this.BTNadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BTNadd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTNadd.Location = new System.Drawing.Point(283, 174);
            this.BTNadd.Name = "BTNadd";
            this.BTNadd.Size = new System.Drawing.Size(168, 39);
            this.BTNadd.TabIndex = 6;
            this.BTNadd.Text = "add X";
            this.BTNadd.UseVisualStyleBackColor = false;
            this.BTNadd.Click += new System.EventHandler(this.BTNadd_Click);
            // 
            // BTNedit
            // 
            this.BTNedit.BackColor = System.Drawing.Color.DarkRed;
            this.BTNedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BTNedit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTNedit.Location = new System.Drawing.Point(283, 219);
            this.BTNedit.Name = "BTNedit";
            this.BTNedit.Size = new System.Drawing.Size(168, 39);
            this.BTNedit.TabIndex = 7;
            this.BTNedit.Text = "edit X";
            this.BTNedit.UseVisualStyleBackColor = false;
            this.BTNedit.Click += new System.EventHandler(this.BTNremove_Click);
            // 
            // CBsession
            // 
            this.CBsession.AutoSize = true;
            this.CBsession.Location = new System.Drawing.Point(305, 32);
            this.CBsession.Name = "CBsession";
            this.CBsession.Size = new System.Drawing.Size(63, 17);
            this.CBsession.TabIndex = 8;
            this.CBsession.Text = "Session";
            this.CBsession.UseVisualStyleBackColor = true;
            this.CBsession.CheckedChanged += new System.EventHandler(this.CBsession_CheckedChanged);
            // 
            // CBtotal
            // 
            this.CBtotal.AutoSize = true;
            this.CBtotal.Location = new System.Drawing.Point(384, 33);
            this.CBtotal.Name = "CBtotal";
            this.CBtotal.Size = new System.Drawing.Size(50, 17);
            this.CBtotal.TabIndex = 9;
            this.CBtotal.Text = "Total";
            this.CBtotal.UseVisualStyleBackColor = true;
            this.CBtotal.CheckedChanged += new System.EventHandler(this.CBtotal_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(305, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 43);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // LBLrate
            // 
            this.LBLrate.AutoSize = true;
            this.LBLrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLrate.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLrate.Location = new System.Drawing.Point(340, 53);
            this.LBLrate.Name = "LBLrate";
            this.LBLrate.Size = new System.Drawing.Size(57, 24);
            this.LBLrate.TabIndex = 11;
            this.LBLrate.Text = "Profit";
            // 
            // LBLprofit
            // 
            this.LBLprofit.AutoSize = true;
            this.LBLprofit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLprofit.ForeColor = System.Drawing.Color.Green;
            this.LBLprofit.Location = new System.Drawing.Point(337, 88);
            this.LBLprofit.Name = "LBLprofit";
            this.LBLprofit.Size = new System.Drawing.Size(60, 25);
            this.LBLprofit.TabIndex = 12;
            this.LBLprofit.Text = "$$$$";
            // 
            // LBLmoney
            // 
            this.LBLmoney.AutoSize = true;
            this.LBLmoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLmoney.ForeColor = System.Drawing.Color.Green;
            this.LBLmoney.Location = new System.Drawing.Point(308, 88);
            this.LBLmoney.Name = "LBLmoney";
            this.LBLmoney.Size = new System.Drawing.Size(24, 25);
            this.LBLmoney.TabIndex = 13;
            this.LBLmoney.Text = "$";
            // 
            // LBLinput4
            // 
            this.LBLinput4.AutoSize = true;
            this.LBLinput4.Location = new System.Drawing.Point(472, 138);
            this.LBLinput4.Name = "LBLinput4";
            this.LBLinput4.Size = new System.Drawing.Size(35, 13);
            this.LBLinput4.TabIndex = 27;
            this.LBLinput4.Text = "label1";
            // 
            // TBinput4
            // 
            this.TBinput4.Location = new System.Drawing.Point(472, 156);
            this.TBinput4.MaxLength = 35;
            this.TBinput4.Name = "TBinput4";
            this.TBinput4.Size = new System.Drawing.Size(150, 20);
            this.TBinput4.TabIndex = 26;
            this.TBinput4.TextChanged += new System.EventHandler(this.TBinput4_TextChanged);
            this.TBinput4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBnames_KeyPress);
            // 
            // LBLinput5
            // 
            this.LBLinput5.AutoSize = true;
            this.LBLinput5.Location = new System.Drawing.Point(472, 181);
            this.LBLinput5.Name = "LBLinput5";
            this.LBLinput5.Size = new System.Drawing.Size(35, 13);
            this.LBLinput5.TabIndex = 29;
            this.LBLinput5.Text = "label1";
            // 
            // TBinput5
            // 
            this.TBinput5.Location = new System.Drawing.Point(472, 199);
            this.TBinput5.MaxLength = 35;
            this.TBinput5.Name = "TBinput5";
            this.TBinput5.Size = new System.Drawing.Size(150, 20);
            this.TBinput5.TabIndex = 28;
            this.TBinput5.TextChanged += new System.EventHandler(this.TBinput4_TextChanged);
            this.TBinput5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBnames_KeyPress);
            // 
            // BTNup
            // 
            this.BTNup.Location = new System.Drawing.Point(400, 53);
            this.BTNup.Name = "BTNup";
            this.BTNup.Size = new System.Drawing.Size(34, 28);
            this.BTNup.TabIndex = 32;
            this.BTNup.Text = "+";
            this.BTNup.UseVisualStyleBackColor = true;
            this.BTNup.Click += new System.EventHandler(this.BTNup_Click);
            // 
            // BTNdown
            // 
            this.BTNdown.Location = new System.Drawing.Point(305, 53);
            this.BTNdown.Name = "BTNdown";
            this.BTNdown.Size = new System.Drawing.Size(34, 28);
            this.BTNdown.TabIndex = 33;
            this.BTNdown.Text = "-";
            this.BTNdown.UseVisualStyleBackColor = true;
            this.BTNdown.Click += new System.EventHandler(this.BTNdown_Click);
            // 
            // LBLfilter
            // 
            this.LBLfilter.AutoSize = true;
            this.LBLfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLfilter.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLfilter.Location = new System.Drawing.Point(468, 114);
            this.LBLfilter.Name = "LBLfilter";
            this.LBLfilter.Size = new System.Drawing.Size(49, 24);
            this.LBLfilter.TabIndex = 34;
            this.LBLfilter.Text = "filter";
            // 
            // BTNclear
            // 
            this.BTNclear.Location = new System.Drawing.Point(472, 225);
            this.BTNclear.Name = "BTNclear";
            this.BTNclear.Size = new System.Drawing.Size(75, 23);
            this.BTNclear.TabIndex = 35;
            this.BTNclear.Text = "Clear";
            this.BTNclear.UseVisualStyleBackColor = true;
            this.BTNclear.Click += new System.EventHandler(this.BTNclear_Click);
            // 
            // BTNdeselect
            // 
            this.BTNdeselect.Location = new System.Drawing.Point(202, 22);
            this.BTNdeselect.Name = "BTNdeselect";
            this.BTNdeselect.Size = new System.Drawing.Size(75, 23);
            this.BTNdeselect.TabIndex = 36;
            this.BTNdeselect.Text = "Deselect";
            this.BTNdeselect.UseVisualStyleBackColor = true;
            this.BTNdeselect.Click += new System.EventHandler(this.BTNdeselect_Click);
            // 
            // AderantFitBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 285);
            this.Controls.Add(this.BTNdeselect);
            this.Controls.Add(this.BTNclear);
            this.Controls.Add(this.LBLfilter);
            this.Controls.Add(this.BTNdown);
            this.Controls.Add(this.BTNup);
            this.Controls.Add(this.LBLinput5);
            this.Controls.Add(this.TBinput5);
            this.Controls.Add(this.LBLinput4);
            this.Controls.Add(this.TBinput4);
            this.Controls.Add(this.LBLmoney);
            this.Controls.Add(this.LBLprofit);
            this.Controls.Add(this.LBLrate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CBtotal);
            this.Controls.Add(this.CBsession);
            this.Controls.Add(this.BTNedit);
            this.Controls.Add(this.BTNadd);
            this.Controls.Add(this.BTNschedule);
            this.Controls.Add(this.LBLlistbox);
            this.Controls.Add(this.LBdata);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AderantFitBaseForm";
            this.Text = "LBL";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ListBox LBdata;
        private System.Windows.Forms.Label LBLlistbox;
        private System.Windows.Forms.Button BTNschedule;
        private System.Windows.Forms.Button BTNadd;
        private System.Windows.Forms.Button BTNedit;
        private System.Windows.Forms.CheckBox CBsession;
        private System.Windows.Forms.CheckBox CBtotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBLrate;
        private System.Windows.Forms.Label LBLprofit;
        private System.Windows.Forms.Label LBLmoney;
        private System.Windows.Forms.Label LBLinput4;
        private System.Windows.Forms.TextBox TBinput4;
        private System.Windows.Forms.Label LBLinput5;
        private System.Windows.Forms.TextBox TBinput5;
        private System.Windows.Forms.Button BTNup;
        private System.Windows.Forms.Button BTNdown;
        private System.Windows.Forms.Label LBLfilter;
        private System.Windows.Forms.Button BTNclear;
        private System.Windows.Forms.Button BTNdeselect;
    }
}