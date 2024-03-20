using LocalShoppingDatabase.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalShoppingDatabase.Services
{
    public class LocalDatabase
    {
        private SQLiteConnection _dbConnection;

        public string GetDatabasePath()
        {
            string filename = "shoppingdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        public LocalDatabase()
        {

            _dbConnection = new SQLiteConnection(GetDatabasePath());

          
            _dbConnection.CreateTable<Profile>();
            _dbConnection.CreateTable<ShoppingList>();
            _dbConnection.CreateTable<Cart>();


            SeedDatabase();
        }

        public void SeedDatabase()
        {
            if (_dbConnection.Table<Profile>().Count() == 0)
            {

                Profile profile = new Profile()
                {
                    Name = "Vicardo";
                    Surname = "Kakora";
                    EmailAddress = "vk@gmail.com";
                };

                _dbConnection.Insert(profile);
            {

            }
            if (_dbConnection.Table<ShoppingList>().Count() == 0)
            {
                List<ShoppingList> shoppinglist = new List<ShoppingList>()
                {
                    new ShoppingList()
                    {
                        ItemName = "Item",
                        ItemQuantity = 1,
                        ItemPrice = 1,
                      
                    },
                    new ShoppingList()
                    {
                        ItemName = "Item 2",
                        ItemQuantity = 2,
                        ItemPrice = 2,
                    
                    },
                    new ShoppingList()
                    {
                        ItemName = "Item 3",
                        ItemQuantity = 3,
                        ItemPrice = 3,
                       
                    }
                };
                _dbConnection.InsertAll(shoppinglist);
            }

          
            if (_dbConnection.Table<Cart>().Count() == 0)
            {
                List<Cart> carts = new List<Cart>()
                {
                };
                _dbConnection.InsertAll(carts);
            }
        }
      
        public void UpdateProfile(Profile profile)
        {
            _dbConnection.Update(profile);
        }

        public Profile GetUserByID(int id)
        {
            Profile user = _dbConnection.Table<Profile>().Where(x => x.UserId == id).FirstOrDefault();

            if (user != null)
                _dbConnection.GetChildren(user, true);

            Profile profile = null;
            return profile;
        }


        // Shopping List Methods
        public List<ShoppingList> GetAllItems()
        {
            return _dbConnection.Table<ShoppingList>().ToList();
        }


        // Shopping Cart Methods
        public List<Cart> GetAllCartItems()
        {
            return _dbConnection.Table<Cart>().ToList();
        }


        // Insert Item from Shopping List to Cart
        public void InsertToCart(string name, decimal amount, int quantity, string images)
        {
            var newItem = new Cart
            {
                NameOfItem = name,
                ItemAmount = quantity,
                CartTotal = amount,
            
            };

            if (newItem.NameOfItem == "John Doe")
            {

            }
            _dbConnection.Insert(newItem);
        }
        // Display Error Message here..


        // Remove Item From Cart
        public void RemoveFromCart(Cart itemToRemove)
        {
            _dbConnection.Delete(itemToRemove);
        }
    }
}