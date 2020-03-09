using System;
using System.Data.Entity;
using DTOlibrary;
using IntroductoryProject3._1.DAL;
using IntroductoryProject3._1.Models;

namespace IntroductoryProject3._1.Tests
{
    class TestLawyerContext : LawyerContext
    {
        public TestLawyerContext()
        {
            this.Lawyers = new TestLawyerDbSet();
            this.LawyerDTOs = new TestLawyerDTODbSet();
        }

        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<LawyerDTO> LawyerDTOs { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Lawyer lawyer) { }
        public void Dispose() { }
    }
}
