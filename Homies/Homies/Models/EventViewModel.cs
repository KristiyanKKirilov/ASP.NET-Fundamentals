using Homies.Data.Models;
using System.ComponentModel.DataAnnotations;


namespace Homies.Models
{
    public class EventViewModel
    {
        public EventViewModel(
            int id,
            string name,
            DateTime start,
            string type,
            string organiser)
        {
            Id = id;
            Name = name;
            Start = start.ToString(DataConstants.DateFormat);
            Type = type;
            Organiser = organiser;

        }
        /// <summary>
        /// Event identifier
        /// </summary>
        [Key]        
        public int Id { get; set; }

        /// <summary>
        /// Event name
        /// </summary>
        [Required]               
        public string Name { get; set; } 

        /// <summary>
        /// Event starting time
        /// </summary>
        [Required]                
        public string Start{ get; set; } 

        /// <summary>
        /// Event type
        /// </summary>
        [Required]
        public string Type { get; set; } 
        [Required]
        public string Organiser { get; set; } 
        
    }
}
