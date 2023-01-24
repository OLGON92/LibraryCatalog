using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    [Required(ErrorMessage = "The authors name must be filled out")]
    public string Name { get; set; }
    public List<AuthorBook> JoinEntities { get; }
  }
}