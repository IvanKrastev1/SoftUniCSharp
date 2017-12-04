namespace CarPartsStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {   [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        public IList<Sale> Sales { get; set; } = new List<Sale>();

        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
