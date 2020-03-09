using System;
using System.Linq;
using DTOlibrary;
using IntroductoryProject3._1.Models;

namespace IntroductoryProject3._1.Tests
{
    class TestLawyerDbSet : TestDbSet<Lawyer>
    {
        public object Local { get; internal set; }

        public override Lawyer Find(params object[] keyValues)
        {
            return this.SingleOrDefault(lawyer => lawyer.Id == (int)keyValues.Single());
        }
    }
}
