using System;
using System.Collections.Generic;

namespace VerbiItaliani
{
    public interface IVerb
    {
        string Infinitivo { get; }
        
        IEnumerable<string> PresenteIndicativo();
        IEnumerable<string> Gerundio();
        IEnumerable<string> PassatoProssimo();

        string PresenteIndicativo(Persons person, Numbers number, Genders gender);
        string Gerundio(Persons person, Numbers number, Genders gender);
        string PassatoProssimo(Persons person, Numbers number, Genders gender);
    }
}