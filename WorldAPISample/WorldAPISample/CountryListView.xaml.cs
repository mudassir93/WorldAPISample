using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WorldAPISample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorldAPISample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryListView : ContentPage
    {
        private readonly List<Country> countries;

        public CountryListView()
        {
            InitializeComponent();

            var data = WorldInfo.Implementation.WorldInfo.Current.GetCountriesWithIcons();

            countries = data.Countries.OrderBy(x => x.Name).Select(x=> new Country
            {
              
               Image = ImageSource.FromStream(() => new MemoryStream(x.Icon)),
               Name = x.Name,  
               PhoneCode = x.PhoneCode,
               NativeName = x.NativeName
              
            }).ToList();

            CountriesListView.BindingContext = countries;
            CountriesListView.ItemsSource = countries;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Country> data = new List<Country>();
            if (SearchBar.Text.Length > 0)
            {
                data = countries.Where(
                x => (x.Name ?? string.Empty).StartsWith(SearchBar.Text, StringComparison.InvariantCultureIgnoreCase) ||
                     (x.NativeName ?? string.Empty).StartsWith(SearchBar.Text, StringComparison.InvariantCultureIgnoreCase) ||
                     (x.PhoneCode ?? string.Empty).StartsWith(SearchBar.Text, StringComparison.InvariantCultureIgnoreCase)
                     ).ToList();

                CountriesListView.ItemsSource = data;
                return;
            }

            CountriesListView.ItemsSource = countries;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void CountriesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}