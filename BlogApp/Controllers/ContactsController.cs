using BlogApp.Models;
using BlogApp.Repositories;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    public class ContactsController : Controller
    {

        private readonly ContactRepository _contactRepository;
        private readonly SmtpMailService _smtpMailService;


        public ContactsController(ContactRepository cRepo, SmtpMailService smtpMailService)
        {
            _contactRepository = cRepo;

            _smtpMailService = smtpMailService;


        }


        [HttpGet]
        public ActionResult AddContact()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddContact(Contact c)
        {
            _contactRepository.Add(c);
            _smtpMailService.SendEmail("bitirmeprojesi55@gmail.com", "enesturhan9@gmail.com", "Mesaj gönderildi", "Basarlı bir şekilde mesaj gönderildi");


            return View();
        }
    }
}