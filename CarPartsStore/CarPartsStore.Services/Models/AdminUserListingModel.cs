using CarPartsStore.Common.Mapping;
using CarPartsStore.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CarPartsStore.Services.Models
{
    public class AdminUserListingModel : IMapFrom<User>
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
