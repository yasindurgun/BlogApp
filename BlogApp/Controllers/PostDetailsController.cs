﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    public class PostDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
