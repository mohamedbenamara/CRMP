using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class UserProfil
    {
        public string UserProfilId { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public string userAddress { get; set; }
        public int userNum { get; set; }
        public int point { get; set; }
        public int solde { get; set; }
        public int internet { get; set; }
        [DataType(DataType.ImageUrl)]
        public string image { get; set; }

        public UserProfil()
        {

        }
    }
}
