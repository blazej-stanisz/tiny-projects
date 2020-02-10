using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CheckNetworkLocation.Models;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CheckNetworkLocation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }

        public IActionResult Index()
        {
            var checkUsingDomainAccount = _config.GetValue<string>("AppSettings:CheckUsingDomainAccount");
            var developedBy = _config.GetValue<string>("AppSettings:DevelopedBy");
            ViewData["CheckUsingDomainAccount"] = checkUsingDomainAccount;
            ViewData["DevelopedBy"] = developedBy;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult SomeAction(string inputText)
        {
            _logger.LogInformation($"Checking: \"{inputText}\"");
            bool folderExists = (Directory.Exists(inputText) || System.IO.File.Exists(inputText));
            if (!folderExists)
            {
                _logger.LogError($"Path: \"{inputText}\". No access or path is invalid.");
            }
            else
            {
                _logger.LogInformation($"Path: \"{inputText}\" - OK");
            }
            

            return Json(folderExists);
        }
    }
}
