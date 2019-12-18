﻿using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DutchTreat.Controllers
{
    public class appController : Controller 
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _context;

        public appController(IMailService mailService, DutchContext context)
        {
            _mailService = mailService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();

        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
           
            //throw new InvalidOperationException("Bad things happen");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send email
                _mailService.SendMessage("mauro.doneda@gmail.com", model.Subject, $"From:{model.Name} - {model.Email}, Message:{model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //show errors
            }

            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Products
                .OrderBy(p=>p.Category)
                .ToList();
            return View(results.ToList());
        }
    }
}
