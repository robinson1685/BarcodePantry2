using System;
using System.Collections.Generic;
using System.Text;
using Pantry.Data;
using SQLite;

namespace Pantry.Model
{
    public class PantryList : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }

        public static List<PantryList> Pantry = new List<PantryList>(); 
        //public List<PantryList> GetPantry()
        // {
        //List<PantryList> pantry = new List<PantryList>();
        //      {
        //          new PantryList()
        //          {
        //              Name = "Apple",
        //              Quantity = 1
        //          },

        //          new PantryList()
        //          {
        //              Name = "Salt",
        //              Quantity = 2
        //          },

        //          new PantryList()
        //          {
        //              Name = "Bread",
        //              Quantity = 3
        //          }
        //      };

        //return pantry;
        //   }
    }
}
