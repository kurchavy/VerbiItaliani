using System;
using System.Collections.Generic;

namespace VerbiItaliani
{
    public interface IVerb
    {
        string Infinitivo { get; }
        
        IEnumerable<string> PresenteIndicativo();
        IEnumerable<string> StarePlusGerundio();
        IEnumerable<string> PassatoProssimo();

        string PresenteIndicativo(Persons person, Numbers number, Genders gender);
        string StarePlusGerundio(Persons person, Numbers number, Genders gender);
        string PassatoProssimo(Persons person, Numbers number, Genders gender);
    }
}