using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class CourseType
    {
        public int CourseTypeID { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeCode { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
