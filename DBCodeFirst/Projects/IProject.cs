using DBCodeFirst.EmployeeProjects;

namespace DBCodeFirst.Projects
{
    internal interface IProject
    {
        List<EmployeeProject> EmployeeProjects { get; set; }
        string Name { get; set; }
        decimal Budget { get; set; }
        int ProjectId { get; set; }
        DateTime StartedDate { get; set; }
    }
}