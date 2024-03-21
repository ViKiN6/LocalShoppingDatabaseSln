using LocalShoppingDatabase.Models;
using LocalShoppingDatabase.Services;
using Microsoft.Maui;

namespace LocalShoppingDatabase;

public partial class ProfilePage : ContentPage
{
    private LocalDatabase _database;

    private Profile _currentProfile;
    public Profile CurrentProfile
    {
        get { return _currentProfile; }
        set
        {
            _currentProfile = value;
            OnPropertyChanged();
        }
    }
    public ProfilePage()
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
    public void LoadData() // Loading the data
    {
        Profile profile = _database.GetProfileByID(1);
        CurrentProfile = profile;
    }

    private void SaveProfile(object sender, EventArgs e)
    {
        //DisplayAlert("test", "button click works", "ok");
        _database.UpdateProfile(CurrentProfile); // Saving the data to the database but updating with new information
        nameEntry.Text = "";
        surnameEntry.Text = "";
        emailEntry.Text = "";
        
    }

    private void LoadProfile(object sender, EventArgs e) // Loading data on button clcik
    {
        //DisplayAlert("test", "is working", "ok");
        LoadData();
    }
}