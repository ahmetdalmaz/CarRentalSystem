using CarRentalSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Mapping
{
    public class SegmentMap : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.ToTable("Segments");
            builder.HasKey(segment => segment.SegmentId);
            builder.Property(segment => segment.SegmentId).UseIdentityColumn(1, 1);
            builder.Property(segment => segment.SegmentName).HasColumnType("char").HasMaxLength(1);
            builder.Property(segment => segment.WeeklyPrice).HasColumnType("money");
            builder.Property(segment => segment.DailyPrice).HasColumnType("money");
            builder.Property(segment => segment.MonthlyPrice).HasColumnType("money");
            builder.Property(c => c.State).HasColumnType("bit").HasDefaultValue(true);


        }
    }
}
