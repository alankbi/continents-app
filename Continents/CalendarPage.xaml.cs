using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            Title = "Calendar";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
