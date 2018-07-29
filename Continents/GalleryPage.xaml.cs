using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace Continents
{
    public partial class GalleryPage : ContentPage
    {
        public GalleryPage()
        {
            InitializeComponent();
            Title = "Gallery";
            NavigationPage.SetBackButtonTitle(this, "Back");
            //GetImages();
            var wv = new WebView
            {
                Source = "https://www.continents.us/photos"
            };
            this.Content = wv;
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
