using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMP.Domain.Entities
{
    public class Vehicule
    {

        public int VehiculeId { get; set; }

        public string typeVh { get; set; }
        public int? AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent agent { get; set; }
    }
}
