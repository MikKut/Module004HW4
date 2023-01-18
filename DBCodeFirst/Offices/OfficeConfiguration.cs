using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCodeFirst.Offices
{
    internal class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            ConfiureColumns(builder);
        }
        
        private void ConfiureColumns(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable(nameof(Office)).HasKey(p => p.OfficeId);
            builder.Property(p => p.OfficeId).HasColumnName(nameof(Office.OfficeId)).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasColumnName(nameof(Office.Title)).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Location).HasColumnName(nameof(Office.Location)).HasMaxLength(100).IsRequired();
        }
    }
}
