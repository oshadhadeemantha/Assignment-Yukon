using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School_TimeTable.Models
{
    public partial class SchedulerContext : DbContext
    {
        public SchedulerContext() : base("name=EventModel") { }
        public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }

        public virtual DbSet<teacher> Teachers { get; set; }
    }
}