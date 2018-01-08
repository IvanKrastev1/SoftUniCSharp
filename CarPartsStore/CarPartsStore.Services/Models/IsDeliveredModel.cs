using CarPartsStore.Common.Mapping;
using CarPartsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsStore.Services.Models
{
    public class IsDeliveredModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public bool IsDelivered { get; set; }
    }
}
