using System.Data.Entity;

namespace DTOlibrary.DAL
{
    class DTOcontext : DbContext
    {
        public DTOcontext()
       : base("LawyerDtoDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DTOcontext>());
        }

        public DbSet<LawyerDTO> LawyerDTOs { get; set; }
        public DbSet<GenderDTO> GenderDTOs { get; set; }
        public DbSet<TitleDTO> TitleDTOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LawyerDTO>();
            modelBuilder.Entity<GenderDTO>();
            modelBuilder.Entity<TitleDTO>();
        }

    }

}
