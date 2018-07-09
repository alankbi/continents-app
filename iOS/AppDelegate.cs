﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Continents.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            new Syncfusion.SfCalendar.XForms.iOS.SfCalendarRenderer();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
