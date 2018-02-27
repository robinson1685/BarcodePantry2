using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry.Data;
using Pantry.Model;
using Pantry.View;
using Xamarin.Forms;

namespace Pantry.View
{
	public partial class MainPage : ContentPage
	{
	    public ObservableCollection<PantryList> Pantries { get; set; } =
	        new ObservableCollection<PantryList>();
	    public MainPage(List<PantryList> pantries)
	    {
	        foreach (PantryList pantry in pantries)
	        {
	            Pantries.Add(pantry);
	        }
	        InitializeComponent();
	        BindingContext = this;
	    }

	    public void OnStore(object o, EventArgs e)
	    {
	        var repo = new PantryRepository();
	        repo.Save(Pantries);
	    }

	    public void OnRestore(object o, EventArgs e)
	    {
	        var repo = new PantryRepository();
	        var pantries = repo.GetAll();
	        foreach (PantryList person in pantries)
	        {
                Pantries.Add(person);
	        }
	    }

	    private void GoToPantryList(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new PantryView());
	    }
	}
}
