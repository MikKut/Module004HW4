using DBCodeFirst.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCodeFirst.Clients
{
    public class Client : IClient
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Caracteristic { get; set; }
        public virtual List<Project> Projects { get; set; } = new();
    }
}
