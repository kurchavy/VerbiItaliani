using System.Linq;
using NUnit.Framework;
using VerbiItaliani.Collection;

namespace VerbiItaliani.Tests.Builders
{
    [TestFixture]
    public class PassatoProssimoBuilderTests
    {
        [TestCase("accendere", new[] { "ho acceso", "hai acceso", "ha acceso", "abbiamo acceso", "avete acceso", "hanno acceso" })]
        [TestCase("accorgersi", new[] { "mi ho accorto", "ti hai accorto", "si ha accorto", "ci abbiamo accorto", "vi avete accorto", "si hanno accorto" })]
        [TestCase("fare", new[] { "ho fatto", "hai fatto", "ha fatto", "abbiamo fatto", "avete fatto", "hanno fatto" })]
        [TestCase("mettersi", new[] { "mi ho messo", "ti hai messo", "si ha messo", "ci abbiamo messo", "vi avete messo", "si hanno messo" })]
        public void GetForm_ReturnsRightResults(string inf, string[] results)
        {
            var verb = VerbsCollection.Get(inf);

            var res = verb.PassatoProssimo();

            Assert.AreEqual(true, results.SequenceEqual(res));
        }
    }
}