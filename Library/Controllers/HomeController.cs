using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  public class HomeController : Controllers
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
      Author[] author = _db.Authors.ToArray();
      Dictionary<string, object[]> model = new Dictonary<string, object[]>();
      model.Add("authors", authors);
      string userId = this.User.FindFirst(ClainTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
      {
        Book[] books = _db.Books.Where(entry => entry.User.Id == currentUser.Id).ToArray();
        model.Add("books", books);
      }
      return ViewModels(model);
    }
  }
}
