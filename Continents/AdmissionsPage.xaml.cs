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

            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"utf-8\"> <meta name=\"generator\" content=\"CoffeeCup HTML Editor (www.continents.us)\"> <meta name=\"dcterms.created\" content=\"Mon, 23 Jul 2018 10:58:53 GMT\"> <META HTTP-EQUIV=\"Content-type\" CONTENT=\"text/html; charset=UTF-8\"> <meta name=\"description\" content=\"\"> <meta name=\"keywords\" content=\"\"> <title></title> <style> .input { width: 90%; height: 35px; margin: 5px; border-radius: 0px; margin-bottom: 25px; } .input-text { font: 18px Verdana; margin-bottom: 8px; } .submit { -webkit-appearance: none; -webkit-border-radius:0; background-color: red; border: none; color: white; text-align: center; text-decoration: none; display: inline-block; font-size: 22px; border-radius: 0px; width: 95%; height: 50px; margin-left: 5px; } .test label, .test input { display: inline-block; } .container { margin: 10px; padding: 20px; background-color: #eaecee; height: 80vh; } </style> </head> <body> <div class=\"container\"> <h1 style=\"text-align: center; font-family: verdana; margin-bottom: 20px;\">Apply Now</h1> <form action=\"https://webto.salesforce.com/servlet/servlet.WebToLead?encoding=UTF-8\" method=\"POST\"> <input type=hidden name=\"oid\" value=\"00D1H000000N3my\"> <input type=hidden name=\"retURL\" value=\"https://www.continents.us/\"> <label class=\"input-text\" for=\"first_name\">First Name</label><br><input id=\"first_name\" maxlength=\"40\" name=\"first_name\" placeholder=\"First Name\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"last_name\">Last Name</label><br><input id=\"last_name\" maxlength=\"80\" name=\"last_name\" placeholder=\"Last Name\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"email\">Email</label><br><input id=\"email\" maxlength=\"80\" name=\"email\" placeholder=\"Email\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"phone\">Phone</label><br><input id=\"phone\" maxlength=\"40\" name=\"phone\" placeholder=\"Phone\" size=\"20\" type=\"text\" class=\"input\" /><br> <input type=\"submit\" name=\"submit\" class=\"submit\"> </form> </div> </body> </html>";
            browser.Source = htmlSource;
            this.Content = browser;

        }
    }
}
