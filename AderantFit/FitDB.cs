using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AderantFit
{
    public class FitDB : IFitDB
    {
        //Constant Connection String
        const string connStr = "Server=(local);" +
                                "Database=AderantFit;" +
                                "trusted_connection= true;" +
                                "integrated security= true;" +
                                "Connect Timeout=1000;";


        /*
        * 
        * 
        * Trainer Interface Implementation
        * 
        * 
        * 
        * */
        //Gets Trainer
        public int GetTrainerId(string fn, string ln)
        {

            string query = "Select Trainer_Uno FROM dbo.AF_Trainer Where Person_Code= " + getPerson(fn, ln);
            DataTable result = getDataTable(query);
            using (result)
            {
                if (result.Rows.Count != 0) { return Convert.ToInt32(result.Rows[0]["Trainer_Uno"]); }
                return 0;
            }

        }

        //Gets Trainer
        public int GetTrainerId(string username)
        {
            string query = "Select Trainer_Uno FROM dbo.AF_Trainer Where usn= '" + username + "'";
            DataTable result = getDataTable(query);
            using (result)
            {
                if (result.Rows.Count != 0) { return Convert.ToInt32(result.Rows[0]["Trainer_Uno"]); }
                return 0;
            }

        }

        public Trainer GetTrainer(string username)
        {

            DataTable trainerTable, clientTable, sessionTable, personTable = new DataTable();
            string query = "Select Trainer_Uno, Usn, Pass, Person_Code,Rate FROM dbo.AF_Trainer Where Usn= '" + username + "'";
            Trainer trainer = new Trainer();
            trainerTable = getDataTable(query);
            //Creates trainer and sets attribute
            trainer.trainer_uno = Convert.ToInt32(trainerTable.Rows[0]["Trainer_Uno"]);
            trainer.usn = Convert.ToString(trainerTable.Rows[0]["Usn"]);
            trainer.pass = Convert.ToString(trainerTable.Rows[0]["Pass"]);
            trainer.rate = Convert.ToDouble(trainerTable.Rows[0]["Rate"]);
            trainer.person_uno = Convert.ToInt32(trainerTable.Rows[0]["Person_Code"]);


            //Query Its Identity
            query = "Select FirstName, LastName From dbo.AF_Person (NOLOCK) Where Person_Uno = " + trainer.person_uno.ToString();
            personTable = getDataTable(query);
            trainer.firstName = Convert.ToString(personTable.Rows[0]["FirstName"]);
            trainer.lastName = Convert.ToString(personTable.Rows[0]["LastName"]);

            //Query Clients (Iteratively)
            query = "Select Person_Code, Client_Uno From AF_Client Where Trainer_Code=" + trainer.trainer_uno.ToString();
            clientTable = getDataTable(query);
            if (clientTable != null)
            {
                for (int i = 0; i < clientTable.Rows.Count; i++)
                {

                    Client client = new Client();
                    client.person_uno = Convert.ToInt32(clientTable.Rows[i]["Person_Code"]);
                    client.trainer_code = trainer.trainer_uno;
                    client.client_uno = Convert.ToInt32(clientTable.Rows[i]["Client_Uno"]);

                    query = "Select FirstName, LastName From dbo.AF_Person (NOLOCK) Where Person_Uno = " + client.person_uno.ToString();
                    personTable = getDataTable(query);
                    client.firstName = Convert.ToString(personTable.Rows[0]["FirstName"]);
                    client.lastName = Convert.ToString(personTable.Rows[0]["LastName"]);

                    //Query Sessions
                    query = "Select Session_Uno, Session_Num, Workout_Name, NumReps, NumSets, ExerciseWeight From AF_Session Where Client_Code = '" + client.client_uno + "'";
                    sessionTable = getDataTable(query);
                    //Iterates through rows shown and builds sessions
                    foreach (DataRow dr2 in sessionTable.Rows)
                    {
                        Session session = new Session();
                        session.session_uno = Convert.ToInt32(dr2["Session_Uno"]);
                        if (dr2["NumSets"] != DBNull.Value)
                        {
                            session.numSets = Convert.ToInt32(dr2["NumSets"]);
                        }
                        if (dr2["NumReps"] != DBNull.Value)
                        {
                            session.numReps = Convert.ToInt32(dr2["NumReps"]);
                        }
                        if (dr2["ExerciseWeight"] != DBNull.Value)
                        {
                            session.exerciseWeight = Convert.ToInt32(dr2["ExerciseWeight"]);
                        }
                        session.session_num = Convert.ToInt32(dr2["Session_Num"]);
                        session.workoutName = Convert.ToString(dr2["Workout_Name"]);
                        client.sess.Add(session);
                    }

                    query = "Select Distinct Session_Num FROM AF_Session Where Client_Code = '" + client.client_uno + "' GROUP BY Session_Num";
                    sessionTable = getDataTable(query);
                    client.sessCount = sessionTable.Rows.Count;
                    trainer.clients.Add(client);
                }

            }

            return trainer;
        }

        //Creates a Trainer
        public string SaveTrainer(Trainer trainer)
        {
            string query;
            if (String.IsNullOrEmpty(trainer.firstName) || String.IsNullOrEmpty(trainer.lastName) || String.IsNullOrEmpty(trainer.usn) || String.IsNullOrEmpty(trainer.pass))
            {
                return "One or more required fields are empty!";
            }
            if (getPerson(trainer.firstName, trainer.lastName) == 0)
            {
                query = "INSERT INTO AF_PERSON (FirstName,LastName) VALUES ('" + trainer.firstName + "','" + trainer.lastName + "')";
                execQuery(query);
            }
            query = "INSERT INTO AF_TRAINER (Usn,Pass,Person_Code,Rate) VALUES ('" + trainer.usn + "','" + trainer.pass + "', " + getPerson(trainer.firstName, trainer.lastName) + ", 20.0)";
            execQuery(query);
            return "Successfully created Trainer";
        }

        //To be Implemented (No)
        public string DeleteTrainer(int tID)
        {
            return "";
        }

        /*
         * 
         * 
         * Client Interface Implementation
         * 
         * 
         * 
         * */


        //Gets Client
        public int GetClientId(int personcode, int trainercode)
        {
            string query = "Select Client_Uno FROM dbo.AF_Client Where Person_Code=" + personcode + " AND Trainer_Code=" + trainercode;
            DataTable result = getDataTable(query);
            using (result)
            {
                if (result.Rows.Count != 0) { return Convert.ToInt32(result.Rows[0]["Client_Uno"]); }
                return 0;
            }
        }

        //Insert or Update for Client
        public string SaveClient(Client client)
        {
            string query;
            if (String.IsNullOrEmpty(client.firstName) || String.IsNullOrEmpty(client.lastName))
            {
                return "One or more required fields are empty!";
            }

            //If has a client UNO, is a client and Update Performed
            if (client.client_uno != 0)
            {
                query = "UPDATE AF_Person Set FirstName='" + client.firstName + "', LastName='" + client.lastName + "' WHERE Person_Uno= " + client.person_uno;
                execQuery(query);
                return "Successfully edited Client";
            }
            else
            {
                if (getPerson(client.firstName, client.lastName) == 0)
                {
                    query = "INSERT INTO AF_PERSON (FirstName,LastName) VALUES ('" + client.firstName + "','" + client.lastName + "')";
                    execQuery(query);
                }
                if (GetClientId(getPerson(client.firstName, client.lastName), client.trainer_code) == 0)
                {
                    query = "INSERT INTO AF_Client (Person_Code,Trainer_Code) VALUES (" + getPerson(client.firstName, client.lastName) + "," + client.trainer_code + ")";
                    execQuery(query);
                    return "Successfully created Client";
                }
                return "Person already a client";

            }

        }

        //Deletes Client
        public string DeleteClient(int clientuno)
        {
            string query = "Delete FROM AF_Client WHERE Client_Uno=" + clientuno;
            execQuery(query);
            return "Client Successfully Deleted";
        }

        /*
         * 
         * 
         * Session Interface Implementation
         * 
         * 
         * */
        public int GetWorkoutSessionId(Session session)
        {
            return 0;
        }
        public string SaveWorkoutSession(Session session)
        {
            string s1, s2, s3;
            if (session.numReps >= 0)
            {
                s1 = session.numReps.ToString();
            }
            else
            {
                s1 = "NULL";
                
            }
            if (session.numSets >= 0)
            {
                s2 = session.numSets.ToString();
            }
            else
            {
                s2 = "NULL";
                
            }
            if (session.exerciseWeight >=0)
            {
                s3 = session.exerciseWeight.ToString();
            }
            else
            {
                s3 = "NULL";
                
            }
            string query = "Insert INTO AF_SESSION (Session_Num,Workout_Name,NumReps,NumSets,ExerciseWeight,Client_Code) VALUES(" + session.session_num + ",'" + session.workoutName + "'," + s1 + "," + s2 + "," + s3 + "," + session.client_code + ")";
            execQuery(query);
            return "Success";
        }
        public string DeleteWorkoutSession(int clientcode, int sessionnum)
        {
            string query = "Delete FROM AF_Session WHERE Client_Code=" + clientcode + " AND Session_Num=" + sessionnum;
            execQuery(query);
            return "Session Successfully Deleted";
        }





        //Checks username / password Returns boolean
        public bool AuthenticateUsernameAndPassword(string username, string password)
        {
            string query = "Select Usn FROM dbo.AF_Trainer Where Usn= '" + username + "' AND Pass='" + password + "'";
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Load(dr);
                    }
                }
            }
            using (result)
            {
                if (result.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Get Person ID -- If 0 does not exist.
        private int getPerson(string firstname, string lastname)
        {
            string query = "Select FirstName, LastName, Person_Uno FROM dbo.AF_Person Where FirstName= '" + firstname + "' AND LastName= '" + lastname + "'";
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Load(dr);
                    }
                }
            }
            using (result)
            {
                if (result.Rows.Count == 1)
                {
                    return Convert.ToInt32(result.Rows[0]["Person_Uno"]);
                }
                else
                {
                    return 0;
                }
            }

        }

        //UPDATES Rate of Trainer
        public void UpdateRate(double rate, int tID)
        {
            string query = "UPDATE AF_Trainer Set Rate=" + rate.ToString() + " WHERE Trainer_Code= " + tID.ToString();
            execQuery(query);
        }


        //INQUIRY SQL METHOD
        private DataTable getDataTable(string query)
        {

            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Load(dr);
                    }
                }
            }

            return result;
        }

        //EXEC NONQUERY
        private void execQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}
