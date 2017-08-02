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
            CreateVerb("accendere", passatoForm: "acceso");
            CreateVerb("accorgere", passatoForm: "accorto");
            CreateVerb("agire", suffixIsc: true);
            CreateVerb("andare", presForms: new[] { "vado", "vai", "va", "andiamo", "andate", "vanno" }, useEssere: true);
            CreateVerb("apparire", presForms: new[] { "appaio", "appari", "appare", "appariamo", "apparite", "appaiono" }, useEssere: true, passatoForm: "apparso");
            CreateVerb("aprire", passatoForm: "aperto");
            CreateVerb("arrabbiare", useEssere: true);
            CreateVerb("arrivare", useEssere: true);
            CreateVerb("bere", false, "bev");
            CreateVerb("cadere", useEssere: true);
            CreateVerb("capire", suffixIsc: true);
            CreateVerb("chiacchierare", useEssere: true);
            CreateVerb("chiedere", passatoForm: "chiesto");
            CreateVerb("chiudere", passatoForm: "chiuso");
            CreateVerb("comporre", passatoForm: "composto");
            CreateVerb("condividere", passatoForm: "condiviso");
            CreateVerb("conoscere", passatoForm: "conosciuto");
            CreateVerb("convincere", passatoForm: "convinto");
            CreateVerb("coprire", passatoForm: "coperto");
            CreateVerb("correggere", passatoForm: "coretto");
            CreateVerb("costare", useEssere: true);
            CreateVerb("costringere", passatoForm: "costretto");
            CreateVerb("costruire", suffixIsc: true);
            CreateVerb("crescere", useEssere: true);
            CreateVerb("cuocere", passatoForm: "cotto");
            CreateVerb("dare", presForms: new[] { "do", "dai", "dà", "diamo", "date", "danno" }, passatoForm: "dato");
            CreateVerb("decidere", passatoForm: "deciso");
            CreateVerb("dimagrire", suffixIsc: true, useEssere: true);
            CreateVerb("dipignere", passatoForm: "dipinto");
            CreateVerb("dire", core: "dic", passatoForm: "detto");
            CreateVerb("diventare", useEssere: true);
            CreateVerb("dovere", presForms: new[] { "devo", "devi", "deve", "dobbiamo", "dovete", "devono" });
            CreateVerb("esistere", useEssere: true);
            CreateVerb("esprimere", passatoForm: "espresso");
            CreateVerb("fare", core: "fac", presForms: new[] { "faccio", "fai", "fa", "facciamo", "fate", "fanno" }, passatoForm: "fatto");
            CreateVerb("fermare", useEssere: true);
            CreateVerb("finire", suffixIsc: true);
            CreateVerb("funzionare", useEssere: true);
            CreateVerb("guarire", suffixIsc: true, useEssere: true);
            CreateVerb("ingrassare", useEssere: true);
            CreateVerb("leggere", passatoForm: "letto");
            CreateVerb("mantenere", presForms: new[] { "mantengo", "mantieni", "mantiene", "manteniamo", "mantenete", "mantengono" });
            CreateVerb("mettere", passatoForm: "messo");
            CreateVerb("morire", presForms: new[] { "muoio", "muori", "muore", "moriamo", "morite", "mupiono" }, useEssere: true, passatoForm: "morto");
            CreateVerb("nascere", passatoForm: "nato", useEssere: true);
            CreateVerb("offrire", passatoForm: "offerto");
            CreateVerb("partire", useEssere: true);
            CreateVerb("piangere", passatoForm: "pianto");
            CreateVerb("porgere", passatoForm: "porto");
            CreateVerb("porre", passatoForm: "posto");
            CreateVerb("potere", presForms: new[] { "posso", "puoi", "può", "possiamo", "potete", "possono" });
            CreateVerb("preferire", suffixIsc: true);
            CreateVerb("prendere", passatoForm: "preso");
            CreateVerb("produrre", passatoForm: "prodotto");
            CreateVerb("proibire", suffixIsc: true);
            CreateVerb("proporre", passatoForm: "proposto");
            CreateVerb("pulire", suffixIsc: true);
            CreateVerb("punire", suffixIsc: true);
            CreateVerb("raccogliere", passatoForm: "raccolto");
            CreateVerb("ricomporre", passatoForm: "ricomposto");
        }

        private static void CreateVerb(string inf, bool suffixIsc = false, string core = null, string[] presForms = null, bool useEssere = false, string passatoForm = null)
        {
            var lverb = new Lazy<Verb>(() => new Verb(inf, true,
                new PresenteBuilder(inf, suffixIsc, core, presForms),
                new GerundioBuilder(inf, core), 
                new PassatoProssimoBuilder(inf, useEssere, passatoForm)));
            var infRef = inf.Remove(inf.Length - 1) + "si";
            var lverbref = new Lazy<Verb>(() => new Verb(infRef, true,
                new PresenteBuilder(infRef, suffixIsc, core, presForms),
                new GerundioBuilder(infRef, core),
                new PassatoProssimoBuilder(infRef, useEssere, passatoForm)));

            Verbs.Add(inf, lverb);
            Verbs.Add(infRef, lverbref);
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