using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Transporteur
    {
        public Transporteur()
        {
            Distributions = new HashSet<Distribution>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Distribution> Distributions { get; set; }
    }
}
