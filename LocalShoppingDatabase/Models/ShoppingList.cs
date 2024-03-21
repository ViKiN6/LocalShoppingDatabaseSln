using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalShoppingDatabase.Models
{
    public class ShoppingList
    {
        [PrimaryKey, AutoIncrement]
        public int ItemID { get; set; }
        public string ListName { get; set; }
        public int ListQuantity { get; set; }
        public decimal ListPrice { get; set; }
       

        [ForeignKey(typeof(Cart))]
        public int CartID { get; set; } 
    }
}
