﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Login, string SenhaUsuario)
        {
            if(Autenticacao.VerificaLoginSenha(Login, SenhaUsuario, this))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Erro"] = "Senha Inválida";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
