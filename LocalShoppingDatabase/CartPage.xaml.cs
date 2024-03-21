using LocalShoppingDatabase. Models;
using LocalShoppingDatabase.Services;
using System.Collections.ObjectModel;

namespace LocalShoppingDatabase;

public partial class CartPage : ContentPage
{
    private LocalDatabase _database;

    private ObservableCollection<Cart> _cartlist;
    public ObservableCollection<Cart> CartList
    {
        get { return _cartlist; }
        set
        {
            _cartlist = value;
            OnPropertyChanged();
        }
    }
    public CartPage()
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
        
        CartList = new ObservableCollection<Cart>(_database.GetAllCartList());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter as Cart;

        if (selectedItem != null)
        {
            CartList.Remove(selectedItem);
            _database.RemoveFromCart(selectedItem);
        }
    }
}
