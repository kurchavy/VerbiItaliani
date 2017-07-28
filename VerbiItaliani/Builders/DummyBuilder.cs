namespace VerbiItaliani.Builders
{
    public class DummyBuilder : ITenseBuilder
    {
        public string GetForm(Persons person, Numbers number, Genders gender)
        {
            throw new System.NotImplementedException();
        }
    }
}