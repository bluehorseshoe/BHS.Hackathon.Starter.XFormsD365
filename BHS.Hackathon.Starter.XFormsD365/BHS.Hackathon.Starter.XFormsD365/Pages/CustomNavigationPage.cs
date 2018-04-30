using Xamarin.Forms;

namespace BHS.Hackathon.Starter.XFormsD365.Pages
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            BarBackgroundColor = Color.FromHex("183c57");
            BarTextColor = Color.White;
        }
    }
}