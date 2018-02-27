using System;
using System.Collections.Generic;
using System.Text;
using Pantry.Model;

namespace Pantry.Data
{
    public class PantryRepository : GenericFileRepository<PantryList>
    {
        public PantryRepository() : base("PantryFile.json") { }
    }
}
