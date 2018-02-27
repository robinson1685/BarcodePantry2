using Pantry.ViewModel;
using Pantry.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace Pantry.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantryView : ContentPage
    {
        private List<PantryList> pantry = new List<PantryList>();
        private static int ids = 0;
        ZXingScannerPage scanPage;
        //PantryViewModel vm;

        public PantryView()
        {
            InitializeComponent();
            //vm = new PantryViewModel();
            //listPantry.ItemsSource = vm.Pantry;
            ButtonScanner.Clicked += ButtonScanner_Clicked;
        }

        private async void ButtonScanner_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                //Do something with result
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
                    DisplayAlert("Updated Quantity: ", result.Text, "OK");
                    UpdateQuantity(result.Text);
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }

        private void UpdateQuantity(string result)
        {
            switch (result)
            {
                case "1":
                    var item = App.Database.GetPantryListbyBarCodeAsync(result);
                App.Database.UpdatePantryListQuantityAsync(item);
                    break;
                default:
                    DisplayAlert("Error", "You scanned barcode is invalid", "OK");
                    break;
            }
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    var pantry = new PantryList();
        //    pantry.ID = ids++;
        //    pantry.Name = Name.Text;
        //    pantry.Quantity = Quantity.Text;
        //    pantry.BarCode = Barcode.Text;
        //    Name.Text = "";
        //    Quantity.Text = "";
        //    pantry.Add(person);
        //}
    }
}