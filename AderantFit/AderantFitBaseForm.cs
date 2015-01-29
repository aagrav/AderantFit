using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AderantFit.Properties;

namespace AderantFit
{
    public partial class AderantFitBaseForm : Form
    {
        Trainer trainer;
        Client client;
        List<Client> listClients = new List<Client>();
        List<Session> listSessions = new List<Session>();
        int formType;
        IFitDB db;
        ToolTip ratetip0;
        ToolTip ratetip1;
        ToolTip ratetip2;
        ToolTip ratetip3;
        ToolTip ratetip4;
        ToolTip ratetip5;

        /**
         * 
         * 
         * Section Below pertains to Initializing a resuable form
         * 
         * 
         * **/

        //Trainer Form
        public AderantFitBaseForm()
        {
            this.db = new FitDB();
        }

        public AderantFitBaseForm(Trainer t)
            : this()
        {


            InitializeComponent();
            this.trainer = t;
            this.formType = 1;
            this.Text = "Welcome " + trainer.firstName;
            this.CBsession.Text = "Client";
            this.CBtotal.Checked = true;
            this.LBLlistbox.Text = "";
            this.BTNadd.Text = Resources.addClient;
            this.BTNedit.Text = Resources.editClient;
            this.LBLinput4.Text = AderantFit.Properties.Resources.firstname;
            this.LBLinput5.Text = Resources.lastname;
            this.LBLfilter.Text = Resources.filter;
            this.ratetip0 = new ToolTip();
            this.ratetip1 = new ToolTip();
            this.ratetip2 = new ToolTip();
            this.ratetip3 = new ToolTip();
            this.ratetip4 = new ToolTip();
            this.ratetip5 = new ToolTip();

            //Databox setup
            List<String> columnData = new List<String>();
            this.listClients = trainer.clients;
            for (int i = 0; i < trainer.clients.Count; i++)
            {
                columnData.Add(trainer.clients[i].firstName + " " + trainer.clients[i].lastName);

            }

            this.LBLprofit.Text = cashOut(t);

            //tooltipRefresh();

            LBdata.DataSource = columnData;
            LBdata.Click += OnListBoxItemClick;
            LBdata.DoubleClick += new EventHandler(LBdata_DoubleClick);



        }

        //Client Form
        public AderantFitBaseForm(Client c, Trainer t)
            : this()
        {
            InitializeComponent();
            this.Width = 476;
            this.client = c;
            this.trainer = t;
            this.formType = 2;
            this.Text = "Client: " + client.firstName;
            this.BTNschedule.Text = "Details";
            this.CBsession.Hide();
            this.CBtotal.Checked = true;
            this.CBtotal.Enabled = false;
            this.LBLlistbox.Text = Resources.sessionList + ":";
            this.BTNup.Hide();
            this.BTNdown.Hide();
            this.BTNadd.Text = Resources.addSession;
            this.BTNedit.Text = "Remove Session";

            List<String> columnData = new List<String>();
            this.listSessions = client.sess;

            //Hide Filter
            this.TBinput4.Hide();
            this.LBLfilter.Hide();
            this.TBinput5.Hide();
            this.LBLinput4.Hide();
            this.LBLinput5.Hide();

            for (int i = 0; i < client.sessCount; i++)
            {
                columnData.Add("Session " + (i + 1));

            }
            LBdata.DataSource = columnData;
            LBdata.Click += OnListBoxItemClick;
            LBdata.DoubleClick += new EventHandler(LBdata_DoubleClick);
            this.LBLprofit.Text = (t.rate * c.sessCount).ToString();


        }

        //Refreshes Databox
        private void formRefresh()
        {
            if (formType == 1)
            {
                this.trainer = db.GetTrainer(trainer.usn);
                List<String> columnData = new List<String>();
                this.listClients = trainer.clients;
                for (int i = 0; i < trainer.clients.Count; i++)
                {
                    columnData.Add(trainer.clients[i].firstName + " " + trainer.clients[i].lastName);

                }

                LBdata.DataSource = columnData;
            }
            if (formType == 2)
            {
                string inquiry = client.firstName + " " + client.lastName;
                this.trainer = db.GetTrainer(trainer.usn);
                var result2 = listClients.Where(cl =>
                    (cl.firstName + " " + cl.lastName) == inquiry).FirstOrDefault();

                if (result2 != null)
                {
                    this.client = result2;
                    List<String> columnData = new List<String>();
                    client.sessCount = client.sessCount - 1;
                    for (int i = 0; i < client.sessCount; i++)
                    {
                        columnData.Add("Session " + (i + 1));

                    }
                    LBdata.DataSource = columnData;
                    this.LBLprofit.Text = (trainer.rate * client.sessCount).ToString();
                }
                
            }
        }
        //Configures Tooltips
        private void tooltipRefresh()
        {
            
            this.ratetip0.SetToolTip(LBLprofit, "Your rate is: " + this.trainer.rate);
            this.ratetip1.SetToolTip(LBLrate, "Your rate is: " + this.trainer.rate);
            this.ratetip2.SetToolTip(BTNup, "Your rate is: " + this.trainer.rate);
            this.ratetip3.SetToolTip(BTNdown, "Your rate is: " + this.trainer.rate);
            

        }

