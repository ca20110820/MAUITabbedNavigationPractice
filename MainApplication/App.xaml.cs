using MainApplication.Models;
using System.Diagnostics;

namespace MainApplication
{
    public partial class App : Application
    {
        public List<PersonModel> People { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        private List<PersonModel> CreatePeople()
        {
            List<PersonModel> personModels = new List<PersonModel>()
            {
                CreatePerson(1, "Ced", 29),
                CreatePerson(2, "Terry", 43),
                CreatePerson(3, "Dave", 105)
            };
            return personModels;
        }
        private PersonModel CreatePerson(int id, string name, int age)
        {
            return new PersonModel { Id = id, Name = name, Age = age };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Trace.WriteLine("We are Starting the App ...");

            // Initialize People List
            Trace.WriteLine("Initializing People ...");
            People = CreatePeople();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Trace.WriteLine("App is sleeping ...");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Trace.WriteLine("We are Resuming the App ...");
        }
    }
}
