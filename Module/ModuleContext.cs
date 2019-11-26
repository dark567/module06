using ModuleDal.Models;
using System.Data.Entity;

namespace ModuleDal
{
    public class ModuleContext : DbContext
    {
        //public ModuleContext(string connectionString = @"Data Source=DARK\SQLEXPRESS;Initial Catalog=Db30;Integrated Security=True") : base(connectionString)
        //{

        //}

        public ModuleContext() : base(@"Data Source=DARK\SQLEXPRESS;Initial Catalog=Module;Integrated Security=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
