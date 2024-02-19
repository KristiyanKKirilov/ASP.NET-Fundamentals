using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Data.Models
{
    [Comment("Board tasks")]
    public class Task
    {
        [Key]
        [Comment("Task identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Task title")]
        [MaxLength(DataConstants.Task.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Task description")]
        [MaxLength(DataConstants.Task.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Task date of creation")]
        public DateTime? CreatedOn { get; set; }

        [Comment("Task's board identifier")]
        public int? BoardId { get; set; }
        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        [Comment("Application user's identifier")]
        public string OwnerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;


    }
}

//Id – a unique integer, Primary Key
//•	Title – a string with min length 5 and max length 70 (required)
//•	Description – a string with min length 10 and max length 1000 (required)
//•	CreatedOn – date and time
//•	BoardId – an integer
//•	Board – a Board object
//•	OwnerId – an integer (required)
//•	Owner – an IdentityUser object
