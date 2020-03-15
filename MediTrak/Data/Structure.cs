using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Structure
    {
        public Structure()
        {
            InverseZone = new HashSet<Structure>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public int? ZoneId { get; set; }

        public virtual Structure Zone { get; set; }
        public virtual ICollection<Structure> InverseZone { get; set; }
    }
}
