using Microsoft.AspNetCore.Mvc;

namespace Tiny_Web_Tool.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard() 
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        } 

        public IActionResult Register() 
        { 
            return View();
        }
        
        public IActionResult Forgot_Password() 
        {
            return View();
        }

        public IActionResult Recover_Password() 
        { 
            return View();  
        }

        public IActionResult Lock_Screen() 
        {
            return View();
        }
    }
}
