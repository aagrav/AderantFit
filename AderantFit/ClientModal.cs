using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AderantFit
{
    public partial class ClientModal : AderantFit.BaseInputModal
    {
        protected Client client;
        public ClientModal(Client client)
        {
            this.client = client;
            this.db = new FitDB();
            InitializeComponent();
            this.Text = AderantFit.Properties.Resources.registration;
            this.LBLinput1.Text = AderantFit.Properties.Resources.firstname + ":";
            this.LBLinput2.Text = AderantFit.Properties.Resources.lastname + ":";
            this.TBinput1.Text = client.firstName;
            this.TBinput2.Text = client.lastName;
            this.LBLinput3.Hide();
            this.LBLinput4.Hide();
            this.TBinput3.Hide();
            this.TBinput4.Hide();
            this.req3.Hide();
            this.req4.Hide();
            this.TBinput1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.BTNdelete.Click += new System.EventHandler(this.BTNdelete_Click);
            
        }

        private void BTNdelete_Click(object sender, EventArgs e)
        {
            if (this.client.client_uno != 0)
            {
                if (MessageBox.Show("Are you sure you want to remove?", "Careful", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DeleteClient(client.client_uno);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You cannot delete a client that has not already been made.", this.Text, MessageBoxButtons.OK);
            }
        }

        protected override bool SaveSettings()
        {
            var fn = this.TBinput1.Text;
            var ln = this.TBinput2.Text;
            client.firstName = fn;
            client.lastName = ln;
            MessageBox.Show(this.db.SaveClient(client), this.Text, MessageBoxButtons.OK);
            return true;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!e.Cancel && (this.DialogResult == DialogResult.OK))
            {
                // If SaveSettings() is OK (TRUE), then e.Cancel
                // will be FALSE, therefore the application will be exit.
                if (!(String.IsNullOrEmpty(this.TBinput1.Text) && !String.IsNullOrEmpty(this.TBinput2.Text)))
                {
                    SaveSettings();
                    
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
                e.Cancel = false;
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
