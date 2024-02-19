using Homies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homies.Data.Configuration
{
    public class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasKey(ep => new { ep.HelperId, ep.EventId });

            builder
                .HasOne(ep => ep.Event)
                .WithMany(e => e.EventsParticipants)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
