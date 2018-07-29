using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Continents
{
    public partial class SocialMediaPage : TabbedPage
    {
        public SocialMediaPage()
        {
            InitializeComponent();
            Title = "Social Media";
            NavigationPage.SetBackButtonTitle(this, "Back");

            ToolbarItems.Add(new ToolbarItem("<", null, () => { GetWebView().GoBack(); }));
            ToolbarItems.Add(new ToolbarItem(">", null, () => { GetWebView().GoForward(); }));
        }

        private WebView GetWebView()
        {
            switch (CurrentPage.Title)
            {
                case "Facebook":
                    return webViewFB;
                case "Twitter":
                    return webViewTW;
                case "YouTube":
                    return webViewYT;
                default:
                    return webViewLI;
            }
        }
    }
}
