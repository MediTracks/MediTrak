using System;
using System.Collections.Generic;

namespace MediTrak.Data
{
    public partial class Zone
    {
        public int Id { get; set; }
        public string ZoneCore { get; set; }
        public string Description { get; set; }
        public string Addresse { get; set; }
        public int? VilleId { get; set; }
    }
}
