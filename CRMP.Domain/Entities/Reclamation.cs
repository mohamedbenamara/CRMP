using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRMP.Domain.Entities
{
    public class Reclamation
    {
        public int ReclamationId { get; set; }
        public string typeRec { get; set; }

        public string descRec { get; set; }

        public string responseRec { get; set; }
        public string etatRec { get; set; }

        public DateTime dataRec { get; set; }
        public String userId { get; set; }
       
        public virtual User user { get; set; }

        public Reclamation()
        {

        }
    }
}
