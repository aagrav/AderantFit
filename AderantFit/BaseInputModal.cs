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
    public partial class BaseInputModal : Form
    {

        protected IFitDB db;
        //Sets up Form
        public BaseInputModal()
        {
            InitializeComponent();
        }


        protected virtual void ResetSettings()
        {
            TBinput1.Clear();
            TBinput2.Clear();
            TBinput3.Clear();
            TBinput4.Clear();
        }

        // Derived Forms MUST override this method
        protected virtual bool SaveSettings()
        {
            // Code logic in derived Form
            MessageBox.Show("Ok was pressed", this.Text, MessageBoxButtons.OK);
            return true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!e.Cancel && (this.DialogResult == DialogResult.OK))
            {
                // If SaveSettings() is OK (TRUE), then e.Cancel
                // will be FALSE, therefore the application will be exit.
                
            }
            else
            {
                e.Cancel = true;
            }
            // Make sure any Closing event handler for the
            // form are called before the application exits.
            base.OnClosing(e);
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            // Call ResetSettings()in the derived Form
            ResetSettings();
        }

        //Key Press Reg Expression for Field Validation and filtering
        protected virtual void Validation(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Code logic derived on form

        }

        private void BTNclear_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

    }
}