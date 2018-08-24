using System;
using System.Net;
using System.Net.Http;
using System.IO;

using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

using Xamarin.Forms;

using HtmlAgilityPack;

namespace Continents
{
    public partial class HelpPage : ContentPage
    {
        private WebView webView;

        public HelpPage()
        {
            InitializeComponent();
            Title = "FAQ";
            LoadFAQFromWebsite();

            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        public async void LoadFAQFromWebsite()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/page/faq-list/");

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("content-page"));
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("section-head")).Remove();

            var body = doc.DocumentNode.Descendants("body").FirstOrDefault();
            body.RemoveAllChildren();
            body.AppendChild(content);

            var htmlSource = new HtmlWebViewSource
            {
                Html = doc.DocumentNode.OuterHtml
            };

            webView = new WebView
            {
                Source = htmlSource
            };

            this.Content = webView;
        }
    }
}
