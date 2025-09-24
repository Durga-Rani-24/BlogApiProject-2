using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApiProject.Domain;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash {get;set;}
    public bool IsEnabled { get; set; }=true;

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

};
