namespace School_TimeTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Student_Id { get; set; }

        [StringLength(50)]
        public string Student_name { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? subject_id { get; set; }
    }
}
