using System.Runtime.CompilerServices;

namespace VerbiItaliani
{
    public class VerbProperties
    {
        public string Infinitivo { get; internal set; }

        public Conjugations Conjugation { get; internal set; }
        public VerbTypes Type { get; internal set; }

        internal string Core { get; set; }
        internal string FormGerundio { get; set; }
    }
}