using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Depot
    {
        public Depot()
        {
            Approvisionnements = new HashSet<Approvisionnement>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Approvisionnement> Approvisionnements { get; set; }
    }
}
