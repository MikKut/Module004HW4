using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCodeFirst.Titles
{
    internal class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            ConfigureColumns(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable(nameof(Title)).HasKey(p => p.TitleId);
            builder.Property(p => p.TitleId).HasColumnName(nameof(Title.TitleId)).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName(nameof(Title.Name)).IsRequired().HasMaxLength(50);
        }
    }
}
