using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMP.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }

        public string role { get; set; }
        public string gender { get; set; }

        public DateTime birthDate { get; set; }

        public string userAddress { get; set; }


        public int userNum { get; set; }
        public User()
        {

        }
    }
}
