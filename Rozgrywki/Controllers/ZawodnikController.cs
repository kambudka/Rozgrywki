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
    public class ZawodnikController : Controller
    {
        private List<Zawodnik> zawodnicy;

        // GET: Zawodnik
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                zawodnicy = session.Query<Zawodnik>().ToList();

                return View(zawodnicy);

            }
        }

        public ActionResult Statystyki(int StatystykiZawodnikaID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var statystyki = session.Get<StatystykiZawodnika>(StatystykiZawodnikaID);

                return View(statystyki);

            }
        }

        // GET: Zawodnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zawodnik/Create
        [HttpPost]
        public ActionResult Create(Zawodnik zawodnik)
        {

            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(zawodnik);
                        transaction.Commit();
                        zawodnicy = session.Query<Zawodnik>().ToList();
                    }
                }
                
            }
            catch (Exception exception)
            {
                return View();
            }
            Zawodnik nowyzawodnik = zawodnicy.Find(x => x.Nazwisko == zawodnik.Nazwisko);
            StatystykiZawodnika nowestatystyki = new StatystykiZawodnika();
            nowestatystyki.StatystykiZawodnikaID = nowyzawodnik.ZawodnikID;
            nowestatystyki.IloscFauli = 0;
            nowestatystyki.IloscGier = 0;
            nowestatystyki.IloscPunktow = 0;
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(nowestatystyki);
                        transaction.Commit();
                    }
                }
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
                        nowyzawodnik.StatystykiZawodnikaID = nowyzawodnik.ZawodnikID;
                        session.Update(nowyzawodnik);
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

        // GET: Zawodnik/Edit/5
        public ActionResult Edit(int ZawodnikID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var zawodnik = session.Get<Zawodnik>(ZawodnikID);

                return View(zawodnik);

            }
        }

        // POST: Zawodnik/Edit/5
        [HttpPost]
        public ActionResult Edit(int ZawodnikID, Zawodnik zawodnik)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(zawodnik);
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

        public ActionResult EditStatystyki(int StatystykiZawodnikaID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var statystyki = session.Get<StatystykiZawodnika>(StatystykiZawodnikaID);

                return View(statystyki);

            }
        }

        // POST: Zawodnik/Edit/5
        [HttpPost]
        public ActionResult EditStatystyki(int StatystykiZawodnikaID, StatystykiZawodnika statystyki)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(statystyki);
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

        // GET: Zawodnik/Delete/5
        public ActionResult Delete(int ZawodnikID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                var zawodnik = session.Get<Zawodnik>(ZawodnikID);
                return View(zawodnik);
            }
        }

        // POST: Zawodnik/Delete/5
        [HttpPost]
        public ActionResult Delete(int ZawodnikID, Zawodnik zawodnik)
        {
            int StatystykiZawodnikaID = ZawodnikID;
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(zawodnik);
                        transaction.Commit();
                    }
                }  
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
                        var statystyki = session.Get<StatystykiZawodnika>(StatystykiZawodnikaID);
                        session.Delete(statystyki);
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
    }
}
