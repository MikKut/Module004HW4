using DBCodeFirst.Employees;

namespace DBCodeFirst.Offices
{
    internal interface IOffice
    {
        List<Employee> Employees { get; set; }
        string Location { get; set; }
        int OfficeId { get; set; }
        string Title { get; set; }
    }
}