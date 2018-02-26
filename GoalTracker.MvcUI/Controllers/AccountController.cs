using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoalTracker.MvcUI.Data;
using Microsoft.AspNetCore.Authentication;

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
