using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Models
{
    public class TaskViewModel
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Task title
        /// </summary>

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Task description 
        /// </summary>

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;      
        /// <summary>
        /// Task's owner 
        /// </summary>
        [Required]
        public string Owner { get; set; } = string.Empty;


    }
}
