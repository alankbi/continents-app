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
        public NewsPage()
        {
            InitializeComponent();
            Title = "Campus News";
            //LoadArticles();
            LoadArticlesFromContinents();

            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        public async void LoadArticlesFromContinents()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/news/");
            var container = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("content-page"));
            var webView = new WebView
            {
                Source = container.OuterHtml
            };
            this.Content = webView;
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
