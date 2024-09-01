using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usersAccounts.Data;
using usersAccounts.Models;

namespace usersAccounts.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Welcome()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var inactiveUsers = context.Users.Where(user => !user.IsActive).ToList();
            return View(inactiveUsers);
        }
        public IActionResult ChangeToActive(Guid id)
        {
            var user =  context.Users.Find(id);
           
            user.IsActive = true;

            context.Update(user);
           context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(x => x.Email == user.Email && x.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction("Index", "Users");
            }
            ViewBag.Error = "Invalid email or password";

            return View(user);
        }
    }
}
