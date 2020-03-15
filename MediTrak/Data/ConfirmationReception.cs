using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class ConfirmationReception
    {
        public int Id { get; set; }
        public int? CommandeId { get; set; }
        public DateTime? DateConfirmation { get; set; }
        public decimal? QteRecue { get; set; }
        public string Observations { get; set; }

        public virtual Commande Commande { get; set; }
    }
}
