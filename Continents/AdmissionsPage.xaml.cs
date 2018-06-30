using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class AdmissionsPage : ContentPage
    {
        public AdmissionsPage()
        {
            InitializeComponent();
            Title = "Admissions";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
    }
}
