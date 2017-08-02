using System.Linq;
using NUnit.Framework;
using VerbiItaliani.Collection;

namespace VerbiItaliani.Tests.Builders
{
    [TestFixture]
    public class GerundioBuilderTests
    {
        [TestCase("parlare", new[] { "sto parlando", "stai parlando", "sta parlando", "stiamo parlando", "state parlando", "stanno parlando" })]
        [TestCase("prendere", new[] { "sto prendendo", "stai prendendo", "sta prendendo", "stiamo prendendo", "state prendendo", "stanno prendendo" })]
        [TestCase("dormire", new[] { "sto dormendo", "stai dormendo", "sta dormendo", "stiamo dormendo", "state dormendo", "stanno dormendo" })]
        [TestCase("bere", new[] { "sto bevendo", "stai bevendo", "sta bevendo", "stiamo bevendo", "state bevendo", "stanno bevendo" })]
        [TestCase("fare", new[] { "sto facendo", "stai facendo", "sta facendo", "stiamo facendo", "state facendo", "stanno facendo" })]
        public void GetForm_ReturnsRightResults(string inf, string[] results)
        {
            var verb = VerbsCollection.Get(inf);

            var res = verb.StarePlusGerundio();

            Assert.AreEqual(true, results.SequenceEqual(res));
        }
    }
}