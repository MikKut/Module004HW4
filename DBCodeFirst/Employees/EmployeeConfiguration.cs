using DBCodeFirst.EmployeeProjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DBCodeFirst.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            ConfidureColumns(builder);
            ConfigureRelations(builder);
        }

        private void ConfidureColumns(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee)).HasKey(p => p.EmployeeId);
            builder.Property(p => p.EmployeeId).HasColumnName(nameof(Employee.EmployeeId)).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnName(nameof(Employee.FirstName)).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnName(nameof(Employee.LastName)).HasMaxLength(50).IsRequired();
            builder.Property(p => p.HiredDate).HasColumnName(nameof(Employee.HiredDate)).IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnName(nameof(Employee.DateOfBirth));
            builder.Property(p => p.OfficeId).HasColumnName(nameof(Employee.OfficeId)).IsRequired();
            builder.Property(p => p.TitleId).HasColumnName(nameof(Employee.TitleId)).IsRequired();
        }

        private void ConfigureRelations(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(o => o.Office)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Title)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
