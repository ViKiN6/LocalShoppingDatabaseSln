using LocalShoppingDatabase.Models;
using LocalShoppingDatabase.Services;
using System.Collections.ObjectModel;

namespace LocalShoppingDatabase;

public partial class ShoppingList: ContentPage
{
    private LocalDatabase _database;

    private ObservableCollection<Cart> _cartitems;
    public ObservableCollection<Cart> CartItems
    {
        get { return _cart; }
        set
        {
            _cartitems = value;
            OnPropertyChanged();
        }
    }
    public ShoppingList()
    {
        InitializeComponent();
        _database = new LocalDatabase();
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    public void LoadData()
    {
        // Returns a list from the database with all data and displays in one the screen
        CartItems = new ObservableCollection<Cart>(_database.GetAllCartItems());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter as Cart;

        if (selectedItem != null)
        {
            CartItems.Remove(selectedItem);
            _database.RemoveFromCart(selectedItem);
        }
    }
}