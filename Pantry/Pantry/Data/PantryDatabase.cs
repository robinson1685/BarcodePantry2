using Pantry.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantry.View;
using Xamarin.Forms;

namespace Pantry.Data
{
    public class PantryDataBase
    {
        readonly SQLiteAsyncConnection database;

        public PantryDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PantryList>().Wait();

        }

        public Task<List<PantryList>> GetPantrysAsync()
        {
            return database.Table<PantryList>().ToListAsync();
        }

        public Task<PantryList> GetPantryListAsync(int id)
        {
            return database.Table<PantryList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<PantryList> GetPantryListbyBarCodeAsync(string barcode)
        {
            return database.Table<PantryList>().Where(i => i.BarCode == barcode).FirstOrDefaultAsync();
        }

        public Task<int> SavePantryListAsync(PantryList pantry)
        {
            if (pantry.ID != 0)
            {
                return database.UpdateAsync(pantry);
            }
            else
            {
                return database.InsertAsync(pantry);
            }
        }

        public Task<int> DeletePantryListAsync(PantryList pantry)
        {
            return database.DeleteAsync(pantry);
        }

        public void UpdatePantryListQuantityAsync(Task<PantryList> pantry)
        {
            database.QueryAsync<PantryList>
                ("UPDATE PantryList SET Quantity = Quantity + 1" +
                "WHERE Id = ?", pantry.Result.ID);
        }
    }
}

