namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LectureId { get; set; }

      //  [Required]
        [StringLength(255)]
        [Required(ErrorMessage = " Khong duoc de trong")]
        public string Place { get; set; }
        [Required(ErrorMessage =" Khong duoc de trong")]
        public DateTime Datetime { get; set; }

        public int CategoryId { get; set; }
       // public string Name { get; internal set; }

        //add List Category
        public List<Category> ListCategory = new List<Category>();
    }
}
 