using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
            Title = "Help and Feedback";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        async void OnFeedback()
        {
            await Navigation.PushAsync(new ContactPage());
        }
    }
}
