﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.AdminApp.Services;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace eShopSolution.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var session = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                BearerToken = session,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userApiClient.GetUserPaging(request);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var token = await _userApiClient.Authenticate(request);

            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };

            HttpContext.Session.SetString("Token", token);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties
            );

            return RedirectToAction("Index", "Home");
        }

        //Hàm giải mã
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            //SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,

                ValidAudience = _configuration["Tokens:Issuer"],
                ValidIssuer = _configuration["Tokens:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]))
            };

            var principal =
                new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out _);
            //var principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Login", "User");
        }
    }
}