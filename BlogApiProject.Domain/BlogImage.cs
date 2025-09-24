using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApiProject.Domain;

public class BlogImage
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Blog")]
    public int BlogId { get; set; }

    public Blog Blog { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
