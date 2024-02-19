using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
	public class SeminarParticipant
	{
		[Required]
		[Comment("Seminar identifier")]
        public int SeminarId { get; set; }
		[ForeignKey(nameof(SeminarId))]
		public Seminar Seminar { get; set; } = null!;

        [Required]
		[Comment("Seminar participant identifier")]
        public string ParticipantId { get; set; } = string.Empty;
		[ForeignKey(nameof(ParticipantId))]
		public IdentityUser Participant { get; set; } = null!;
    }
}

