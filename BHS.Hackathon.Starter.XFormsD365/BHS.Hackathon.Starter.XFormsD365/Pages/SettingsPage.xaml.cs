using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Helpers;
using BHS.Hackathon.Starter.XFormsD365.Utils;

namespace BHS.Hackathon.Starter.XFormsD365.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            Title = "Settings";

            D365URL.Text = Settings.D365URL;
            AzureADClientId.Text = Settings.AzureADClientId;
            AzureADAuthority.Text = Settings.AzureADAuthority;
            AzureADReturnURL.Text = Settings.AzureADReturnURL;

            var tbSave = ToolbarHelper.GenerateToolbarButton("Save", new Command(async () =>
            {
                var isValidUrl = AppUtils.IsValidUrl(D365URL.Text);
                if (!isValidUrl)
                {
                    await DisplayAlert("Error", "Invalid D365 Url.", "Ok");
                    return;
                }

                isValidUrl = AppUtils.IsValidUrl(AzureADAuthority.Text);
                if (!isValidUrl)
                {
                    await DisplayAlert("Error", "Invalid Azure AD Authority Url.", "Ok");
                    return;
                }

                // update settings
                Settings.D365URL = D365URL.Text;
                Settings.AzureADClientId = AzureADClientId.Text;
                Settings.AzureADAuthority = AzureADAuthority.Text;
                Settings.AzureADReturnURL = AzureADReturnURL.Text;

                await Navigation.PopModalAsync();
            }));
            ToolbarItems.Add(tbSave);
        }
    }
}