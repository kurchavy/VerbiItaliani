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
            CreateVerb("stare", new[] { "sto", "stai", "sta", "stiamo", "state", "stanno" });
            CreateVerb("essere", new[] { "sono", "sei", "è", "siamo", "siete", "sono" });
            CreateVerb("avere", new[] { "ho", "hai", "ha", "abbiamo", "avete", "hanno" });


            CreateVerb("andare", new []{ "vado", "vai", "va", "andiamo", "andate", "vanno" });
            CreateVerb("parlare");
            CreateVerb("prendere");
            CreateVerb("mettersi");
            CreateVerb("credere");
            CreateVerb("bere", false, "bev");
            CreateVerb("dormire");
            CreateVerb("capire", suffixIsc: true);
        }

        private static void CreateVerb(string inf, bool suffixIsc = false, string core = null, bool useEssere = false, string passatoForm = null)
        {
            var lverb = new Lazy<Verb>(() =>
            {
                return new Verb(inf, 
                    new PresenteBuilder(inf, suffixIsc, core),
                    new GerundioBuilder(inf, core), 
                    new PassatoProssimoBuilder(inf, useEssere, passatoForm));
            }); 
            Verbs.Add(inf, lverb);
        }

        private static void CreateVerb(string inf, string[] forms, string core = null, bool useEssere = false, string passatoForm = null)
        {
            var lverb = new Lazy<Verb>(() =>
            {
                return new Verb(inf,
                    new PresenteIrregularBuilder(inf, forms), 
                    new GerundioBuilder(inf, core),
                    new PassatoProssimoBuilder(inf, useEssere, passatoForm));
            });
            Verbs.Add(inf, lverb);
        }

        public static Verb Get(string inf)
        {
            return Verbs[inf].Value;
        }
    }
}