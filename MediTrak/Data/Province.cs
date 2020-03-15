using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Province
    {
        public Province()
        {
            Villes = new HashSet<Ville>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ville> Villes { get; set; }
    }
}
