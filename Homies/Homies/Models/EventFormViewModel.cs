using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.Models.DataConstants.Event;
using static Homies.Data.Models.ErrorMessages;
using Type = Homies.Data.Models.Type;


namespace Homies.Models
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = RequiredError)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = StringLengthError)]
        [Comment("Event name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredError)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = StringLengthError)]
        [Comment("Event description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredError)]
        [Comment("Start of event")]
        public string Start { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [Comment("End of event")]
        public string End { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [Comment("Event's type identifier")]
        public int TypeId { get; set; }       

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
