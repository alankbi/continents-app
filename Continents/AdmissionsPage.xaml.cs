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

            var browser = new WebView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"utf-8\"> <meta name=\"generator\" content=\"CoffeeCup HTML Editor (www.continents.us)\"> <meta name=\"dcterms.created\" content=\"Mon, 23 Jul 2018 10:58:53 GMT\"> <META HTTP-EQUIV=\"Content-type\" CONTENT=\"text/html; charset=UTF-8\"> <meta name=\"description\" content=\"\"> <meta name=\"keywords\" content=\"\"> <title></title> <style> .input { width: 90%; height: 35px; margin: 5px; border-radius: 0px; margin-bottom: 20px; } .input-text { font: 18px Verdana; margin-bottom: 6px; } .submit { -webkit-appearance: none; -webkit-border-radius:0; background-color: red; border: none; color: white; text-align: center; text-decoration: none; display: inline-block; font-size: 22px; border-radius: 3px; width: 90%; height: 50px; margin: 0 auto; } .test label, .test input { display: inline-block; } .container { margin: 10px; margin-top: 20px; padding: 20px; padding-top: 10px; background-color: #eaecee; height: 100vh; text-align: center; } </style> </head> <body> <div class=\"container\"> <h2 style=\"text-align: center; font-family: verdana; margin-bottom: 20px;\">Apply Now</h2> <form action=\"https://webto.salesforce.com/servlet/servlet.WebToLead?encoding=UTF-8\" method=\"POST\"> <input type=hidden name=\"oid\" value=\"00D1H000000N3my\"> <input type=hidden name=\"retURL\" value=\"https://www.continents.us/\"> <p>Complete this form to receive our school catalog and admission information. An enrollment counselor who specializes in your area of study will contact you soon to answer your questions.</p> <br> <input id=\"first_name\" maxlength=\"40\" name=\"first_name\" placeholder=\"First Name\" size=\"20\" type=\"text\" class=\"input\" /> <br> <input id=\"last_name\" placeholder=\"Last Name\" maxlength=\"80\" name=\"last_name\" size=\"20\" type=\"text\" class=\"input\" /><br><input id=\"email\" maxlength=\"80\" name=\"email\" placeholder=\"Email\" size=\"20\" type=\"text\" class=\"input\" /><br> <input id=\"phone\" maxlength=\"40\" name=\"phone\" placeholder=\"Phone\" size=\"20\" type=\"text\" class=\"input\" /><br> <p>We respect your privacy. By providing your information, you consent to The Continents Foundation and its subdivisions sending you occasional communications and special promotions when available.</p> <br> <input type=\"submit\" name=\"submit\" class=\"submit\"> </form> </div> </body> </html>";
            browser.Source = htmlSource;

            var sLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            sLayout.Children.Add(browser);
            sLayout.Children.Add(new Label
            {
                Text = "© The Continents Foundation",
                Style = (Style)Application.Current.Resources["copyright"]
            });

            this.Content = sLayout;
        }
    }
}
