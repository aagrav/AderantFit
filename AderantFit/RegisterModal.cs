using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AderantFit
{
    public partial class RegisterModal : AderantFit.BaseInputModal
    {
        public RegisterModal()
        {
            this.db = new FitDB();
            InitializeComponent();
            this.Text = AderantFit.Properties.Resources.registration;
            this.LBLinput1.Text = AderantFit.Properties.Resources.firstname + ":";
            this.LBLinput2.Text = AderantFit.Properties.Resources.lastname + ":";
            this.LBLinput3.Text = AderantFit.Properties.Resources.username + ":";
            this.LBLinput4.Text = AderantFit.Properties.Resources.password + ":";
            this.TBinput1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.BTNdelete.Hide();
            this.TBinput4.UseSystemPasswordChar = true;
        }

        protected override bool SaveSettings()
        {
            var fn = this.TBinput1.Text;
            var ln = this.TBinput2.Text;
            var usn = this.TBinput3.Text;
            var pass = this.TBinput4.Text;
            Trainer trainer = new Trainer();
            trainer.firstName = fn;
            trainer.lastName = ln;
            trainer.usn = usn;
            trainer.pass = pass;
            MessageBox.Show(this.db.SaveTrainer(trainer), this.Text, MessageBoxButtons.OK);
            return true;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!e.Cancel && (this.DialogResult == DialogResult.OK))
            {
                // If SaveSettings() is OK (TRUE), then e.Cancel
                // will be FALSE, therefore the application will be exit.
                if (!(String.IsNullOrEmpty(this.TBinput1.Text) && !String.IsNullOrEmpty(this.TBinput2.Text) && !String.IsNullOrEmpty(this.TBinput3.Text) && !String.IsNullOrEmpty(this.TBinput4.Text)))
                {
                    if (this.db.GetTrainerId(this.TBinput1.Text,this.TBinput2.Text) == 0)
                    {
                        if (this.db.GetTrainerId(this.TBinput3.Text) == 0)
                        {
                            SaveSettings();
                        }
                        else
                        {
                            MessageBox.Show("Account exists! Please specify another username", this.Text, MessageBoxButtons.OK);
                            e.Cancel = true;
                            base.OnClosing(e);
                        }
                       
                    }
                    else
                    {
                        
                        MessageBox.Show("Person already is a trainer", this.Text, MessageBoxButtons.OK);
                        e.Cancel = true;
                        base.OnClosing(e);
                    }
                    
                }
                else
                {
                    
                    MessageBox.Show("Missing required fields please fill in.", this.Text, MessageBoxButtons.OK);
                    e.Cancel = true;
                    base.OnClosing(e);
                }
                
            }
            else
            {
                //MessageBox.Show("Cancel was pressed", this.Text, MessageBoxButtons.OK);
                //base.OnClosing(e);
            }
            // Make sure any Closing event handler for the
            // form are called before the application exits.

        }

        //Key Press Reg Expression for Field Validation and filtering
        protected override void Validation(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Code logic derived on form
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z0-9\b]+$") && sender.Equals(TBinput3))
            {
                MessageBox.Show("This field does not accept special characters!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;

            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z\b]+$") && !sender.Equals(TBinput3))
            {
                MessageBox.Show("This field does not accept numbers or special characters!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }

        }

    }
}
