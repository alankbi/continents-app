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
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("id") && x.Attributes["id"].Value.Equals("header_container")).Remove();
            doc.DocumentNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("SideBarButton")).Remove();
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("id") && x.Attributes["id"].Value.Equals("footer")).Remove();

            var body = doc.DocumentNode.Descendants("body").FirstOrDefault();

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
