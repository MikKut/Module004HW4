using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DBCodeFirst.Projects
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            ConfiureColumns(builder);
            ConfigureRelations(builder);
        }

        private void ConfiureColumns(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(nameof(Project)).HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).HasColumnName(nameof(Project.ProjectId)).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName(nameof(Project.Name)).IsRequired();
            builder.Property(p => p.Budget).HasColumnName(nameof(Project.Budget)).IsRequired();
            builder.Property(p => p.CLientId).HasColumnName(nameof(Project.CLientId)).IsRequired();
            builder.Property(p => p.StartedDate).HasColumnName(nameof(Project.StartedDate)).IsRequired();
        }

        private void ConfigureRelations(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(c => c.Client)
             .WithMany(e => e.Projects)
             .HasForeignKey(e => e.CLientId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
