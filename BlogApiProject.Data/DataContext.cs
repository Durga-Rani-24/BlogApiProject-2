using BlogApiProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BlogApiProject.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogImage> BlogImages { get; set; }
}
