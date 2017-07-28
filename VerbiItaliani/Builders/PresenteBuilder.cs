namespace VerbiItaliani.Builders
{
    public class PresenteBuilder : BaseBuilder, ITenseBuilder
    {
        private string[] _endings;

        public PresenteBuilder(string inf, bool suffixIsc, string core) 
            : base(inf)
        {
            if (core != null)
                Core = core;

            if (suffixIsc && Conjugation == Conjugations.III)
                Conjugation = Conjugations.IIIisc;

            CalculateEndings();
        }

        private void CalculateEndings()
        {
            _endings = new[] { "o", "i", "a", "iamo", "ate", "ano" };
            switch (Conjugation)
            {
                case Conjugations.II:
                    _endings[2] = "e";
                    _endings[4] = "ete";
                    _endings[5] = "ono";
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
            if (Type == VerbTypes.Normal)
                return Core + _endings[idx];
            return ReflexiveParticles[idx] + Core + _endings[idx];
        }
    }
}