using System;
using System.Net;

using Xamarin.Forms;

namespace Continents
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            Title = "Contact";
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        void OnSubmit()
        {
            if (String.IsNullOrEmpty(emailEntry.Text) ||
                String.IsNullOrEmpty(subjectEntry.Text) ||
                String.IsNullOrEmpty(bodyEntry.Text))
            {
                DisplayAlert("Error", "Please fill in all required sections. ", "OK");
            }
            else
            {
                var mail = DependencyService.Get<IEmailSender>();
                try
                {
                    mail.SendEmail("Mobile Contact Form: " + subjectEntry.Text, "Email: " + emailEntry.Text + "\n\n" + bodyEntry.Text);
                }
                catch (Exception e)
                {
                    DisplayAlert("Error", "Unable to send contact form. Please try again later. ", "OK");
                }
                emailEntry.Text = String.Empty;
                subjectEntry.Text = String.Empty;
                bodyEntry.Text = String.Empty;
            }
        }
    }
}
