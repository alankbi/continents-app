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
            Title = "FAQ";
            NavigationPage.SetBackButtonTitle(this, "Back");
            this.Content = new WebView
            {
                Source = "https://continents.us/faqs"
            };
        }

        async void OnFeedback()
        {
            await Navigation.PushAsync(new ContactPage());
        }
    }
}
