using System;

namespace BHS.Hackathon.Starter.XFormsD365.Utils
{
    public class AppUtils
    {
        /// <summary>
        /// Checks if URL Is Valid Format.
        /// </summary>
        /// <param name="input">String URL.</param>
        /// <returns>Is Valid.</returns>
        public static bool IsValidUrl(string url)
        {
            var result = Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == "http" || uriResult.Scheme == "https");
            return result;
        }
    }
}