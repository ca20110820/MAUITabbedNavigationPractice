using MainApplication.Models;
using System.Diagnostics;

namespace MainApplication;

public partial class PeoplePage : ContentPage
{

	public List<PersonModel> People { get; private set; }

	public PeoplePage()
	{
		InitializeComponent();
    }

	public async Task UpdateUI()
	{
        /* Update the following:
         * ---------------------
         * - BindingContext, if applicable
         * - "Current" Selected Item in Context
         * - "Current" Collection of Items in Context
         * - UI (Manually or Data Binding)
         * 
         * Tips:
         * -----
         * - Use `Update` and `Setter` methods.
         */

        SetPeopleFromApp();
    }

    public void SetPeople(IEnumerable<PersonModel> people)
	{
        /* Use this method for manually updating the "current" list of person
		 */
        People = (List<PersonModel>)people;
		collectionviewPeople.ItemsSource = null;
        collectionviewPeople.ItemsSource = People;

        datagridPeople.ItemsSource = null;
        datagridPeople.ItemsSource = people;

    }
    private void SetPeopleFromApp()
    {
        App myApp = (App)Application.Current;
        if (myApp == null) return;

        //List<PersonModel> persons = myApp.People;
        SetPeople(myApp.People);
    }

    /* Event-Handler Methods */
    protected async override void OnAppearing()
    {
        await Task.Delay(250);
        base.OnAppearing();
        // Do whatever you want here
        Trace.WriteLine("We are now navigated to this PeoplePage ...");
        SetPeopleFromApp();
    }

    protected async override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        await Task.Delay(250);
        base.OnNavigatedFrom(args);
        // ...
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await Task.Delay(250);
        base.OnNavigatedTo(args);
        // ...
        // e.g. UpdateUI(args);
    }
}