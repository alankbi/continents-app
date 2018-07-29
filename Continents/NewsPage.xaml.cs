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
    public partial class NewsPage : ContentPage
    {
        private WebView webView;

        public NewsPage()
        {
            InitializeComponent();
            Title = "Campus News";
            //LoadArticles();
            LoadArticlesFromWebsite();

            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        public async void LoadArticlesFromWebsite()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/news/");

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
                Source = htmlSource
            };

            ToolbarItems.Add(new ToolbarItem("<", null, () => { HandleBackButtonClicked(htmlSource); }));
            ToolbarItems.Add(new ToolbarItem(">", null, () => { webView.GoForward(); }));

            this.Content = webView;
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

        public async void LoadArticles()
        {
            var json = await WebsiteCaller.ExecuteCall("https://continents-6124.restdb.io/rest/news-articles");

            dynamic response = JArray.Parse(json);
            var result = response.ToObject<List<Article>>();

            foreach (Article article in result)
            {
                sLayout.Children.Add(new NewsView
                {
                    ImageUrl = article.ImageUrl,
                    InfoText = article.Body,
                    Title = article.Title,
                    Date = "Written on " + article.Date.ToString("D")
                });
            }
        }
    }
}
