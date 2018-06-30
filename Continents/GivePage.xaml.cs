using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class GivePage : ContentPage
    {
        public GivePage()
        {
            InitializeComponent();
            Title = "Give";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
