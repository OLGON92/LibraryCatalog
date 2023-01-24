using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
  public class Book
  {
    public int BookId { get; set; }
    [Required(ErrorMessage = "The title must be filled out")]
    public string Title { get; set;}
    [Required(ErrorMessage = "The genre must be filled out")]
    public string Genre { get; set; }
    public List<AuthorBook> JoinEntities { get; }
    public ApplicationUser User { get; set; }
    
  }
}