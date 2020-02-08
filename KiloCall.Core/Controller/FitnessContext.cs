using KiloCall.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace KiloCall.Core.Controller
{
    public class FitnessContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OH4MS2K\\SQLEXPRESS;Initial Catalog=fitness;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        //public FitnessContext() : base("DBConnection") { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
