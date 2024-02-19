using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Models;
using static TaskBoardApp.Data.Configuration.ConfigurationHelper;

namespace TaskBoardApp.Data.Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(new Board[]
            {
                OpenBoard,
                InProgressBoard,
                DoneBoard
            });
        }
    }
}
