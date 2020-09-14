using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_TimeTable.Models
{
    [Table("Teacher")]
    public class teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int teacher_id { get; set; }

        [StringLength(50)]
        public string teacher_name { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int subject_id { get; set; }

        public bool absent { get; set; }

        public DateTime absentDate { get; set; }
    }
}