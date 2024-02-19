using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        [Comment("Event identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Event.NameMaxLength)]
        [Comment("Event name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.Event.DescriptionMaxLength)]
        [Comment("Event description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Event's organiser identifier")]
        public string OrganiserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [Comment("Event's date of creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Start of event")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("End of event")]
        public DateTime End { get; set; }

        [Required]
        [Comment("Event's type identifier")]
        public int TypeId { get; set; }
        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public IList<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}


