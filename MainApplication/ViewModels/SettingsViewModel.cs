using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.ViewModels
{
    public class SettingsViewModel : BindableObject
    {
        private bool _darkModeSwitched;
        public bool DarkModeSwitched
        {
            get => _darkModeSwitched;
            set
            {
                if (_darkModeSwitched != value)
                {
                    _darkModeSwitched = value;
                    OnPropertyChanged();
                    // Handle dark mode switch logic here
                    // ...
                    Trace.WriteLine("DarkModeSwitched clicked ...");
                }
            }
        }

        private bool _notificationsSwitched;
        public bool NotificationsSwitched
        {
            get => _notificationsSwitched;
            set
            {
                if (_notificationsSwitched != value)
                {
                    _notificationsSwitched = value;
                    OnPropertyChanged();
                    // Handle notifications switch logic here
                    // ...
                    Trace.WriteLine("NotificationsSwitched clicked ...");
                }
            }
        }

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged();
                    // Handle language selection logic here
                    // ...
                    Trace.WriteLine($"Language changed to {value}");
                }
            }
        }


        public SettingsViewModel()
        {
            // Default Settings and Configurationss
            DarkModeSwitched = false; // Setting a default value for DarkModeSwitched
            NotificationsSwitched = true; // Setting a default value for NotificationsSwitched
            SelectedLanguage = "English"; // Setting a default value for SelectedLanguage
        }
    }

}
