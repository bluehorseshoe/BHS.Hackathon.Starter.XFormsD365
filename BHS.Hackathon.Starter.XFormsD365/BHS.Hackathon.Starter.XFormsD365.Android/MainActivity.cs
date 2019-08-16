using Android.App;
using Android.Content.PM;
using Android.OS;
using BHS.Hackathon.Starter.XFormsD365;
using Plugin.CurrentActivity;
using Xamarin.Forms;

namespace XFormsD365.Android
{
    [Activity(Label = "BHS.Hackathon.Starter.XFormsD365", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Droid.Resource.Layout.Tabbar;
            ToolbarResource = Droid.Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Acr.UserDialogs.UserDialogs.Init(() => CrossCurrentActivity.Current.Activity);
            DependencyService.Register<Plugin.Toasts.ToastNotificatorImplementation>();
            Plugin.Toasts.ToastNotificatorImplementation.Init(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}