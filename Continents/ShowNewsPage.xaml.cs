using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class ShowNewsPage : ContentPage
    {
        string infoText;
        string imageUrl;
        string title;
        string date;

        public ShowNewsPage(string infoText, string imageUrl, string title, string date)
        {
            InitializeComponent();
            this.infoText = infoText;
            this.imageUrl = imageUrl;
            this.title = title;
            this.date = date;

            infoTextLabel.Text = infoText;
            image.Source = imageUrl;
            titleLabel.Text = title;
            dateLabel.Text = date;

        }
    }
}
