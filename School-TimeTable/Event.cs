namespace School_TimeTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int id { get; set; }

        [StringLength(256)]
        public string text { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}
