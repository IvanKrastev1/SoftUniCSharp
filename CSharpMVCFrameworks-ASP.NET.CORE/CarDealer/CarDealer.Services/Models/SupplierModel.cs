using CarDealer.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
     public class SupplierModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public int PartsCount { get; set; }
    }
}
