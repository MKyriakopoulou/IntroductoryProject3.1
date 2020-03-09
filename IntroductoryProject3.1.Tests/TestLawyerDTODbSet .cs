using System;
using System.Linq;
using DTOlibrary;
using IntroductoryProject3._1.Models;

namespace IntroductoryProject3._1.Tests
{
    class TestLawyerDTODbSet : TestDbSet<LawyerDTO>
    {
        private object local;

        public object Local { get => local; internal set => local = value; }
        public override LawyerDTO Find(params object[] keyValues)
        {
            return this.SingleOrDefault(Lawyer => Lawyer.Id == (int)keyValues.Single());
        }
    }
}
