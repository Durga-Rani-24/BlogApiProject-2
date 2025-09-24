using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApiProject.Domain;

public class Blog
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    [ForeignKey("Employee")]
    public int CreatedByEmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsPublished { get; set; }
}