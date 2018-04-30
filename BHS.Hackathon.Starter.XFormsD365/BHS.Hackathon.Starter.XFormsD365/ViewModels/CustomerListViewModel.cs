using Acr.UserDialogs;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Models;
using BHS.Hackathon.Starter.XFormsD365.Services;

namespace BHS.Hackathon.Starter.XFormsD365.ViewModels
{
    public class CustomerListViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Customer> CustomerList { get; }

        public CustomerListViewModel()
        {
            CustomerList = new ObservableRangeCollection<Customer>();
        }

        #region Load Activites

        private Command loadCustomersCommand;

        public Command LoadCustomersCommand
        {
            get
            {
                return loadCustomersCommand ??
                (loadCustomersCommand = new Command(async () =>
                {
                    await ExecuteLoadCustomersCommand();
                }));
            }
        }

        public async Task ExecuteLoadCustomersCommand()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                UserDialogs.Instance.ShowLoading("Loading...");

                var customers = await D365Service.GetCustomers();

                CustomerList.ReplaceRange(customers);
            }
            catch (Exception ex)
            {
                //LogHelper.Exception(ex, true);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
            }
        }

        #endregion Load Activites
    }
}