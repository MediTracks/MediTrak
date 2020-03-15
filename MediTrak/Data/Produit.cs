using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Produit
    {
        public Produit()
        {
            Approvisionnements = new HashSet<Approvisionnement>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int? CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Approvisionnement> Approvisionnements { get; set; }
    }
}
