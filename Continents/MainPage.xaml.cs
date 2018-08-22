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
            Title = "Welcome to the Continents!";
            NavigationPage.SetBackButtonTitle(this, "Back");
            //BackgroundImage = "continents_logo.png";
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

        async void OnAccreditation()
        {
            await Navigation.PushAsync(new AccreditationsPage());
        }

        async void OnPartners()
        {
            await Navigation.PushAsync(new PartnersPage());
        }

        async void OnProjects()
        {
            await Navigation.PushAsync(new ProjectsPage());
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