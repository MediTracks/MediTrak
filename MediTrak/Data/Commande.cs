using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Commande
    {
        public Commande()
        {
            ConfirmationReceptions = new HashSet<ConfirmationReception>();
            Distributions = new HashSet<Distribution>();
        }

        public int Id { get; set; }
        public string NumCommand { get; set; }
        public DateTime? Date { get; set; }
        public int? StructureId { get; set; }

        public virtual ICollection<ConfirmationReception> ConfirmationReceptions { get; set; }
        public virtual ICollection<Distribution> Distributions { get; set; }
    }
}
