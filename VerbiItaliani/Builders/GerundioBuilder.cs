using System;
using System.Linq;
using VerbiItaliani.Collection;

namespace VerbiItaliani.Builders
{
    public class GerundioBuilder : BaseBuilder, ITenseBuilder
    {
        private readonly string _form;
        private readonly string[] _auxVerb;
        public GerundioBuilder(string inf, string core)
            : base(inf)
        {
            if (!String.IsNullOrEmpty(core))
                Core = core;

            switch (Conjugation)
            {
                case Conjugations.I:
                    _form = Core + "ando";
                    break;
                case Conjugations.ORRE:
                case Conjugations.URRE:
                    _form = Core + "nendo";
                    break;
                default:
                    _form = Core + "endo";
                    break;
            }

            _auxVerb = new[] {"sto", "stai", "sta", "stiamo", "state", "stanno"};
        }

        public string GetForm(Persons person, Numbers number, Genders gender)
        {
            var idx = GetIndex(person, number);
            var res = _auxVerb[idx] + " " + _form;
            if (Type == VerbTypes.Reflexive)
                res = ReflexiveParticles[idx] + res;
            return res;
        }
    }
}