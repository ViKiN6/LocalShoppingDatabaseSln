using LocalShoppingDatabase.Models;
using LocalShoppingDatabase.Services;
using System.Collections.ObjectModel;

namespace LocalShoppingDatabase;

public partial class ShoppingListPage: ContentPage
{
    private LocalDatabase _database;

    private ObservableCollection<ShoppingList> _list;
    public ObservableCollection<ShoppingList> List
    {
        get { return _list; }
        set
        {
            _list = value;
            OnPropertyChanged();
        }
    }

    private int _itemamount;

    public int ItemAmounts
    {
        get { return _itemamount; }
        set { _itemamount = value; }
    }

    private decimal _carttotal;

    public decimal CartTotals
    {
        get { return _carttotal; }
        set { _carttotal = value; }
    }


    public ShoppingListPage()
    {
        InitializeComponent();
        _database = new LocalDatabase();
        BindingContext = this;
        //ItemsList.ItemsSource = GetAllItems();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    public void LoadData()
    {
        //ShoppingItems items = _database.GetItemByID(1);
        //CurrentItem = items;
        List = new ObservableCollection<ShoppingList>(_database.GetAllList());
    }


    private List<Cart> cartList = new List<Cart>();
    private void Button1(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter as ShoppingList;

        if (selectedItem != null)
        {
            Cart existingItem = cartList.FirstOrDefault(i => i.ItemID == selectedItem.ItemID);
            if (existingItem != null)
            {
                // updating the price and the qauntity in the cart
                existingItem.ItemAmount++;
                existingItem.CartTotal += selectedItem.ListPrice;
            }
            else
            {
                // if item doesnt exist
                Cart shoppingCart = new Cart()
                {
                    NameOfItem = selectedItem.ListName,
                    ItemAmount = 1,
                    CartTotal = selectedItem.ListPrice,
                    ItemID = selectedItem.ItemID
                };
                cartList.Add(shoppingCart);
                _database.InsertToDatabase(shoppingCart);
            }
            DisplayAlert("Cart", "Item Added To Cart", "Done");
        }
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Does the exact some thing the button does
        if (e.SelectedItem != null)
        {
            var selectedItem = e.SelectedItem as Cart;

            string itemName = selectedItem.NameOfItem;
            decimal itemPrice = selectedItem.CartTotal;
            int itemQuantity = selectedItem.ItemAmount;
          

            //InsertToCart();
        }
    }
}