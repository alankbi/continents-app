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
    public partial class AccreditationsPage : ContentPage
    {
        private WebView webView;

        public AccreditationsPage()
        {
            InitializeComponent();
            Title = "Accreditations";
            LoadAccreditationsFromWebsite();

            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        public async void LoadAccreditationsFromWebsite()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/partners/");

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("content-page"));
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("section-head")).Remove();

            var body = doc.DocumentNode.Descendants("body").FirstOrDefault();
            body.RemoveAllChildren();
            body.AppendChild(content);

            var htmlSource = new HtmlWebViewSource
            {
                Html = doc.DocumentNode.OuterHtml
            };

            webView = new WebView
            {
                Source = htmlSource,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            ToolbarItems.Add(new ToolbarItem("<", null, () => { HandleBackButtonClicked(htmlSource); }));
            ToolbarItems.Add(new ToolbarItem(">", null, () => { webView.GoForward(); }));

            var sLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            sLayout.Children.Add(webView);
            sLayout.Children.Add(new Label
            {
                Text = "© The Continents Foundation",
                Style = (Style) Application.Current.Resources["copyright"]
            });

            this.Content = sLayout;
        }

        void HandleBackButtonClicked(HtmlWebViewSource defaultPage)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                webView.Source = defaultPage;
            }
        }
    }
}
