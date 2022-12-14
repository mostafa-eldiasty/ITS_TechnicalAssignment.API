using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_TechnicalAssignment.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Class { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }

    }
}
