﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoFinance_API_Sharp.Controllers
{
    public class testeController : Controller
    {
        // GET: teste
        public ActionResult Index()
        {
            return View();
        }

        // GET: teste/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: teste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teste/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: teste/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: teste/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: teste/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: teste/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
