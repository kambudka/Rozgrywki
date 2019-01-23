using Rozgrywki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace Rozgrywki.Controllers
{
    public class MeczeController : Controller
    {
        // GET: Mecze
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var mecze = session.Query<Mecz>().ToList();

                return View(mecze);

            }
        }

        // GET: Mecze/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mecze/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mecze/Create
        [HttpPost]
        public ActionResult Create(Mecz mecz)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(mecz);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {

                return View();
            }
            
        }

        // GET: Mecze/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mecze/Edit/5
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

        // GET: Mecze/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mecze/Delete/5
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
