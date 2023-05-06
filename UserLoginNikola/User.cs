using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginNikola
{
   public class User
    {
        public System.Int32 UserId { get; set; }
        public System.String username { get; set; }
        public System.String password { get; set; }
        //iskat taka System.String
        public System.Int32 fakNomer { get; set; }
        //iskat taka System.Int32
        public UserRoles role { get; set; }

        public System.DateTime created { get; set; }

        public System.DateTime? expiryDate { get; set; }




        public void toString()
        {
            Console.WriteLine(username+ " "+password+" "+ fakNomer+ " "+ role + " created on: "+ created + " Expiry date: "+expiryDate);
        }



    }
}
