using DBCodeFirst.Employees;
using DBCodeFirst.Projects;

namespace DBCodeFirst.EmployeeProjects
{
    public class EmployeeProject : IEmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StarteDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
