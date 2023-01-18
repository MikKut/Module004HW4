using DBCodeFirst.Employees;
using DBCodeFirst.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DBCodeFirst.EmployeeProjects
{
    internal class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            ConfiureColumns(builder);
            ConfigureRelations(builder);  
        }

        private void ConfiureColumns(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable(nameof(EmployeeProject)).HasKey(p => p.EmployeeProjectId);
            builder.Property(p => p.EmployeeProjectId).HasColumnName(nameof(EmployeeProject.EmployeeProjectId)).ValueGeneratedOnAdd();
            builder.Property(p => p.StarteDate).HasColumnName(nameof(EmployeeProject.StarteDate)).IsRequired();
            builder.Property(p => p.EmployeeId).HasColumnName(nameof(EmployeeProject.EmployeeId)).IsRequired();
            builder.Property(p => p.ProjectId).HasColumnName(nameof(EmployeeProject.ProjectId)).IsRequired();
        }

        private void ConfigureRelations(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasOne(e => e.Employee)
              .WithMany(p => p.Projects)
              .HasForeignKey(e => e.EmployeeId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Project)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(f => f.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
