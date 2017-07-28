using System;

namespace VerbiItaliani.Builders
{
    public abstract class BaseBuilder 
    {
        protected readonly string Infinitive;
        protected Conjugations Conjugation;
        protected VerbTypes Type;
        protected string Core;

        protected string[] ReflexiveParticles = {"mi ", "ti ", "si ", "ci ", "vi ", "si "};

        protected BaseBuilder(string inf)
        {
            Infinitive = inf;
            FindProperties();
        }

        protected int GetIndex(Persons person, Numbers number)
        {
            return (int) person + (int) number * 3;
        }

        private void FindProperties()
        {
            if (Infinitive.EndsWith("si"))
            {
                Type = VerbTypes.Reflexive;
                if (Infinitive.EndsWith("arsi"))
                    Conjugation = Conjugations.I;
                else if (Infinitive.EndsWith("ersi"))
                    Conjugation = Conjugations.II;
                else if (Infinitive.EndsWith("irsi"))
                    Conjugation = Conjugations.III;
                else
                {
                    throw new ArgumentException($"Unknown infinitive ending: {Infinitive}");
                }
                Core = Infinitive.Remove(Infinitive.Length - 4);
            }
            else
            {
                Type = VerbTypes.Normal;
                if (Infinitive.EndsWith("are"))
                    Conjugation = Conjugations.I;
                else if (Infinitive.EndsWith("ere"))
                    Conjugation = Conjugations.II;
                else if (Infinitive.EndsWith("ire"))
                    Conjugation = Conjugations.III;
                else if (Infinitive.EndsWith("urre"))
                    Conjugation = Conjugations.URRE;
                else if (Infinitive.EndsWith("orre"))
                    Conjugation = Conjugations.ORRE;
                else
                {
                    throw new ArgumentException($"Unknown infinitive ending: {Infinitive}");
                }
                Core = Infinitive.Remove(Infinitive.Length - 3);
            }
        }
    }
}