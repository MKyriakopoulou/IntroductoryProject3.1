using DocumentFormat.OpenXml.Wordprocessing;
using IntroductoryProject3._1.Models;
using Magnum.FileSystem;
using System.Data.Entity;


namespace IntroductoryProject3._1.DAL
{

    public class LawyerContext : DbContext
    {


        public LawyerContext() : base("LawyerDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LawyerContext>());

        }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LawyerContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lawyer>();
            modelBuilder.Entity<Gender>();
            modelBuilder.Entity<Title>();

        }

    }
}