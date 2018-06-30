using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class SocialMediaPage : TabbedPage
    {
        public SocialMediaPage()
        {
            InitializeComponent();
            Title = "Social Media";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
