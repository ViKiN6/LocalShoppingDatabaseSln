
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalShoppingDatabase.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int CartID { get; set; }
        public int ItemAmount { get; set; }
        public decimal CartTotal { get; set; }
        public string NameOfItem { get; set; }

        [ForeignKey(typeof(ShoppingList))]
        public int ItemID { get; set; } 

        [ForeignKey(typeof(Profile))]
        public int Name { get; set; }
       
        [OneToOne]
        public Profile profile { get; set; }
    }
}