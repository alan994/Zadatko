using Xamarin.Forms;
using Zadatko.Helpers;
using Zadatko.Pages;
using Zadatko.Services;

namespace Zadatko
{
    public class App : Application
    {
        public static DataService DataService { get; set; }

        public App()
        {
            DataService = new DataService();

            if (Settings.Accepted)
            {
                MainPage = new NavigationPage(new ZadatkoTabbedPage());
            }
            else
            {
                MainPage = new NavigationPage(new FirstPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
