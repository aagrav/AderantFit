using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AderantFit
{
    public partial class AderantFitLogin : Form
    {
        //properties
        public string UserName
        {
            get
            {
                return TBusername.Text;
            }
        }

        IFitDB db;

        //Sets up Form
        public AderantFitLogin()
        {
            this.db = new FitDB();
            InitializeComponent();
            TBusername.Text = AderantFit.Properties.Resources.username;
            TBpass.Text = AderantFit.Properties.Resources.password;
            TBpass.KeyPress += TBpass_KeyPress;
            TBusername.KeyPress += TBpass_KeyPress;


        }

        //Process Form Validates / Authenticates then calls form
        private void processForm()
        {
            if (validateCredentials())
            {
                if (db.AuthenticateUsernameAndPassword(this.TBusername.Text, this.TBpass.Text))
                {
                    Trainer trainer = new Trainer();
                    trainer = db.GetTrainer(this.TBusername.Text);
                    showForm(trainer);
                }
                else
                {
                    //Error Requirement
                    MessageBox.Show("Invalid Username or Password Combination", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        //Login Click -- Validates then Shows 2ndary form
        private void BTNlogin_Click(object sender, EventArgs e)
        {
            processForm();
        }

        //Key Press Input for Login -- Enter Key 
        private void TBpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                processForm();
            }
        }

        //Resuable Login Form Field Reset
        private void resetFields()
        {
            TBusername.Focus();
            TBusername.Clear();
            TBpass.Clear();
            TBusername.Text = AderantFit.Properties.Resources.username;
            TBpass.Text = AderantFit.Properties.Resources.password;
        }

        //Validates Form side and Server Side.
        private bool validateCredentials()
        {
            //Error Compilation & Reporting
            //Validation
            if (string.IsNullOrEmpty(TBusername.Text) || string.IsNullOrEmpty(TBpass.Text) || (TBusername.Text.Equals("Username"))||TBpass.Text.Equals("Password"))
            {
                //Error Requirement
                MessageBox.Show("Username & Password Required", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetFields();
                return false;
            }
            return true;
        }

        //Runs DB class then proceeds to showing form
        private void showForm(Trainer trainer)
        {
                DialogResult = DialogResult.OK;
                Form trainerForm = new AderantFitBaseForm(trainer);
                trainerForm.Show();
                this.Hide();
                trainerForm.FormClosed += (senders,args) => this.Show();
        }




        //Debug button to Login Easier.
        private void BTNclear_Click(object sender, EventArgs e)
        {
            resetFields();
        }
       

        //Registration = Create New user. If person doesn't exist, create him, then make client out of person else make existing person client.
        //Checks for Existences of USR / Unique Person
        private void BTNregister_Click(object sender, EventArgs e)
        {
            RegisterModal regiForm = new RegisterModal();
            regiForm.ShowDialog();
        }



    }
}