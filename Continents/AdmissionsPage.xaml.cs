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
            htmlSource.Html = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"utf-8\"> <meta name=\"generator\" content=\"CoffeeCup HTML Editor (www.continents.us)\"> <meta name=\"dcterms.created\" content=\"Mon, 23 Jul 2018 10:58:53 GMT\"> <META HTTP-EQUIV=\"Content-type\" CONTENT=\"text/html; charset=UTF-8\"> <meta name=\"description\" content=\"\"> <meta name=\"keywords\" content=\"\"> <title></title> <style> .input { width: 100%; height: 20px; margin: 5px; } .input-text { font: 16px Verdana; } .submit { background-color: red; border: none; color: white; padding: 10px 20px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; border-radius: 6px; } .test label, .test input { display: inline-block; } </style> </head> <body> <form action=\"https://webto.salesforce.com/servlet/servlet.WebToLead?encoding=UTF-8\" method=\"POST\"> <input type=hidden name=\"oid\" value=\"00D1H000000N3my\"> <input type=hidden name=\"retURL\" value=\"https://www.continents.us/\"> <label class=\"input-text\" for=\"first_name\">First Name</label><input id=\"first_name\" maxlength=\"40\" name=\"first_name\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"last_name\">Last Name</label><input id=\"last_name\" maxlength=\"80\" name=\"last_name\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"email\">Email</label><input id=\"email\" maxlength=\"80\" name=\"email\" size=\"20\" type=\"text\" class=\"input\" /><br> <label class=\"input-text\" for=\"phone\">Phone</label><input id=\"phone\" maxlength=\"40\" name=\"phone\" size=\"20\" type=\"text\" class=\"input\" /><br> <input type=\"submit\" name=\"submit\" class=\"submit\"> </form> </body> </html>";
            browser.Source = htmlSource;
            this.Content = browser;

        }
    }
}
