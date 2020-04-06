using System.ComponentModel;
using Xamarin.Forms;

namespace WorldAPISample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ShowInfo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CountryInfoView(), true);
        }

        private void ShowList_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CountryListView(), true);
        }
    }
}
