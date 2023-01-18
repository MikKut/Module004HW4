using DBCodeFirst.Projects;

namespace DBCodeFirst.Clients
{
    internal interface IClient
    {
        string? Caracteristic { get; set; }
        int ClientId { get; set; }
        DateTime? DateOfBirth { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        List<Project> Projects { get; set; }
    }
}