using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldInfo.Core.Models;
using Xamarin.Forms;

namespace WorldAPISample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int current = 0, max = 0;
        List<Country> countries;
        public MainPage()
        {
            InitializeComponent();

            var data = WorldInfo.Implementation.WorldInfo.Current.GetCountriesWithIcons();

            countries = data.Countries.OrderBy(x=>x.Name).ToList();
            
            max = countries.Count;

            ShowCountry();           
        }

        private void PrevBtn_Clicked(object sender, EventArgs e)
        {
            if (current > 0)
                current--;

            ShowCountry();
        }

        private void NextBtn_Clicked(object sender, EventArgs e)
        {
            if (current < max - 1)
                current++;

            ShowCountry();
        }

        private void ShowCountry()
        {
            var c = countries[current];
            CountryName.Text = c.Name;
            CountryNameNative.Text = c.NativeName;
            CountryDetail.Text = $"Phone Code: {c.PhoneCode}        Currency: {c.Currency}";
            var stream = new MemoryStream(c.Icon);
            Flag.Source = ImageSource.FromStream(() => stream);
        }
    }
}
