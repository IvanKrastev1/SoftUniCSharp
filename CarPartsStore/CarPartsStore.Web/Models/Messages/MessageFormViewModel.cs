using CarPartsStore.Common.Mapping;
using CarPartsStore.Data;
using CarPartsStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsStore.Web.Models.Messages
{
    public class MessageFormViewModel : IMapFrom<Message>
    {
        [Required]
        [MinLength(DataConstants.MessageDescriptionMinLength)]
        [MaxLength(DataConstants.MessageDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
