using System;
using System.Collections.Generic;

namespace VerbiItaliani
{
    public class Verb : IVerb
    {
        public string Infinitivo { get; }

        public bool IsInDictionary { get; }

        protected ITenseBuilder PresenteBuilder;
        protected ITenseBuilder GerundioBuilder;
        protected ITenseBuilder PassatoProssimoBuilder;

        public Verb(string inf, bool isInDictionary, ITenseBuilder bldPresente, ITenseBuilder bldGerundio, ITenseBuilder bldPassato)
        {
            Infinitivo = inf.ToLowerInvariant();

            IsInDictionary = isInDictionary;

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

        public IEnumerable<string> StarePlusGerundio()
        {
            return new List<string>
            {
                StarePlusGerundio(Persons.First, Numbers.Singular, Genders.M),
                StarePlusGerundio(Persons.Second, Numbers.Singular, Genders.M),
                StarePlusGerundio(Persons.Third, Numbers.Singular, Genders.M),
                StarePlusGerundio(Persons.First, Numbers.Plural, Genders.M),
                StarePlusGerundio(Persons.Second, Numbers.Plural, Genders.M),
                StarePlusGerundio(Persons.Third, Numbers.Plural, Genders.M),
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

        public string StarePlusGerundio(Persons person, Numbers number, Genders gender)
        {
            return GerundioBuilder.GetForm(person, number, gender);
        }

        public string PassatoProssimo(Persons person, Numbers number, Genders gender)
        {
            return PassatoProssimoBuilder.GetForm(person, number, gender);
        }

        
    }
}