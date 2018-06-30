using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Continents
{
    public partial class NewsView : ContentView
    {
        public string InfoText 
        {
            get 
            {
                return infoText.Text;
            }
            set
            {
                infoText.Text = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageUrl.Text;
            }
            set
            {
                imageUrl.Text = value;
                image.Source = value;
            }
        }

        public string Title
        {
            get
            {
                return titleLabel.Text;
            }
            set
            {
                titleLabel.Text = value;
            }
        }

        public string Date
        {
            get
            {
                return dateLabel.Text;
            }
            set
            {
                dateLabel.Text = value;
            }
        }

        public NewsView()
        {
            InitializeComponent();
            infoText.LineBreakMode = LineBreakMode.TailTruncation;
            image.Source = ImageUrl;
            System.Diagnostics.Debug.WriteLine(ImageUrl);
            System.Diagnostics.Debug.WriteLine("HERE");
            grid.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => { OnMoreInfo(); }) });
        }

        async void OnMoreInfo()
        {
            await Navigation.PushAsync(new ShowNewsPage(InfoText, ImageUrl, Title, Date));
        }
    }
}
