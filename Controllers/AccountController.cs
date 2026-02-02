using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelpDeskWebapp.Models;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
//using HelpDeskWebapp.Models.RegisterViewModel;

public class AccountController : Controller
{
    private readonly UserManager<User> UserManager;
    private readonly SignInManager<User> SignInManager;
    public AccountController(UserManager<User> um, SignInManager<User> sim)
    {
        UserManager = um;
        SignInManager = sim;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid) //checks required fields of RegisterViewModel
        {
            User u = new User
            {
                Pseudo = model.Pseudo,
                Email = model.Email,
                UserName = model.Email
            };

            //hash + salt
            var res = await UserManager.CreateAsync(u,model.Password);

            if (res.Succeeded) //checks password requirments from Microsoft
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var err in res.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }
        return View(model);
    }
}