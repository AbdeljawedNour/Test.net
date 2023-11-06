using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public  class Personne : Locataire
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