        //Reusable Clear Form
        public void clearForm()
        {
            TBinput4.Text = "";
            TBinput5.Text = "";
            this.CBtotal.Checked = true;
            LBdata.ClearSelected();
        }

        //Calculate Profit
        public string cashOut(Trainer t)
        {
            double i = 0;
            if (this.CBtotal.Checked)
            {
                var cashOut = from client in listClients
                              select new { sessCount = client.sessCount };

                foreach (var item in cashOut)
                {
                    i = i + (item.sessCount * t.rate);
                }
                return i.ToString();
            }
            else
            {
                var cashOut = from client in listClients
                              where (client.firstName + " " + client.lastName).Equals(LBdata.SelectedItem)
                              select new { sessCount = client.sessCount };

                foreach (var item in cashOut)
                {
                    i = i + (item.sessCount * t.rate);
                }
                return i.ToString();
            }
        }


        /**
         * 
         * 
         * Section Below pertains to Buttons and their Functions
         * 
         * 
         * **/

        //Shows Schedule of Client or Details of a session
        private void BTNschedule_Click(object sender, EventArgs e)
        {
            if (formType == 1)
            {
                var result2 = listClients.Where(cl =>
                    (cl.firstName + " " + cl.lastName) == LBdata.SelectedItem.ToString()).FirstOrDefault();

                if (result2 != null)
                {
                    Form clientForm = new AderantFitBaseForm(result2, this.trainer);
                    clientForm.Show();
                    this.Hide();
                    clientForm.FormClosed += (senders, args) => this.Show();
                    this.formRefresh();
                  //  this.LBLprofit.Text = (trainer.rate * client.sessCount).ToString();
                }
                else
                {
                    MessageBox.Show("No client selected! Please add or select one", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (formType == 2)
            {
                if (LBdata.SelectedItem != null)
                {
                    string details = "Workout Details: \n";
                    int selection = LBdata.SelectedIndex + 1;
                    var selSessions = from session in listSessions
                                      where session.session_num == selection
                                      select new { workoutName = session.workoutName, numReps = session.numReps, numSets = session.numSets, exerciseWeight = session.exerciseWeight };
                    int i = 0;
                    foreach (var item in selSessions)
                    {
                        if (i == 0)
                        {
                            details = details + "\n" + "Workout Name" + "\tReps" + "\tSets" + "\tWeight\n";
                            details = details + "  " + item.workoutName + "\t" + item.numReps + "\t" + item.numSets + "\t" + item.exerciseWeight + "\n";
                            i = i + 1;
                        }
                        else
                        {
                            details = details + "  " + item.workoutName + "\t" + item.numReps + "\t" + item.numSets + "\t" + item.exerciseWeight + "\n";
                        }
                    }

                    MessageBox.Show(details, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //Adds a Client or Session depending on form type
        private void BTNadd_Click(object sender, EventArgs e)
        {

            if (formType == 1)
            {
                Client client = new Client(this.trainer.trainer_uno);
                ClientModal clientForm = new ClientModal(client);
                clientForm.ShowDialog();
                formRefresh();

            }
            if (formType == 2)
            {
                Session session = new Session();
                session.client_code = client.client_uno;
                int seshNum = LBdata.SelectedIndex+1;
                if ((LBdata.SelectedItem == null)) { seshNum = this.client.sessCount + 1; }
                SessionModal sessionForm = new SessionModal(session, seshNum);
                if (sessionForm.ShowDialog() == DialogResult.OK)
                {
                    formRefresh();
                    this.client.sessCount = seshNum;
                    listSessions.Add(session);
                    List<String> columnData = new List<String>();

                    for (int i = 0; i < this.client.sessCount;i++ )
                    {
                        columnData.Add("Session " + (i + 1));
                    }
                   
                    LBdata.DataSource = columnData;
                    this.LBLprofit.Text = (trainer.rate * client.sessCount).ToString();
                         
                }

            }
            clearForm();
        }



        //Remove a Client or Session depending on form type
        private void BTNremove_Click(object sender, EventArgs e)
        {
            if (formType == 1 && !(LBdata.SelectedItem == null))
            {
                var result2 = listClients.Where(cl =>
                    (cl.firstName + " " + cl.lastName) == LBdata.SelectedItem.ToString()).FirstOrDefault();

                if (result2 != null)
                {
                    ClientModal clientForm = new ClientModal(result2);
                    clientForm.ShowDialog();
                    formRefresh();
                    return;
                }
               
            }
            else if(formType==1)
            {
                MessageBox.Show("No client selected! Please add or select one", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (formType == 2 && !(LBdata.SelectedItem == null))
            {
                if (LBdata.SelectedItem != null)
                {
                    int remove = LBdata.SelectedIndex + 1;
                    db.DeleteWorkoutSession(client.client_uno, remove);
                    List<String> columnData = new List<String>();
                    client.sessCount = client.sessCount - 1;
                    for (int i = 0; i < client.sessCount; i++)
                    {
                        columnData.Add("Session " + (i + 1));

                    }
                    LBdata.DataSource = columnData;
                    this.LBLprofit.Text = (trainer.rate * client.sessCount).ToString();
                }
              
            }
            else if (formType == 2)
            {
                MessageBox.Show("No Session selected! Please add or select one", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clearForm();
        }


        /**
         * 
         * 
         * Section Below pertains to functions being utilized by another action/activity
         * 
         * 
         * **/

        //Function to expand details
        private void LBdata_DoubleClick(object sender, EventArgs e)
        {
            if (LBdata.SelectedItem != null)
            {
                if (formType == 1)
                {
                    Client result = listClients.Find(
                    delegate(Client cl)
                    {
                        return cl.firstName + " " + cl.lastName == LBdata.SelectedItem.ToString();
                    }
                    );

                    Form clientForm = new AderantFitBaseForm(result, trainer);
                    clientForm.Show();
                    this.Hide();
                    clientForm.FormClosed += (senders, args) => this.Show();
                }
                if (formType == 2)
                {
                    string details = "Workout Details: \n";
                    int selection = LBdata.SelectedIndex + 1;
                    var selSessions = from session in listSessions
                                      where session.session_num == selection
                                      select new { workoutName = session.workoutName, numReps = session.numReps, numSets = session.numSets, exerciseWeight = session.exerciseWeight };
                    int i = 0;
                    foreach (var item in selSessions)
                    {
                        if (i == 0)
                        {
                            details = details + "Workout Name" + "\tReps" + "\tSets" + "\tWeight\n";
                            details = details + "  " + item.workoutName + "\t" + item.numReps + "\t" + item.numSets + "\t" + item.exerciseWeight + "\n";
                            i = i + 1;
                        }
                        else
                        {
                            details = details + "  " + item.workoutName + "\t" + item.numReps + "\t" + item.numSets + "\t" + item.exerciseWeight + "\n";
                        }
                    }

                    MessageBox.Show(details, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        //Updates LBLprofit real time
        private void OnListBoxItemClick(object sender, EventArgs e)
        {
            if (formType == 1)
            {
                this.LBLprofit.Text = cashOut(this.trainer);
            }
            else
            {
                this.LBLprofit.Text = (trainer.rate * client.sessCount).ToString();
            }
        }


        private void TBinput4_TextChanged(object sender, EventArgs e)
        {
            List<String> columnData = new List<String>();
            if (formType == 1)
            {
                var filterName = from client in listClients
                                 where client.trainer_code == trainer.trainer_uno
                                 select new { firstName = client.firstName, lastName = client.lastName };
                foreach (var item in filterName)
                {
                    if (item.firstName.ToUpper().Contains(TBinput4.Text.ToUpper()) && item.lastName.ToUpper().Contains(TBinput5.Text.ToUpper()))
                    {
                        columnData.Add(item.firstName + " " + item.lastName);
                    }
                }
                LBdata.DataSource = columnData;
            }

        }

        //Key Press Reg Expression for Field Validation and filtering
        private void TBnames_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (formType == 1)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^[A-Za-z' '\b ]+$"))
                {
                    e.Handled = false;

                }
                else
                {
                    MessageBox.Show("This field only accepts alpha characters", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
            }
          
        }


        /**
         * 
         * 
         * Section Below pertains to updating rates
         * 
         * 
         * **/
        private void BTNup_Click(object sender, EventArgs e)
        {
            this.trainer.rate = this.trainer.rate + .5;
            //db.updateRate(this.trainer.rate, this.trainer.tID);
            this.LBLprofit.Text = cashOut(this.trainer);
            tooltipRefresh();
        }

        private void BTNdown_Click(object sender, EventArgs e)
        {
            this.trainer.rate = this.trainer.rate - .5;
            //db.updateRate(this.trainer.rate, this.trainer.tID);
            this.LBLprofit.Text = cashOut(this.trainer);
            tooltipRefresh();
        }

        //Check Validation and Rate refresh
        private void CBsession_CheckedChanged(object sender, EventArgs e)
        {
            CBtotal.Checked = !CBsession.Checked;

            this.LBLprofit.Text = cashOut(this.trainer);

        }

        private void CBtotal_CheckedChanged(object sender, EventArgs e)
        {
            CBsession.Checked = !CBtotal.Checked;

            this.LBLprofit.Text = cashOut(this.trainer);

        }

        private void BTNclear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void BTNdeselect_Click(object sender, EventArgs e)
        {
            LBdata.ClearSelected();
        }





    }
}
