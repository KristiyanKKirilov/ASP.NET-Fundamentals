using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Type.NameMaxLength)]
        [Comment("Type name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
