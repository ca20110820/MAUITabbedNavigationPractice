using MainApplication.Models;
using Microsoft.Maui;
using System.Diagnostics;

namespace MainApplication
{
    public partial class MainPage : ContentPage
    {
        public List<PersonModel> People
        {
            get
            {
                App myApp = Application.Current as App;
                return myApp.People;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private async Task ClearForm()
        {
            await Task.Delay(250);
            entryId.Text = string.Empty;
            entryName.Text = string.Empty;
            entryAge.Text = string.Empty;
        }

        private async void btnEnter_Clicked(object sender, EventArgs e)
        {
            // Navigate to Another Page containing a Table View of Persons (updated with new data)

            // Check if ID already exists
            int id;
            if (int.TryParse(entryId.Text, out id))
            {
                bool personExists = PersonExists(id);
                if (personExists)
                {
                    await DisplayAlert("ID Exists", "ID already exists", "Ok");
                    await ClearForm();
                    return;
                }
            }
            else
            {
                await DisplayAlert("Invalid ID", "ID must be a valid integer!", "Ok");
                return;
            }
            // Check if Age is a valid integer
            int age;
            if (!int.TryParse(entryAge.Text, out age))
            {
                await DisplayAlert("Invalid Age", "Age must be a valid integer!", "Ok");
                return;
            }
            // Check if Name is Null or Empty
            if (string.IsNullOrEmpty(entryName.Text))
            {
                await DisplayAlert("Invalid Age", "Age must be a valid integer!", "Ok");
                return;
            }

            App myApp = (App)Application.Current;
            List<PersonModel> persons = myApp.People;
            persons.Add(new PersonModel { Id = id, Age = age , Name=entryName.Text});

            await ClearForm();

            // Navigate to Another Page
            await Shell.Current.GoToAsync("//PeoplePage");  // Go to the PeoplePage Tab
            PeoplePage peoplePage = (PeoplePage)Shell.Current.CurrentPage;
            peoplePage.SetPeople(persons);

            IReadOnlyList<Page> pageStack = Navigation.NavigationStack;
        }

        private bool PersonExists(int id)
        {
            return People.Where(p => p.Id == id).FirstOrDefault() != null;
        }
    }
}
