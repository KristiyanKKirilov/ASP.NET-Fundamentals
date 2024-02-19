namespace TaskBoardApp.Models
{
	public class TaskDetailsViewModel : TaskViewModel
	{
        /// <summary>
        /// Task date of creation
        /// </summary>
        public string CreatedOn { get; set; } = string.Empty;
        /// <summary>
        /// Task's board
        /// </summary>
        public string Board { get; set; } = string.Empty;
    }
}
