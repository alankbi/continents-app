using System;
using System.Collections.Generic;

using System.Linq;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

using HtmlAgilityPack;

namespace Continents
{
    public partial class GalleryPage : ContentPage
    {
        private WebView webView;
        public GalleryPage()
        {
            InitializeComponent();
            Title = "Gallery";
            NavigationPage.SetBackButtonTitle(this, "Back");
            //GetImages();
            GetImagesFromWebsite();
        }

        public async void GetImagesFromWebsite()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/photos/");

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("content-page"));
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Contains("section-head")).Remove();

            var body = doc.DocumentNode.Descendants("body").FirstOrDefault();
            body.RemoveAllChildren();
            body.AppendChild(content);
            System.Diagnostics.Debug.WriteLine(body.InnerHtml);

            webView = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = doc.DocumentNode.OuterHtml
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            ToolbarItems.Add(new ToolbarItem("<", null, () => { webView.GoBack(); }));
            ToolbarItems.Add(new ToolbarItem(">", null, () => { webView.GoForward(); }));
            sLayout.Children.Add(webView);
        }

        public async void GetImages()
        {
            var json = await WebsiteCaller.ExecuteCall("https://continents-6124.restdb.io/rest/gallery");

            dynamic response = JArray.Parse(json);
            List<ImageUrl> result = response.ToObject<List<ImageUrl>>();

            var grid = new Grid { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, RowSpacing = 5};
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < (result.Count + 1) / 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute) });
            }

            for (int i = 0; i < result.Count; i++)
            {
                grid.Children.Add(new Image { Source = result[i].Url, Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand }, 0, i);
            }

            sLayout.Children.Add(grid);
        }
    }
}
