using Xamarin.Forms;

namespace BHS.Hackathon.Starter.XFormsD365.Helpers
{
    public class ToolbarHelper
    {
        public static ToolbarItem GenerateToolbarButton(string text, Command action)
        {
            var tbItem = new ToolbarItem();

            tbItem.Text = text;
            tbItem.Command = action;
            tbItem.AutomationId = text.ToLower();

            text = text.ToLower().Replace(" ", "");

            if (Device.RuntimePlatform == Device.UWP || (text != "save" && text != "cancel"))
            {
                var icon = $"bar_" + text + ".png";

                if (Device.RuntimePlatform == Device.UWP)
                {
                    icon = "icons/" + icon;
                }
                tbItem.Icon = icon;
            }

            return tbItem;
        }
    }
}