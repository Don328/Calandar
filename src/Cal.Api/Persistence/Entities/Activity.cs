using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cal.Api.Persistence.Entities;
    
public record Activity(
    DateOnly Date,
    TimeOnly Time,
    string Name,
    string Description,
    int Id = 0);

public class ActivityConfig :
    IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.Property(x => x.Id);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.Time).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired();
    }
}