﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P013WebSite.Data;
using P013WebSite.Entities;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {
        private readonly DatabaseContext _context;
       

        public ContactsController(DatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = _context.Contacts.ToList();
            return View(model);
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact collection, IFormFile? Form)
        {
            try
            {
                _context.Contacts.Add(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Contacts = new SelectList(_context.Categories.ToList(), "Id", "Name");
            
                return View();
            }
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _context.Contacts.Find(id);

            return View(model);
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contact collection, IFormFile? Form)
        {

               try
            {
                _context.Contacts.Update(collection);       
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)

        {
            var model = _context.Contacts.Find(id);
            return View(model);
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contact collection)
        {
            try
            {
                _context.Contacts.Remove(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}