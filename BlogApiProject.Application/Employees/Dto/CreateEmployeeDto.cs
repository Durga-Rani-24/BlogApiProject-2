using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApiProject.Application.Employees.Dto
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50,ErrorMessage ="Name in between 50 characters.")]
        public string Name{ get; set; }

        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string Email {  get; set; }

        [Required(ErrorMessage ="Password is Required")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage ="Password must be atleast 6 characters long")]
        public string Password {  get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword {  get; set; }

    }
}
