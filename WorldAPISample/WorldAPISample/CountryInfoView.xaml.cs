using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldInfo.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldAPISample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryInfoView : ContentPage
    {
        private int current = 0;
        private readonly int max = 0;
        private readonly List<Country> countries;
        public CountryInfoView()
        {
            InitializeComponent();

            var data = WorldInfo.Implementation.WorldInfo.Current.GetCountriesWithIcons();

            countries = data.Countries.OrderBy(x => x.Name).ToList();

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