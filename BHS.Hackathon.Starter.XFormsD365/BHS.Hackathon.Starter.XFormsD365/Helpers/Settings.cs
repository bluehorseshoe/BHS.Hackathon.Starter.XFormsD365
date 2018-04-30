using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BHS.Hackathon.Starter.XFormsD365.Helpers
{
    /// <summary>
    /// Application Settings.
    /// </summary>
    public class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string D365URL
        {
            get => AppSettings.GetValueOrDefault(nameof(D365URL), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(D365URL), value);
        }

        public static string AzureADClientId
        {
            get => AppSettings.GetValueOrDefault(nameof(AzureADClientId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AzureADClientId), value);
        }

        public static string AzureADAuthority
        {
            get => AppSettings.GetValueOrDefault(nameof(AzureADAuthority), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AzureADAuthority), value);
        }

        public static string AzureADReturnURL
        {
            get => AppSettings.GetValueOrDefault(nameof(AzureADReturnURL), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AzureADReturnURL), value);
        }

        public static UserInfo AzureADUserInfo
        {
            get
            {
                var val = AppSettings.GetValueOrDefault(nameof(AzureADUserInfo), string.Empty);
                if (string.IsNullOrWhiteSpace(val))
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<UserInfo>(val);
                }
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue(nameof(AzureADUserInfo), JsonConvert.SerializeObject(value));
            }
        }
    }
}