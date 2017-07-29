namespace VerbiItaliani.Builders
{
    public class PresenteBuilder : BaseBuilder, ITenseBuilder
    {
        private string[] _endings;
        private string[] _forms;

        public PresenteBuilder(string inf, bool suffixIsc, string core, string[] forms) 
            : base(inf)
        {
            

            if (core != null)
                Core = core;

            if (suffixIsc && Conjugation == Conjugations.III)
                Conjugation = Conjugations.IIIisc;

            if (forms == null)
                CalculateEndings();
            else
                _forms = forms;
        }

        private void CalculateEndings()
        {
            _endings = new[] { "o", "i", "a", "iamo", "ate", "ano" };
            switch (Conjugation)
            {
                case Conjugations.II:
                    if (Infinitive.EndsWith("gliere"))
                    {
                        Core = Core.Remove(Core.Length - 3);
                        _endings[0] = "lgo";
                        _endings[1] = "gli";
                        _endings[2] = "glie";
                        _endings[3] = "gliamo";
                        _endings[4] = "gliete";
                        _endings[5] = "lgono";
                    }
                    else
                    {
                        _endings[2] = "e";
                        _endings[4] = "ete";
                        _endings[5] = "ono";
                    }
                    break;
                case Conjugations.III:
                    _endings[2] = "e";
                    _endings[4] = "ite";
                    _endings[5] = "ono";
                    break;
                case Conjugations.IIIisc:
                    _endings[0] = "isco";
                    _endings[1] = "isci";
                    _endings[2] = "isce";
                    _endings[4] = "ite";
                    _endings[5] = "iscono";
                    break;
                case Conjugations.ORRE:
                    _endings[0] = "ngo";
                    _endings[1] = "ni";
                    _endings[2] = "ne";
                    _endings[3] = "niamo";
                    _endings[4] = "nete";
                    _endings[5] = "ngono";
                    break;
                case Conjugations.URRE:
                    _endings[0] = "co";
                    _endings[1] = "ci";
                    _endings[2] = "ce";
                    _endings[3] = "ciamo";
                    _endings[4] = "cete";
                    _endings[5] = "cono";
                    break;
            }
        }

        public string GetForm(Persons person, Numbers number, Genders gender)
        {
            var idx = GetIndex(person, number);
            string res = "";
            if (_forms == null)
            {
                res = ComposeVerbForm(person, number);
            }
            else
                res = _forms[idx];

            if (Type == VerbTypes.Normal)
                return res;
            return ReflexiveParticles[idx] + res;
        }

        private string ComposeVerbForm(Persons person, Numbers number)
        {
            var idx = GetIndex(person, number);
            if (Core.EndsWith("i"))
            {
                if (idx == 1 || idx == 3)
                    return Core.Remove(Core.Length - 1) + _endings[idx];
            }
            if (Conjugation == Conjugations.I && (Core.EndsWith("c") || Core.EndsWith("g")))
            {
                if (idx == 1 || idx == 3)
                    return Core + "h" + _endings[idx];
            }
            return Core + _endings[idx];
        }
    }
}