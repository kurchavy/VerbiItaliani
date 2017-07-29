using System.Linq;
using NUnit.Framework;
using VerbiItaliani.Collection;

namespace VerbiItaliani.Tests.Builders
{
    [TestFixture]
    public class PresenteBuilderTests
    {
        [TestCase("parlare", new[] {"parlo", "parli", "parla", "parliamo", "parlate", "parlano"})]
        [TestCase("prendere", new[] { "prendo", "prendi", "prende", "prendiamo", "prendete", "prendono" })]
        [TestCase("dormire", new[] { "dormo", "dormi", "dorme", "dormiamo", "dormite", "dormono" })]
        [TestCase("capire", new[] { "capisco", "capisci", "capisce", "capiamo", "capite", "capiscono" })]
        [TestCase("cercare", new[] { "cerco", "cerchi", "cerca", "cerchiamo", "cercate", "cercano" })]
        [TestCase("studiare", new[] { "studio", "studi", "studia", "studiamo", "studiate", "studiano" })]
        [TestCase("spiegare", new[] { "spiego", "spieghi", "spiega", "spieghiamo", "spiegate", "spiegano" })]
        [TestCase("vincere", new[] { "vinco", "vinci", "vince", "vinciamo", "vincete", "vincono" })]
        [TestCase("scegliere", new[] { "scelgo", "scegli", "sceglie", "scegliamo", "scegliete", "scelgono" })]
        public void GetForm_ReturnsRightResults(string inf, string[] results)
        {
            var verb = VerbsCollection.Get(inf);

            var res = verb.PresenteIndicativo();

            Assert.AreEqual(true, results.SequenceEqual(res));
        }
    }
}