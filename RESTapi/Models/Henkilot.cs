using System;
using System.Collections.Generic;

namespace RESTapi.Models
{
    public class Henkilot
    {

        public long Id { get; set; }
        public string Hetu { get; set; }
        public string Nimi { get; set; }
        public string Osoite { get; set; }
        public string Puhelinnro { get; set; }
        public string Email { get; set; }

        public virtual List<Mittaukset> Mittaukset { get; set; }
        
    
    }
}
