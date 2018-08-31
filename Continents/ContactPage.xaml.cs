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
            if (String.IsNullOrEmpty(firstNameEntry.Text) ||
                String.IsNullOrEmpty(lastNameEntry.Text) ||
                String.IsNullOrEmpty(phoneEntry.Text) ||
                String.IsNullOrEmpty(countryEntry.Text) ||
                String.IsNullOrEmpty(cityEntry.Text) ||
                String.IsNullOrEmpty(emailEntry.Text) ||
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
                    mail.SendEmail("Mobile Contact Form Subject: " + subjectEntry.Text, 
                                   "Email: " + emailEntry.Text + "\n" +
                                   "First Name: " + firstNameEntry.Text + "\n" +
                                   "Last Name: " + lastNameEntry.Text + "\n" +
                                   "Phone: " + phoneEntry.Text + "\n" +
                                   "Country: " + countryEntry.Text + "\n" + 
                                   "City: " + cityEntry.Text + "\n\n" + bodyEntry.Text);
                }
                catch (Exception e)
                {
                    DisplayAlert("Error", "Unable to send contact form. Please try again later. ", "OK");
                }
                firstNameEntry.Text = String.Empty;
                lastNameEntry.Text = String.Empty;
                phoneEntry.Text = String.Empty;
                countryEntry.Text = String.Empty;
                cityEntry.Text = String.Empty;
                emailEntry.Text = String.Empty;
                subjectEntry.Text = String.Empty;
                bodyEntry.Text = String.Empty;
            }
        }
    }
}
