using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Continents
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            Title = "Continents State University";
            NavigationPage.SetBackButtonTitle(this, "Back");
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Red;
            BackgroundImage = "about_image.jpg";
        }

        async void OnNews()
        {
            await Navigation.PushAsync(new NewsPage());
        }

        async void OnAdmissions()
        {
            await Navigation.PushAsync(new AdmissionsPage());
        }

        async void OnCalendar()
        {
            await Navigation.PushAsync(new CalendarPage());
        }

        async void OnMyCampus()
        {
            await Navigation.PushAsync(new MyCampusPage());
        }

        async void OnGallery()
        {
            await Navigation.PushAsync(new GalleryPage());
        }

        async void OnGive()
        {
            await Navigation.PushAsync(new GivePage());
        }

        async void OnContact()
        {
            await Navigation.PushAsync(new ContactPage());
        }

        async void OnSocialMedia()
        {
            await Navigation.PushAsync(new SocialMediaPage());
        }

        async void OnHelp()
        {
            await Navigation.PushAsync(new HelpPage());
        }
    }
}