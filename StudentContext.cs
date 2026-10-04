using System.Data.Entity;
namespace StudentCRUD.Models
{
public class StudentContext : DbContext
{
public StudentContext()
: base("StudentConnection")
{
}
public DbSet<Student> Students
{
get;
set;
}
}
}
