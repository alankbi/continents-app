using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;

namespace Continents
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            Title = "Calendar";
            NavigationPage.SetBackButtonTitle(this, "Back");
            calendar.Locale = new System.Globalization.CultureInfo("en-US");
            FillCalendar();
        }

        public async void FillCalendar() 
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
        }
    }
}
