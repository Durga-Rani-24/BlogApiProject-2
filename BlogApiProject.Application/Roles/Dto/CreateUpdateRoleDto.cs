using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Application.Roles.Dto
{
    public class CreateUpdateRoleDto
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Name in between 50 characters.")]
        public string Name { get; set; }
    }
}
