using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS_TechnicalAssignment.DataAccess.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "too many chachters")]
        public string Class { get; set; }

        [Required]
        [MaxLength(150,ErrorMessage ="too many chachters")]
        public string Name { get; set; }

        [Phone(ErrorMessage ="phone no. is not in a correct format")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage ="Email address is not in a correct format")]
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
