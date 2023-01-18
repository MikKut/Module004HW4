using DBCodeFirst.Contextes;
using DBCodeFirst.Employees;
using DBCodeFirst.Offices;
using DBCodeFirst.Titles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DBCodeFirst
{
    internal static class Starter
    {
        public static IQueryable GetAllEmpoleeesWithProjects(ApplicationContext context)
        {
            IQueryable result = from project in context.Projects
                                join employeeProjects in context.EmployeeProjects
                                on project.ProjectId equals employeeProjects.ProjectId

                                from employee in context.Employees
                                join employeeProjectsNew in context.EmployeeProjects
                                on employee.EmployeeId equals employeeProjectsNew.EmployeeId into joined
                                from j in joined.DefaultIfEmpty()

                                where employeeProjects.EmployeeProjectId == j.EmployeeProjectId
                                select new
                                {
                                    Projects = project,
                                    Employee = employee,
                                    EmployeeProject = j
                                };

            return result;
        }
        
        public static TimeSpan GetDifferenceTodayAndHiredDay(ApplicationContext context, int employeeId)
        {
            var query = context.Employees.Where(e => e.EmployeeId == employeeId).Select(e => e.HiredDate);
            return DateTime.Now - query.First();
        }
        public static void RenovateTwoRecords(ApplicationContext context, string newLastName, string newProjectName, int employeeId, int projectID)
        {
            var employee = context.Employees.First(item => item.EmployeeId == employeeId);
            var project = context.Projects.First(item => item.ProjectId == projectID);
            project.Name = newProjectName;
            employee.LastName = newLastName;
            context.SaveChanges();
        }
        
        public static void AddTwoEmployeeWithTitleAndProject(ApplicationContext context)
        {
            var office = new Office() { Location = "Kiyv", Title = "TTT"};
            var title = new Title() { Name = "T"};
            var emp = new DBCodeFirst.Employees.Employee() { LastName = "Crumn", HiredDate = DateTime.Now, FirstName = "Slavick", Office = office, Title = title};
            context.Add(emp);
            context.SaveChanges();
        }
        
        public static void DeleteEmployee(ApplicationContext context, int id)
        {
            var itemToRemove = context.Employees.SingleOrDefault(x => x.EmployeeId == id); //returns a single item.

            if (itemToRemove != null)
            {
                context.Employees.Remove(itemToRemove);
                context.SaveChanges();
            }
        }
 
        public static IQueryable GetAllEmployeesWithTitlesWhenItStartsWithSymbol(ApplicationContext context, char sybmol)
        { 
            var query = context.Employees
                .Include(x => x.Title)
                .Where(x => EF.Functions.Like(x.Title.Name, $"{sybmol}%"))
                .GroupBy(x => x.Title);

            Console.WriteLine(query.ToQueryString());
            return query;
        }
    }
}
