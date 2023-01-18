using DBCodeFirst.EmployeeProjects;
using DBCodeFirst.Offices;
using DBCodeFirst.Titles;

namespace DBCodeFirst.Employees
{
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public int OfficeId { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual Title Title { get; set; }
        public virtual List<EmployeeProject> Projects { get; set; }
        public virtual Office Office { get; set; }
    }
}
