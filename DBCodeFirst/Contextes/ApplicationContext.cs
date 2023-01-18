using DBCodeFirst.Clients;
using DBCodeFirst.EmployeeProjects;
using DBCodeFirst.Employees;
using DBCodeFirst.Offices;
using DBCodeFirst.Projects;
using DBCodeFirst.Titles;
using Microsoft.EntityFrameworkCore;

namespace DBCodeFirst.Contextes
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = Helpers.AppsettingHelper.GetConnectionString("ApplicationContext");
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjects.EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new Offices.OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new Projects.ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new Titles.TitleConfiguration());
            modelBuilder.ApplyConfiguration(new Clients.ClientConfiguration());

            // SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var office = new Office() { Location = "New York", Title = "MMM", OfficeId = 1 };
            var title = new Title() { Name = "T", TitleId = 1 };
            var emp1 = new DBCodeFirst.Employees.Employee() { LastName = "Crumn", HiredDate = DateTime.Now, FirstName = "Slavick", TitleId = title.TitleId, OfficeId = office.OfficeId, EmployeeId = 1 };
            var ep1 = new EmployeeProject() { EmployeeId = emp1.EmployeeId, EmployeeProjectId = 1, ProjectId = 1 };
            var ep2 = new EmployeeProject() { EmployeeId = emp1.EmployeeId, EmployeeProjectId = 2, ProjectId = 2 };
            var ep3 = new EmployeeProject() { EmployeeId = emp1.EmployeeId, EmployeeProjectId = 3, ProjectId = 3 };
            var ep4 = new EmployeeProject() { EmployeeId = emp1.EmployeeId, EmployeeProjectId = 4, ProjectId = 4 };
            var ep5 = new EmployeeProject() { EmployeeId = emp1.EmployeeId, EmployeeProjectId = 5, ProjectId = 5 };

            var cl1 = new Client() { Caracteristic = "He is A", ClientId = 1, DateOfBirth = DateTime.Now, FirstName = "A", LastName = "B" };
            var cl2 = new Client() { Caracteristic = "He is B", ClientId = 2, DateOfBirth = DateTime.Now, FirstName = "B", LastName = "B" };
            var cl3 = new Client() { Caracteristic = null, ClientId = 3, DateOfBirth = DateTime.Now, FirstName = "C", LastName = "C" };
            var cl4 = new Client() { Caracteristic = "He is D", ClientId = 4, DateOfBirth = DateTime.Now, FirstName = "D", LastName = "B" };
            var cl5 = new Client() { Caracteristic = null, ClientId = 5, DateOfBirth = DateTime.Now, FirstName = "E", LastName = "B" };

            var pr1 = new Project() { Budget = 100, CLientId = 1, Name = "A", StartedDate = DateTime.Now, ProjectId = 1, };
            var pr2 = new Project() { Budget = 110, CLientId = 2, Name = "B", StartedDate = DateTime.Now, ProjectId = 2, };
            var pr3 = new Project() { Budget = 110, CLientId = 3, Name = "C", StartedDate = DateTime.Now, ProjectId = 3, };
            var pr4 = new Project() { Budget = 200, CLientId = 4, Name = "D", StartedDate = DateTime.Now, ProjectId = 4, };
            var pr5 = new Project() { Budget = 90, CLientId = 5, Name = "E", StartedDate = DateTime.MinValue, ProjectId = 5, };

            modelBuilder.Entity<Office>()
                .HasData(office);
            modelBuilder.Entity<Title>()
                .HasData(title);
            modelBuilder.Entity<Employee>()
                .HasData(emp1);
            modelBuilder.Entity<Project>()
                .HasData(pr1, pr2, pr3, pr4, pr5);
            modelBuilder.Entity<EmployeeProject>()
                .HasData(ep1, ep2, ep3, ep4, ep5);
            modelBuilder.Entity<Client>()
                .HasData(cl1, cl2, cl3, cl4, cl5);
        }
    }
}
