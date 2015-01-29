using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AderantFit
{
    public class Client : Person
    {
        public int trainer_code { get; set; }
        public int client_uno { get; set; }
        public int sessCount { get; set; }
        public List<Session> sess { get; set; }

        public Client()
        {
            sess = new List<Session>();
            this.client_uno = 0;
            this.sessCount = 0;
        }

        public Client(int trainercode)
        {
            this.trainer_code = trainercode;
            this.sess = new List<Session>();
            this.client_uno = 0;
            this.sessCount = 0;
        }
    }

    

}
