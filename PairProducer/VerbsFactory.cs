using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LingvoNET;
using VerbiItaliani;

namespace PairProducer
{
    public class VerbsFactory
    {
        public IEnumerable<string> GetForms(string ita, string rus)
        {
            var verbs = rus.Split(',');
            if (verbs.Length > 1)
                return GetVerbForms(ita, new[] {verbs[0].Trim(), verbs[1].Trim()});
            verbs = rus.Split(' ');
            if (verbs.Length > 1)
                return GetVerbForms(ita, verbs[0].Trim(), verbs[1].Trim());
            return GetVerbForms(ita, rus);
        }

        private IEnumerable<string> GetVerbForms(string ita, string rus)
        {
            var result = new List<string>();

            var itaForms = GetItaForms(ita);
            var rusForms = GetRusForms(rus);
            var rusPro = GetRusPronouns();
            var tenses = GetTenseNames();

            for (int i = 0; i < itaForms.Count; i++)
                result.Add($"{itaForms[i]};{rusPro[i]} {rusForms[i]} ({tenses[i]})");
            return result;
        }

        private IEnumerable<string> GetVerbForms(string ita, string rus, string rusAdd)
        {
            var result = new List<string>();

            var itaForms = GetItaForms(ita);
            var rusForms = GetRusForms(rus);
            var rusPro = GetRusPronouns();
            var tenses = GetTenseNames();

            for (int i = 0; i < itaForms.Count; i++)
                result.Add($"{itaForms[i]};{rusPro[i]} {rusForms[i]} {rusAdd} ({tenses[i]})");
            return result;
        }

        private IEnumerable<string> GetVerbForms(string ita, string[] rus)
        {
            var result = new List<string>();

            var itaForms = GetItaForms(ita);
            var rusForms = GetRusForms(rus[0]);
            var rusForms1 = GetRusForms(rus[1]);
            var rusPro = GetRusPronouns();
            var tenses = GetTenseNames();

            for (int i = 0; i < itaForms.Count; i++)
                result.Add($"{itaForms[i]};{rusPro[i]} {rusForms[i]}, {rusForms1[i]} ({tenses[i]})");
            return result;
        }


        private List<string> GetItaForms(string ita)
        {
            var itaVerb = VerbiItaliani.Collection.VerbsCollection.Get(ita);
            return new List<string>
            {
                itaVerb.PresenteIndicativo(Persons.First, Numbers.Singular, Genders.M),
                itaVerb.PresenteIndicativo(Persons.Second, Numbers.Singular, Genders.M),
                itaVerb.PresenteIndicativo(Persons.Third, Numbers.Singular, Genders.M),
                itaVerb.PresenteIndicativo(Persons.First, Numbers.Plural, Genders.M),
                itaVerb.PresenteIndicativo(Persons.Second, Numbers.Plural, Genders.M),
                itaVerb.PresenteIndicativo(Persons.Third, Numbers.Plural, Genders.M),

                itaVerb.StarePlusGerundio(Persons.First, Numbers.Singular, Genders.M),

                itaVerb.PassatoProssimo(Persons.First, Numbers.Singular, Genders.M),
            };
        }

        private List<string> GetRusForms(string rus)
        {
            var rusVerb = LingvoNET.Verbs.FindOne(rus);
            var rusPerf = rusVerb.Perfect(Voice.Active);
            if (rusPerf == null)
                rusPerf = rusVerb;

            return new List<string>
            {
                rusVerb[Voice.Active, Person.First, Number.Singular],
                rusVerb[Voice.Active, Person.Second, Number.Singular],
                rusVerb[Voice.Active, Person.Third, Number.Singular],
                rusVerb[Voice.Active, Person.First, Number.Plural],
                rusVerb[Voice.Active, Person.Second, Number.Plural],
                rusVerb[Voice.Active, Person.Third, Number.Plural],

                rusVerb[Voice.Active, Person.First, Number.Singular],

                rusPerf.Past(Voice.Active, Gender.M),
            };
        }

        private List<string> GetRusPronouns()
        {
            return new List<string>
            {
                "я",
                "ты",
                "он",
                "мы",
                "вы",
                "они",

                "я",
  
                "я",
            };
        }

        private List<string> GetTenseNames()
        {
            return new List<string>
            {
                "Presente",
                "Presente",
                "Presente",
                "Presente",
                "Presente",
                "Presente",

                "Stare + Gerundio",

                "Passato Prossimo",
            };
        }

    }
}