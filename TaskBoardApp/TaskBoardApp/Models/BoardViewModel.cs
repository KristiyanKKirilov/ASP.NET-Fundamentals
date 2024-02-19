using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Models
{
    public class BoardViewModel
    {
        /// <summary>
        /// Board identifier
        /// </summary>              
        public int Id { get; set; }
        /// <summary>
        /// Board name
        /// </summary>
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = "The field {} should be between {2} and {1} symbols")]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
