using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AderantFit
{
    public class Trainer : Person
    {
 
        public int trainer_uno { get; set; }
        public string usn { get; set; }
        public string pass { get; set; }
        public double rate { get; set; }
        public List<Client> clients { get; set; }

        public Trainer()
        {
            this.clients = new List<Client>();

        }
    }


}
