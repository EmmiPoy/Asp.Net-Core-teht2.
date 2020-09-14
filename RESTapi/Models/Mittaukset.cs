using System;
using System.Collections.Generic;

namespace RESTapi.Models
{
    public partial class Mittaukset
    {
        public long MittausId { get; set; }
        public string Hetu { get; set; }
        public double? Mittaustulos { get; set; }
        public DateTime Mittausaika { get; set; }
        public string Mittasuure { get; set; }
        public long HenkilotId { get; set; }

        public virtual Henkilot Henkilot { get; set; }
    }
}
