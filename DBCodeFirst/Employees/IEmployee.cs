using DBCodeFirst.EmployeeProjects;
using DBCodeFirst.Offices;
using DBCodeFirst.Titles;

namespace DBCodeFirst.Employees
{
    internal interface IEmployee
    {
        DateTime? DateOfBirth { get; set; }
        int EmployeeId { get; set; }
        string FirstName { get; set; }
        DateTime HiredDate { get; set; }
        string LastName { get; set; }
        int OfficeId { get; set; }
        int TitleId { get; set; }
        Office Office { get; set; }
        Title Title { get; set; }
        List<EmployeeProject> Projects { get; set; }
    }
}