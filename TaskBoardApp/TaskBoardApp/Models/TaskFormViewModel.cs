using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Models
{
    public class TaskFormViewModel
    {
        /// <summary>
        /// Task identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Task title
        /// </summary>

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = ErrorMessages.StringLengthError)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Task description
        /// </summary>

        [Required(ErrorMessage = ErrorMessages.RequiredError)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = ErrorMessages.StringLengthError)]
        public string Description { get; set; } = string.Empty;       
        /// <summary>
        /// Task's board identifier
        /// </summary>
        public int? BoardId { get; set; }
        /// <summary>
        /// Task's owner 
        /// </summary>
        public IEnumerable<TaskBoardViewModel> Boards { get; set; } = new List<TaskBoardViewModel>();
    }
}
