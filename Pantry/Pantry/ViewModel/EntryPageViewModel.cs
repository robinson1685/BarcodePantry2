using System;
using System.Collections.Generic;
using System.Text;
using Pantry.Model;

namespace Pantry.ViewModel
{
    class EntryPageViewModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
      

        public void AddToPantryList()
        {
            PantryList pantry = new PantryList();
            pantry.Name = Name;
            pantry.Quantity = Quantity;
            App.Database.SavePantryListAsync(pantry);
        }
    }
}
