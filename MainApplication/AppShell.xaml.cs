namespace MainApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // Add Logic when Navigating To PeoplePage (regardless of the Page origin or source)
            // ...
        }
    }
}