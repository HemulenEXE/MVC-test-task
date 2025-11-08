using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace TestMvc.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IConfiguration config, ILogger<AccountController> logger)
        {
            _config = config;
            _logger = logger;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            string cfgUser = _config["AdminCredentials:Username"] ?? "admin";
            string cfgPass = _config["AdminCredentials:Password"] ?? "12345";

            if (username == cfgUser && password == cfgPass)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                _logger.LogWarning("Пользователь залогинился");
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Error = "Неверный логин и/или парольт";
            _logger.LogWarning("Попытка входа с некоректными данными!");
            return View();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation("Пользователь разлогинился");
            return RedirectToAction("Login");
        }
    }
}