﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
