using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GoalTracker.MvcUI.Controllers
{
  [Route("[controller]/[action]")]
  public class AccountController : Controller
  {
    private readonly ILogger _logger;

    public AccountController(ILogger<AccountController> logger)
    {
      _logger = logger;
    }

    public async Task Logout()
    {
      //await _signInManager.SignOutAsync();
      await HttpContext.SignOutAsync("Cookies");
      await HttpContext.SignOutAsync("oidc");
      _logger.LogInformation("User logged out.");
      // return RedirectToPage("/Index");
    }
  }
}
