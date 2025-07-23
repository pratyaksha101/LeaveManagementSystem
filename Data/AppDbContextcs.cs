using LeaveManagementSystemnew.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystemnew.Data
{
    public class AppDbContextcs: DbContext
    {
        public AppDbContextcs(DbContextOptions<AppDbContextcs> options ) : base (options)
        {

        }
       public DbSet<Employee> Employees { get; set; }
      public  DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee", "Leave");
            modelBuilder.Entity<LeaveRequest>().ToTable("LeaveRequest", "Leave");

            modelBuilder.Entity<LeaveRequest>()
            .HasOne(lr => lr.Employee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(lr => lr.EmployeeId);
        }
    }
}
