using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFLab3
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=EModel")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DeptID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
