using DBCodeFirst.Employees;

namespace DBCodeFirst.Titles
{
    internal interface ITitle
    {
        List<Employee> Employees { get; set; }
        string Name { get; set; }
        int TitleId { get; set; }
    }
}