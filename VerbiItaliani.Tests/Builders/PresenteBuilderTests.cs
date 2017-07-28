using System.Linq;
using NUnit.Framework;
using VerbiItaliani.Builders;

namespace VerbiItaliani.Tests.Builders
{
    [TestFixture]
    public class PresenteBuilderTests
    {
        [TestCase("parlare", false, null, new[] {"parlo", "parli", "parla", "parliamo", "parlate", "parlano"})]
        [TestCase("prendere", false, null, new[] { "prendo", "prendi", "prende", "prendiamo", "prendete", "prendono" })]
        [TestCase("dormire", false, null, new[] { "dormo", "dormi", "dorme", "dormiamo", "dormite", "dormono" })]
        [TestCase("capire", true, null, new[] { "capisco", "capisci", "capisce", "capiamo", "capite", "capiscono" })]
        public void GetForm_ReturnsRightResults(string inf, bool suffix, string core, string[] results)
        {
            var builder = new PresenteBuilder(inf, suffix, core);

            var res = new[]
            {
                builder.GetForm(Persons.First, Numbers.Singular, Genders.M),
                builder.GetForm(Persons.Second, Numbers.Singular, Genders.M),
                builder.GetForm(Persons.Third, Numbers.Singular, Genders.M),
                builder.GetForm(Persons.First, Numbers.Plural, Genders.M),
                builder.GetForm(Persons.Second, Numbers.Plural, Genders.M),
                builder.GetForm(Persons.Third, Numbers.Plural, Genders.M),
            };

            Assert.AreEqual(true, results.SequenceEqual(res));
        }
    }
}