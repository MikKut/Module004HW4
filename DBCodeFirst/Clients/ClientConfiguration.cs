using DBCodeFirst.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBCodeFirst.Clients
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            ConfigureColumns(builder);
        }
        private void ConfigureColumns(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client)).HasKey(p => p.ClientId);
            builder.Property(p => p.ClientId).HasColumnName(nameof(Client.ClientId)).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnName(nameof(Client.FirstName)).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasColumnName(nameof(Client.LastName)).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Caracteristic).HasColumnName(nameof(Client.Caracteristic));
            builder.Property(p => p.DateOfBirth).HasColumnName(nameof(Client.DateOfBirth));
        }
    }
}
