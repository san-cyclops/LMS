using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string TpNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string WhatsappNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string NIC_SLIN { get; set; }

        [Required]
        [MaxLength(50)]
        public string Designation { get; set; }
         
        [MaxLength(50)]
        public string Status { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
