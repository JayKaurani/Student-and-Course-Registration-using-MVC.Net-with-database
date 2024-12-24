using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataBase_MVC.NET.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Address is required")]
        [StringLength(500,MinimumLength =10,ErrorMessage ="Address insufficient")]
        public String Address { get; set; }

        [Required]
        public String Gender { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }
    }
}