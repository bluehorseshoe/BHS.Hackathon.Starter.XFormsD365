using Plugin.Toasts;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BHS.Hackathon.Starter.XFormsD365.Helpers
{
    /// <summary>
    /// Display Notifications in App.
    /// </summary>
    public static class ToastHelper
    {
        private static IToastNotificator Toast => DependencyService.Get<IToastNotificator>();

        /// <summary>
        /// Generate Success Toast.
        /// </summary>
        /// <param name="message">Toast Message.</param>
        /// <param name="visibleTimeSeconds">Length of Time to Show Toast.</param>
        /// <returns>Success of Operation.</returns>
        public static async Task<bool> Success(string message, int visibleTimeSeconds = 2)
        {
            return await Toast.Notify(ToastNotificationType.Success, "Success", message, TimeSpan.FromSeconds(visibleTimeSeconds));
        }

        /// <summary>
        /// Generate Information Toast.
        /// </summary>
        /// <param name="message">Toast Message.</param>
        /// <param name="visibleTimeSeconds">Length of Time to Show Toast.</param>
        /// <returns>Success of Operation.</returns>
        public static async Task<bool> Info(string message, int visibleTimeSeconds = 2)
        {
            return await Toast.Notify(ToastNotificationType.Info, "Info", message, TimeSpan.FromSeconds(visibleTimeSeconds));
        }

        /// <summary>
        /// Generate Error Toast.
        /// </summary>
        /// <param name="message">Toast Message.</param>
        /// <param name="visibleTimeSeconds">Length of Time to Show Toast.</param>
        /// <returns>Success of Operation.</returns>
        public static async Task<bool> Error(string message, int visibleTimeSeconds = 2)
        {
            return await Toast.Notify(ToastNotificationType.Error, "Error", message, TimeSpan.FromSeconds(visibleTimeSeconds));
        }
    }
}