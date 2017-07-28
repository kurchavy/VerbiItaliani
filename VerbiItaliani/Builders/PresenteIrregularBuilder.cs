namespace VerbiItaliani.Builders
{
    public class PresenteIrregularBuilder : BaseBuilder, ITenseBuilder
    {
        private readonly string[] _forms;
        public PresenteIrregularBuilder(string inf, string[] forms) 
            : base(inf)
        {
            _forms = forms;
        }

        public string GetForm(Persons person, Numbers number, Genders gender)
        {
            var idx = GetIndex(person, number);
            if (Type == VerbTypes.Normal)
                return _forms[idx];
            return ReflexiveParticles[idx] + _forms[idx];
            
        }
    }
} 