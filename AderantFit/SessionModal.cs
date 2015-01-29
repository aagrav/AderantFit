using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AderantFit
{
    public partial class SessionModal : AderantFit.BaseInputModal
    {
        Session session;
        public SessionModal(Session session, int num)
        {
            this.session = session;
            this.session.session_num = num;
            this.db = new FitDB();
            InitializeComponent();
            this.Text = AderantFit.Properties.Resources.session;
            this.LBLinput1.Text = AderantFit.Properties.Resources.workoutname + ":";
            this.LBLinput2.Text = AderantFit.Properties.Resources.numreps + ":";
            this.LBLinput3.Text = AderantFit.Properties.Resources.numsets + ":";
            this.LBLinput4.Text = AderantFit.Properties.Resources.exerciseweight + ":";
            req2.Hide();
            req3.Hide();
            req4.Hide();
            this.TBinput1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
            this.TBinput4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validation);
        }

        protected override bool SaveSettings()
        {
            session.workoutName = TBinput1.Text;
            if (!String.IsNullOrEmpty(TBinput2.Text))
            {
                session.numReps = Convert.ToInt32(TBinput2.Text);
            }
            if (!String.IsNullOrEmpty(TBinput3.Text))
            {
                session.numSets = Convert.ToInt32(TBinput3.Text);
            }
            if (!String.IsNullOrEmpty(TBinput4.Text))
            {
                session.exerciseWeight = Convert.ToInt32(TBinput4.Text);
            }
            MessageBox.Show(this.db.SaveWorkoutSession(session), this.Text, MessageBoxButtons.OK);
            
            return true;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!e.Cancel && (this.DialogResult == DialogResult.OK))
            {
                // If SaveSettings() is OK (TRUE), then e.Cancel
                // will be FALSE, therefore the application will be exit.
                if (!(String.IsNullOrEmpty(this.TBinput1.Text)))
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
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\b]+$") && !sender.Equals(TBinput1))
            {
                MessageBox.Show("This field only accepts numbers", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;

            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z\b]+$") && sender.Equals(TBinput1))
            {
                MessageBox.Show("This field does not accept numbers or special characters!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }

        }
    }
}
