using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.Models.DataConstants.Seminar;
namespace SeminarHub.Data.Models
{
	public class Seminar
	{
        [Key]
        [Comment("Seminar identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TopicMaxLength)]
        [Comment("Seminar topic")]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(LecturerMaxLength)]
        [Comment("Seminar lecturer")]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(DetailsMaxLength)]
        [Comment("Seminar details")]
        public string Details { get; set; } = string.Empty;

        [Required]
        [Comment("Seminar organizer identifier")]
        public string OrganizerId { get; set; } = string.Empty;
        [Required]
        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Seminar date")]
        public DateTime DateAndTime { get; set; }

        [Range(DurationMinTime, DurationMaxTime)]
        [Comment("Seminar duration")]
        public int Duration { get; set; }

        [Required]
        [Comment("Seminar category identifier")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [Required]
        public Category Category { get; set; } = null!;

        public IList<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}

