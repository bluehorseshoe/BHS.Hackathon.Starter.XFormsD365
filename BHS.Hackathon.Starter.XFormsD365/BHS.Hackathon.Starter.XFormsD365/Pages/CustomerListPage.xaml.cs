using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Helpers;
using BHS.Hackathon.Starter.XFormsD365.Interfaces;
using BHS.Hackathon.Starter.XFormsD365.ViewModels;

namespace BHS.Hackathon.Starter.XFormsD365.Pages
{
    public partial class CustomerListPage : ContentPage
    {
        private CustomerListViewModel VM { get; }

        public CustomerListPage()
        {
            InitializeComponent();

            BindingContext = VM = new CustomerListViewModel();

            // handle auth login/logout

            var tbLoginOut = ToolbarHelper.GenerateToolbarButton("Auth", new Command(async () =>
            {
                if (Settings.AzureADUserInfo != null)
                {
                    // logout
                    new AuthenticationContext(Settings.AzureADAuthority).TokenCache.Clear();

                    DependencyService.Get<IAuthenticator>().ClearCookies();

                    VM.CustomerList.Clear();
                    Settings.AzureADUserInfo = null;

                    await ToastHelper.Success("Logged Out!");
                }
                else
                {
                    // login
                    try
                    {
                        await D365AuthHelper.GetAuthorizationHeader();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Authentication Error", ex.Message, "Ok");
                        return;
                    }

                    await VM.ExecuteLoadCustomersCommand();

                    await ToastHelper.Success("Customers Loaded!");
                }
            }));
            ToolbarItems.Add(tbLoginOut);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // if we don't have settings configured, pop settings page
            if (string.IsNullOrWhiteSpace(Settings.D365URL))
            {
                await Navigation.PushModalAsync(new CustomNavigationPage(new SettingsPage()));
            }
        }
    }
}