namespace CarPartsStore.Services.Models
{
    using CarPartsStore.Common.Mapping;
    using CarPartsStore.Data.Models;

    public class AdminUserEditModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
