using CarDealer.Data;
using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> Suppliers()
        {
            var suppliersQuery = this.db.Suppliers.AsQueryable();
            
            return suppliersQuery
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsImporter = s.IsImporter,
                    PartsCount = s.Parts.Count
                })
                .ToList();
        }


    }
}
