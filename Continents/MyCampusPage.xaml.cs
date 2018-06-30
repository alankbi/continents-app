using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class MyCampusPage : ContentPage
    {
        public MyCampusPage()
        {
            InitializeComponent();
            Title = "My Campus";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
