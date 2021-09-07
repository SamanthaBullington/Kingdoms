using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Models
{
  public class Castle
  {
    // this can be removed later
    public int Id { get; set; }
     [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
  }
}