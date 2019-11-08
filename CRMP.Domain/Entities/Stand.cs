using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMP.Domain.Entities
{
    public class Stand
    {
        public int StandId { get; set; }
        public string adresseSt { get; set; }
        public string typeSt { get; set; }
        public int? AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent agent { get; set; }
    }
}
