using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Services.Models
{
    public class AdminAllMessageListingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MessageDescriptionMinLength)]
        [MaxLength(DataConstants.MessageDescriptionMaxLength)]
        public string Description { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
