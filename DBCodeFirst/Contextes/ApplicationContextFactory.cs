using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBCodeFirst.Contextes
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var conString = Helpers.AppsettingHelper.GetConnectionString("ApplicationContext");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(conString);
            return new ApplicationContext();
        }
    }
}
