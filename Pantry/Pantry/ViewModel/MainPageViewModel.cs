using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pantry.Model;
using Xamarin.Forms;

namespace Pantry.ViewModel
{
    public class MainPageViewModel
    {

        public ObservableCollection<PantryList> People { get; set; } = new ObservableCollection<PantryList>();

        public MainPageViewModel()
        {
            PantryList pantry = new PantryList();
            pantry.Name = "Apple";
            pantry.Quantity = 1;
            pantry.BarCode = "1";
            People.Add(pantry);

            PopulatePantryList();
        }

        private async void PopulatePantryList()
        {
            List<PantryList> pantry = await App.Database.GetPantrysAsync();
            foreach (PantryList pantries in pantry)
            {
                People.Add(pantries);
            }
        }
    }
}
