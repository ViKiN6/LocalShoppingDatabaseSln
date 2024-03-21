using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalShoppingDatabase.Models
{

        public class Profile
        {
            [PrimaryKey, AutoIncrement]
            public int ProfileID{ get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }

            [OneToOne]
            public Cart cart{ get; set; }
        }


}



