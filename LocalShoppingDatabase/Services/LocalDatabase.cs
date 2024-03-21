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
    internal class LocalDatabase
    {
        private SQLiteConnection _dbConnection;
        public string GetDatabasePath()
        {
            string fileName = "profiledatabase.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return pathToDb + fileName;
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
                    Name = "Vicardo",
                    Surname = "Kakora",
                    EmailAddress = "vk@gmail.com",

                };
                _dbConnection.Insert(profile);
            }

            // Shopping List Items
            if (_dbConnection.Table<ShoppingList>().Count() == 0)
            {
                List<ShoppingList> shoppingList = new List<ShoppingList>()
                {
                    new ShoppingList()
                    {
                        ListName = "Item",
                        ListQuantity = 1,
                        ListPrice = 1,

                    },
                    new ShoppingList()
                    {
                        ListName = "Item 2",
                        ListQuantity = 2,
                        ListPrice = 2,

                    },
                    new ShoppingList()
                    {
                        ListName = "Item 3",
                        ListQuantity = 13,
                        ListPrice = 3,

                    }
                };
                _dbConnection.InsertAll(shoppingList);
            }

            if (_dbConnection.Table<Cart>().Count() == 0)
            {
                Cart cart = new Cart();
            }
        }
        public void UpdateProfile(Profile profile)
        {
            _dbConnection.Update(profile);
        }

        public Profile GetProfileByID(int id)
        {
            Profile profile = _dbConnection.Table<Profile>().Where(x => x.ProfileID == id).FirstOrDefault();

            if (profile != null)
                _dbConnection.GetChildren(profile, true);

            return profile;
        }

        // Shopping List Methods
        public List<ShoppingList> GetAllList()
        {
            return _dbConnection.Table<ShoppingList>().ToList();
        }


        // Shopping Cart Methods
        public List<Cart> GetAllCartLists()
        {
            return _dbConnection.Table<Cart>().ToList();
        }


        // Insert Item from Shopping List to Cart
        //private List<ShoppingCart> cartItems = new List<ShoppingCart>();
        public void InsertToDatabase(Cart list)
        {
            _dbConnection.Insert(list);
        }


        // Remove Item From Cart
        public void RemoveFromCart(Cart listToRemove)
        {
            _dbConnection.Delete(listToRemove);
        }
    }
}