using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AderantFit
{
    public interface IFitDB
    {
        int GetTrainerId(string username);
        int GetTrainerId(string fn,string ln);
        Trainer GetTrainer(string username);
        string SaveTrainer(Trainer trainer);
        string DeleteTrainer(int tID);

        int GetClientId(int personcode,int trainercode);
        string SaveClient(Client client);
        string DeleteClient(int clientuno);

        int GetWorkoutSessionId(Session session);
        string SaveWorkoutSession(Session session);
        string DeleteWorkoutSession(int clientcode, int sessionnum);

        bool AuthenticateUsernameAndPassword(string username, string password);
        

        void UpdateRate(double rate, int tID);
    }
}
