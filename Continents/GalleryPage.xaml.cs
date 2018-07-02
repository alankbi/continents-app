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
            GetImages();
        }

        public async void GetImages()
        {
            var json = await WebsiteCaller.ExecuteCall("https://continents-6124.restdb.io/rest/gallery");
            System.Diagnostics.Debug.WriteLine(json);

            dynamic response = JArray.Parse(json);
            List<ImageUrl> result = response.ToObject<List<ImageUrl>>();

            var grid = new Grid { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < (result.Count + 1) / 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < result.Count; i++)
            {
                grid.Children.Add(new WebView { Source = result[i].Url, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand }, 0, i);
            }

            sLayout.Children.Add(grid);
        }
    }
}
