﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http.Security;
using Microsoft.AspNet.Security.OpenIdConnect;
using Microsoft.AspNet.Security.Cookies;

namespace WebApp_OpenIdConnect_DotNet.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (Context.User == null || !Context.User.Identity.IsAuthenticated)
                Context.Response.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/LogOff
        [HttpGet]
        public IActionResult LogOff()
        {
            if (Context.User.Identity.IsAuthenticated)
                Context.Response.SignOut(new List<string>()
                {
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType
                });
            return RedirectToAction("Index", "Home");
        }
    }
}