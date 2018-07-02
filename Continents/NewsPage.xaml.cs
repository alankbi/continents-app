using System;
using System.Net;
using System.Net.Http;
using System.IO;

using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace Continents
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            Title = "Campus News";
            LoadArticles();
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        public async void LoadArticles()
        {
            var json = await WebsiteCaller.ExecuteCall("https://continents-6124.restdb.io/rest/news-articles");
            System.Diagnostics.Debug.WriteLine(json);

            dynamic response = JArray.Parse(json);
            var result = response.ToObject<List<Article>>();

            foreach (Article article in result)
            {
                sLayout.Children.Add(new NewsView
                {
                    ImageUrl = article.ImageUrl,
                    InfoText = article.Body,
                    Title = article.Title, 
                    Date = article.Date
                });
            }
        }
    }
}
