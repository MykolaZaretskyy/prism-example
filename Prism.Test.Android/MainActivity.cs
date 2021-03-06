﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism.Test.Android;

namespace Prism.Test.Droid
{
    [Activity(Label = "Prism.Test", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape,
        Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new Setup()));
        }
    }
}