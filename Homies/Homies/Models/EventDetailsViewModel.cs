using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EventDetailsViewModel
    {
        [Comment("Event identifier")]
        public int Id { get; set; }
        [Comment("Event name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Event description")]
        public string Description { get; set; } = string.Empty;

        [Comment("Event's organiser ")]
        public string Organiser { get; set; } = string.Empty;        

        [Comment("Event's date of creation")]
        public DateTime CreatedOn { get; set; }

        [Comment("Start of event")]
        public DateTime Start { get; set; }

        [Comment("End of event")]
        public DateTime End { get; set; }
        
        [Comment("Event's type ")]
        public string Type { get; set; } = null!;

    }
}
