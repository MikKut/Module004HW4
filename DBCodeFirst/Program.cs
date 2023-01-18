using DBCodeFirst;
using DBCodeFirst.Clients;
using DBCodeFirst.Contextes;
using DBCodeFirst.EmployeeProjects;
using DBCodeFirst.Employees;
using DBCodeFirst.Offices;
using DBCodeFirst.Projects;
using DBCodeFirst.Titles;
using Microsoft.EntityFrameworkCore;

using (var db = new DBCodeFirst.Contextes.ApplicationContext())
{
    foreach (var t in Starter.GetAllEmpoleeesWithProjects(db))
    {
        Console.WriteLine(t.ToString());
    }

    Console.WriteLine();

    var x1 = Starter.GetDifferenceTodayAndHiredDay(db, 1);
    Console.WriteLine(x1);
    Console.WriteLine();

    Starter.RenovateTwoRecords(db, "Emp", "Proj", 1, 1);
    Console.WriteLine("Renovation is done!");

    Starter.AddTwoEmployeeWithTitleAndProject(db);
    Console.WriteLine("Entity is added");
    Starter.DeleteEmployee(db, 3);
    Console.WriteLine("Employee is deleted!");

    var x = Starter.GetAllEmployeesWithTitlesWhenItStartsWithSymbol(db, 'M');
    foreach (var z in x)
    {
        Console.WriteLine(z.ToString());
    }

    db.SaveChanges();
}