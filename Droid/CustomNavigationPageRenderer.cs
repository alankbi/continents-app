﻿using System;
using Continents.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Widget;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
namespace Continents.Droid
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            for (int index = 0; index < toolbar.ChildCount; index++)
            {
                if (toolbar.GetChildAt(index) is TextView)
                {
                    var title = toolbar.GetChildAt(index) as TextView;
                    float toolbarCenter = toolbar.MeasuredWidth / 2;
                    float titleCenter = title.MeasuredWidth / 2;
                    title.SetX(toolbarCenter - titleCenter);
                }
            }
        }
    }
}
