using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMP.Domain.Entities
{
    public class Pack
    {
        public int PackId { get; set; }
        public string packName { get; set; }

        public string packDesc { get; set; }
        public string packPrice { get; set; }
        public string packImage { get; set; }

        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual User product { get; set; }
        public int? OfferId { get; set; }
        [ForeignKey("OfferId")]
        public virtual Offer offer { get; set; }
    }
}
