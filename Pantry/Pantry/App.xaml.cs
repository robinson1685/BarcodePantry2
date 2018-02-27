using Pantry.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pantry.Data;
using Xamarin.Forms;

namespace Pantry
{
    public partial class App : Application
    {
        static PantryDataBase database;

        public App()
        {
            InitializeComponent();

            //MainPage = new Pantry.MainPage();
            //MainPage = new PantryView();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static PantryDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PantryDataBase(
                        DependencyService.Get<IFileHelper>().GetLocalFilePath("PantrySQLite3.db3"));
                }
                return database;
            }
        }
    }
}
