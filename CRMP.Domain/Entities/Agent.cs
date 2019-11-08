using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string NomAg { get; set; }
        public string prenomA { get; set; }
        public string adresseA { get; set; }
        public int ageA { get; set; }
        public float salaireA { get; set; }
        public string typeA { get; set; }
        public Agent()
        {

        }
    }
}
