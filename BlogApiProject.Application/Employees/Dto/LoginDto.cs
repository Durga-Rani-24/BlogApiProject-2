using System.ComponentModel.DataAnnotations;

namespace BlogApiProject.Application.Employees.Dto;

public class LoginDto
{
    [Required(ErrorMessage ="Username or Email is Required")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

}
