namespace VerbiItaliani
{
    public interface ITenseBuilder
    {
        string GetForm(Persons person, Numbers number, Genders gender);
    }
}