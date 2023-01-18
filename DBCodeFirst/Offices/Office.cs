using DBCodeFirst.Employees;

namespace DBCodeFirst.Offices
{
    public class Office : IOffice
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public  virtual List<Employee> Employees
        {
            get; set;
        }
    }
}
