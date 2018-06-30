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
            //var json = await WebsiteCaller.ExecuteCall("https://continents.us/gallery.json");
            //System.Diagnostics.Debug.WriteLine(json);

            //dynamic response = JObject.Parse(json);
            //List<string> result = response.ToObject<List<string>>();

            var result = new List<string>();
            result.Add("https://upload.wikimedia.org/wikipedia/commons/a/a1/Fireworks_public_domain_image.jpg");
            result.Add("https://wallpaperbrowse.com/media/images/soap-bubble-1958650_960_720.jpg");
            result.Add("https://wallpaperbrowse.com/media/images/th.jpg");
            result.Add("https://wallpaperbrowse.com/media/images/trolltunga.jpg");
            result.Add("https://wallpaperbrowse.com/media/images/desktop-year-of-the-tiger-images-wallpaper.jpg");

            var grid = new Grid{VerticalOptions=LayoutOptions.FillAndExpand, HorizontalOptions=LayoutOptions.FillAndExpand};
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int i = 0; i < (result.Count + 1) / 2; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < result.Count; i++)
            {
                grid.Children.Add(new WebView { Source = result[i], VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand }, 0, i);
            }

            sLayout.Children.Add(grid);
        }
    }
}
