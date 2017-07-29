using System;
using System.Collections.Generic;
using VerbiItaliani.Builders;

namespace VerbiItaliani.Collection
{
    public static class VerbsCollection
    {
        private static readonly Dictionary<string, Lazy<Verb>> Verbs = new Dictionary<string, Lazy<Verb>>();
        static VerbsCollection()
        {
            // Вспомогательные глаголы
            CreateVerb("stare", presForms: new[] { "sto", "stai", "sta", "stiamo", "state", "stanno" });
            CreateVerb("essere", presForms: new[] { "sono", "sei", "è", "siamo", "siete", "sono" });
            CreateVerb("avere", presForms:  new[] { "ho", "hai", "ha", "abbiamo", "avete", "hanno" });

            // Прочие
            CreateVerb("andare", presForms: new []{ "vado", "vai", "va", "andiamo", "andate", "vanno" });
            CreateVerb("bere", false, "bev");
            CreateVerb("capire", suffixIsc: true);
            
        }

        private static void CreateVerb(string inf, bool suffixIsc = false, string core = null, string[] presForms = null, bool useEssere = false, string passatoForm = null)
        {
            var lverb = new Lazy<Verb>(() => new Verb(inf, true,
                new PresenteBuilder(inf, suffixIsc, core, presForms),
                new GerundioBuilder(inf, core), 
                new PassatoProssimoBuilder(inf, useEssere, passatoForm))); 
            Verbs.Add(inf, lverb);
        }

        public static Verb Get(string inf)
        {
            if (Verbs.ContainsKey(inf))
                return Verbs[inf].Value;
            return new Verb(inf, false,
                new PresenteBuilder(inf, false, null, null),
                new GerundioBuilder(inf, null), 
                new PassatoProssimoBuilder(inf, false, null));
        }

    }
}