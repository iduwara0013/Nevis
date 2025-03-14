using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Data;  // Your ApplicationDbContext namespace
using RegistrationApp.Models; // Your User model namespace
using RegistrationApp.ViewModels; // Your ViewModel namespace
using Microsoft.EntityFrameworkCore; // For DbContext
using System.Threading.Tasks;

namespace RegistrationApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject ApplicationDbContext into the controller
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account/Register
       [HttpGet]
public IActionResult Register()
{
    return View(); // This will show the Register form with RegisterViewModel as the model
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (ModelState.IsValid)
    {
        /*var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == model.Email);

        if (existingUser != null)
        {
            ModelState.AddModelError("Email", "Email is already taken.");
            return View(model);
        }*/

        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = model.Password,
            DateOfBirth = model.DateOfBirth,
            PhoneNumber = model.PhoneNumber
            
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    return View(model); // Return the RegisterViewModel to the view if model is not valid
}


        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // This will show the Login form
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Look for the user in the database by email and password
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // If the user is found, redirect to the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If credentials are incorrect, add error to model and return the login view
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            // If the model is not valid, return the same view with model errors
            return View(model);
        }
    }
}
