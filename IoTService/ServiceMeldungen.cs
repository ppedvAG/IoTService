namespace IoTService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceMeldungen")]
    public partial class ServiceMeldungen
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Meldung { get; set; }

        public DateTime? Datum { get; set; }
    }
}
