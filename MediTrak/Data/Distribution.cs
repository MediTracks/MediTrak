using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Distribution
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime? DateDistribution { get; set; }
        public int? TransporteurId { get; set; }
        public int? CommandeId { get; set; }
        public int? ApprovisionnementId { get; set; }
        public decimal? Quantite { get; set; }
        public string Description { get; set; }

        public virtual Approvisionnement Approvisionnement { get; set; }
        public virtual Commande Commande { get; set; }
        public virtual Transporteur Transporteur { get; set; }
    }
}
