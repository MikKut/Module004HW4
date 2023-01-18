using DBCodeFirst.Employees;

namespace DBCodeFirst.Titles
{
    public class Title : ITitle
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }

}
