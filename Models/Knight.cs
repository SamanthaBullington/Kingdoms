  using System.ComponentModel.DataAnnotations;

namespace Kingdoms.Models
{
  public class Knight
  {
    // this can be removed later
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public string Weapon { get; set; }
    private bool _roundTable;
    // Creates a flag to identify if the value of a bool was changed during creation [FromBody]
    internal bool RoundTableWasSet { get; private set; }
    public bool RoundTable
    {
      get
      {
        return _roundTable;
      }
      set
      {
        _roundTable = value;
        RoundTableWasSet = true;
      }
    }
  }
}