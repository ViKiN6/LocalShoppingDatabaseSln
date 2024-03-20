using LocalShoppingDatabase.Models;
using LocalShoppingDatabase.Services;

namespace LocalShoppingDatabase;

public partial class ProfilePage : ContentPage
{

    private LocalDatabase _database;


    private Profile _currentProfile;
    public Profile _CurrentProfile;

    public  Profile CurrentUser
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
        public void LoadData() 
        {
            Profile profile = _database.LocalDatabase(1); // Assigning the user to a userid that was saved
            Profile = profile; // Assigning the user to the CurrentUser (will display on screen)
        }

    private void SaveProfile(object sender, EventArgs e)
    {

        Profile CurrentProfle = null;
        _database.UpdateProfile(CurrentProfle);
        nameEntry.Text = "Vicardo";
        surnameEntry.Text = "Kakora";
        emailEntry.Text = "vk@gmail.com";
    }

        private void LoadProfile(object sender, EventArgs e) 
        {
           
            LoadData();
        }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        
    }
}
