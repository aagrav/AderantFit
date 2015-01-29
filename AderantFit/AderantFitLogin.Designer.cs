namespace AderantFit
{
    partial class AderantFitLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AderantFitLogin));
            this.PBlogo = new System.Windows.Forms.PictureBox();
            this.TBusername = new System.Windows.Forms.TextBox();
            this.TBpass = new System.Windows.Forms.TextBox();
            this.BTNlogin = new System.Windows.Forms.Button();
            this.BTNclear = new System.Windows.Forms.Button();
            this.BTNregister = new System.Windows.Forms.Button();
            this.req2 = new System.Windows.Forms.Label();
            this.req1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PBlogo
            // 
            this.PBlogo.Image = ((System.Drawing.Image)(resources.GetObject("PBlogo.Image")));
            this.PBlogo.Location = new System.Drawing.Point(76, 12);
            this.PBlogo.Name = "PBlogo";
            this.PBlogo.Size = new System.Drawing.Size(132, 127);
            this.PBlogo.TabIndex = 0;
            this.PBlogo.TabStop = false;
            // 
            // TBusername
            // 
            this.TBusername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TBusername.ForeColor = System.Drawing.Color.DarkRed;
            this.TBusername.Location = new System.Drawing.Point(27, 161);
            this.TBusername.MaxLength = 35;
            this.TBusername.Name = "TBusername";
            this.TBusername.Size = new System.Drawing.Size(230, 32);
            this.TBusername.TabIndex = 1;
            // 
            // TBpass
            // 
            this.TBpass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TBpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TBpass.ForeColor = System.Drawing.Color.DarkRed;
            this.TBpass.Location = new System.Drawing.Point(27, 213);
            this.TBpass.MaxLength = 35;
            this.TBpass.Name = "TBpass";
            this.TBpass.Size = new System.Drawing.Size(230, 32);
            this.TBpass.TabIndex = 2;
            this.TBpass.UseSystemPasswordChar = true;
            // 
            // BTNlogin
            // 
            this.BTNlogin.BackColor = System.Drawing.Color.DarkRed;
            this.BTNlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BTNlogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTNlogin.Location = new System.Drawing.Point(27, 274);
            this.BTNlogin.Name = "BTNlogin";
            this.BTNlogin.Size = new System.Drawing.Size(230, 39);
            this.BTNlogin.TabIndex = 3;
            this.BTNlogin.Text = "Sign in";
            this.BTNlogin.UseVisualStyleBackColor = false;
            this.BTNlogin.Click += new System.EventHandler(this.BTNlogin_Click);
            // 
            // BTNclear
            // 
            this.BTNclear.Location = new System.Drawing.Point(104, 249);
            this.BTNclear.Name = "BTNclear";
            this.BTNclear.Size = new System.Drawing.Size(75, 23);
            this.BTNclear.TabIndex = 4;
            this.BTNclear.Text = "Clear";
            this.BTNclear.UseVisualStyleBackColor = true;
            this.BTNclear.Click += new System.EventHandler(this.BTNclear_Click);
            // 
            // BTNregister
            // 
            this.BTNregister.BackColor = System.Drawing.Color.Black;
            this.BTNregister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BTNregister.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTNregister.Location = new System.Drawing.Point(27, 319);
            this.BTNregister.Name = "BTNregister";
            this.BTNregister.Size = new System.Drawing.Size(230, 39);
            this.BTNregister.TabIndex = 5;
            this.BTNregister.Text = "Register";
            this.BTNregister.UseVisualStyleBackColor = false;
            this.BTNregister.Click += new System.EventHandler(this.BTNregister_Click);
            // 
            // req2
            // 
            this.req2.AutoSize = true;
            this.req2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.req2.ForeColor = System.Drawing.Color.DarkRed;
            this.req2.Location = new System.Drawing.Point(257, 216);
            this.req2.Name = "req2";
            this.req2.Size = new System.Drawing.Size(15, 20);
            this.req2.TabIndex = 17;
            this.req2.Text = "*";
            // 
            // req1
            // 
            this.req1.AutoSize = true;
            this.req1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.req1.ForeColor = System.Drawing.Color.DarkRed;
            this.req1.Location = new System.Drawing.Point(257, 168);
            this.req1.Name = "req1";
            this.req1.Size = new System.Drawing.Size(15, 20);
            this.req1.TabIndex = 16;
            this.req1.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(57, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "* Indicates required field";
            // 
            // AderantFitLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.req2);
            this.Controls.Add(this.req1);
            this.Controls.Add(this.BTNregister);
            this.Controls.Add(this.BTNclear);
            this.Controls.Add(this.BTNlogin);
            this.Controls.Add(this.TBpass);
            this.Controls.Add(this.TBusername);
            this.Controls.Add(this.PBlogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AderantFitLogin";
            this.Text = "AderantFit";
            this.TransparencyKey = System.Drawing.Color.Cyan;
            ((System.ComponentModel.ISupportInitialize)(this.PBlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBlogo;
        private System.Windows.Forms.Button BTNlogin;
        public System.Windows.Forms.TextBox TBpass;
        public System.Windows.Forms.TextBox TBusername;
        private System.Windows.Forms.Button BTNclear;
        private System.Windows.Forms.Button BTNregister;
        private System.Windows.Forms.Label req2;
        private System.Windows.Forms.Label req1;
        private System.Windows.Forms.Label label1;
    }
}

