using DBCodeFirst.Employees;
using DBCodeFirst.Projects;

namespace DBCodeFirst.EmployeeProjects
{
    internal interface IEmployeeProject
    {
        int EmployeeId { get; set; }
        int EmployeeProjectId { get; set; }
        int ProjectId { get; set; }
        decimal Rate { get; set; }
        DateTime StarteDate { get; set; }
        Employee Employee { get; set; }
        Project Project { get; set; }
    }
}