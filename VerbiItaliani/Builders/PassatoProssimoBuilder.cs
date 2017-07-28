using System;

namespace VerbiItaliani.Builders
{
    public class PassatoProssimoBuilder : BaseBuilder, ITenseBuilder
    {
        private readonly string _form;
        private readonly string[] _auxVerb;
        private readonly bool _useEssere;
        public PassatoProssimoBuilder(string inf, bool useEssere, string form) 
            : base(inf)
        {
            if (String.IsNullOrEmpty(form))
            {
                switch (Conjugation)
                {
                    case Conjugations.I:
                        _form = Core + "ato";
                        break;
                    case Conjugations.II:
                        _form = Core + "uto";
                        break;
                    case Conjugations.III:
                        _form = Core + "ito";
                        break;
                }
            }
            else _form = form;

            _auxVerb = useEssere ?
                new[] { "sono", "sei", "è", "siamo", "siete", "sono" } :
                new[] { "ho", "hai", "ha", "abbiamo", "avete", "hanno" };

            _useEssere = useEssere;
        }

        public string GetForm(Persons person, Numbers number, Genders gender)
        {
            var idx = GetIndex(person, number);
            var res = _auxVerb[idx] + " " + _form;
            if (Type == VerbTypes.Reflexive)
                res = ReflexiveParticles[idx] + res;

            if (gender == Genders.M && number == Numbers.Plural && _useEssere)
            {
                res = res.Remove(res.Length - 1) + "i";
            }

            if (gender == Genders.F && _useEssere)
            {
                if (number == Numbers.Singular)
                    res = res.Remove(res.Length - 1) + "a";
                else 
                    res = res.Remove(res.Length - 1) + "e";
            }
            return res;
        }
    }
}