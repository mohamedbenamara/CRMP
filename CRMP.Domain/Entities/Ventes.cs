using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMP.Domain.Entities
{
    public class Ventes
    {
        public int VentesId { get; set; }
        public string typeVt { get; set; }
        public float valeurVt { get; set; }

        public int? StandId { get; set; }
        [ForeignKey("StandId")]
        public virtual Stand stand { get; set; }
    }
}
