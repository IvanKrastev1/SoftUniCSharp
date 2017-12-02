using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Suppliers
{
    public class AllSuppliersModel
    {
        public IEnumerable<SupplierModel> Suppliers { get; set; }
    }
}
