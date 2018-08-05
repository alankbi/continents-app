using System;
using System.Collections.Generic;

using System.Linq;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;
using HtmlAgilityPack;

namespace Continents
{
    public partial class CalendarPage : ContentPage
    {
        WebView webView;

        public CalendarPage()
        {
            InitializeComponent();
            Title = "Events";
            NavigationPage.SetBackButtonTitle(this, "Back");
            // calendar.Locale = new System.Globalization.CultureInfo("en-US");
            GetEventsFromWebsite();
        }

        public async void GetEventsFromWebsite()
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync("https://continents.us/events/");

            var content = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("content-page"));
            doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals("section-head")).Remove();

            var body = doc.DocumentNode.Descendants("body").FirstOrDefault();
            body.RemoveAllChildren();
            body.AppendChild(content);

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

        /* public async void FillCalendar() 
        {
            calendar.ShowInlineEvents = true;
            var events = new CalendarEventCollection();

            var json = await WebsiteCaller.ExecuteCall("https://continents-6124.restdb.io/rest/calendar");
            System.Diagnostics.Debug.WriteLine(json);

            dynamic response = JArray.Parse(json);
            List<CalendarEvent> result = response.ToObject<List<CalendarEvent>>();

            foreach (var calEvent in result)
            {
                System.Diagnostics.Debug.WriteLine(calEvent.StartDate.ToString());
                events.Add(new CalendarInlineEvent
                {
                    StartTime = calEvent.StartDate.ToLocalTime(),
                    EndTime = calEvent.EndDate.ToLocalTime(),
                    Subject = calEvent.Subject
                });
            }

            calendar.DataSource = events;
        } */
    }
}
