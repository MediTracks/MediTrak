using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Categorie
    {
        public Categorie()
        {
            Produits = new HashSet<Produit>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descritption { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
