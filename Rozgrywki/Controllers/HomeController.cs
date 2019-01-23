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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var employee = session.Query<Zawodnik>().ToList();

                return View(employee);

            }

        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(Zawodnik zawodnik)
        {
            StatystykiZawodnika nowestatystyki = new StatystykiZawodnika();
            zawodnik.StatystykiZawodnikaID = zawodnik.ZawodnikID;
            nowestatystyki.StatystykiZawodnikaID = zawodnik.ZawodnikID;
            nowestatystyki.IloscPunktow = 0;
            nowestatystyki.IloscGier = 0;
            nowestatystyki.IloscFauli = 0;

            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(zawodnik);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {

                return View();
            }

            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(zawodnik);
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}