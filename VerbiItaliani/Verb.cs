using System;
using System.Collections.Generic;

namespace VerbiItaliani
{
    public class Verb : IVerb
    {
        public string Infinitivo { get; }

        protected ITenseBuilder PresenteBuilder;
        protected ITenseBuilder GerundioBuilder;
        protected ITenseBuilder PassatoProssimoBuilder;

        public Verb(string inf, ITenseBuilder bldPresente, ITenseBuilder bldGerundio, ITenseBuilder bldPassato)
        {
            Infinitivo = inf.ToLowerInvariant();

            PresenteBuilder = bldPresente;
            GerundioBuilder = bldGerundio;
            PassatoProssimoBuilder = bldPassato;
        }

        public IEnumerable<string> PresenteIndicativo()
        {
            return new List<string>
            {
                PresenteIndicativo(Persons.First, Numbers.Singular, Genders.M),
                PresenteIndicativo(Persons.Second, Numbers.Singular, Genders.M),
                PresenteIndicativo(Persons.Third, Numbers.Singular, Genders.M),
                PresenteIndicativo(Persons.First, Numbers.Plural, Genders.M),
                PresenteIndicativo(Persons.Second, Numbers.Plural, Genders.M),
                PresenteIndicativo(Persons.Third, Numbers.Plural, Genders.M),
            };
        }

        public IEnumerable<string> Gerundio()
        {
            return new List<string>
            {
                Gerundio(Persons.First, Numbers.Singular, Genders.M),
                Gerundio(Persons.Second, Numbers.Singular, Genders.M),
                Gerundio(Persons.Third, Numbers.Singular, Genders.M),
                Gerundio(Persons.First, Numbers.Plural, Genders.M),
                Gerundio(Persons.Second, Numbers.Plural, Genders.M),
                Gerundio(Persons.Third, Numbers.Plural, Genders.M),
            };
        }

        public IEnumerable<string> PassatoProssimo()
        {
            return new List<string>
            {
                PassatoProssimo(Persons.First, Numbers.Singular, Genders.M),
                PassatoProssimo(Persons.Second, Numbers.Singular, Genders.M),
                PassatoProssimo(Persons.Third, Numbers.Singular, Genders.M),
                PassatoProssimo(Persons.First, Numbers.Plural, Genders.M),
                PassatoProssimo(Persons.Second, Numbers.Plural, Genders.M),
                PassatoProssimo(Persons.Third, Numbers.Plural, Genders.M),
            };
        }

        public string PresenteIndicativo(Persons person, Numbers number, Genders gender)
        {
            return PresenteBuilder.GetForm(person, number, gender);
        }

        public string Gerundio(Persons person, Numbers number, Genders gender)
        {
            return GerundioBuilder.GetForm(person, number, gender);
        }

        public string PassatoProssimo(Persons person, Numbers number, Genders gender)
        {
            return PassatoProssimoBuilder.GetForm(person, number, gender);
        }

        
    }
}