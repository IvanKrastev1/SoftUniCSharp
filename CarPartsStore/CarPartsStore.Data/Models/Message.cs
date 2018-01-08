using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Data.Models
{
    public class Message
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
