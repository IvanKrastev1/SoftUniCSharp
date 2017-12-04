namespace CarPartsStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.SaleAdressMinLength)]
        [MaxLength(DataConstants.SaleAdressMaxLength)]
        public string Adress { get; set; }

        [Required]
        public bool IsDelivered { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<PartSale> Parts { get; set; } = new List<PartSale>();
    }
}
