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
    public class DruzynaController : Controller
    {
        // GET: Druzyna
        List<Druzyna> druzyny = new List<Druzyna>();
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                druzyny = session.Query<Druzyna>().ToList();

                return View(druzyny);
            }
        }

        // GET: Druzyna/Details/5
        public ActionResult DetailsStatystyki(int StatystykiDruzynyID)
        {

            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                var statystyki = session.Get<StatystykiDruzyny>(StatystykiDruzynyID);
                return View(statystyki);
            }
        }

        public ActionResult DetailsSklad(int SkladID)
        {

            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                var objEmployee = session.Get<Druzyna>(SkladID);
                return View(objEmployee);
            }
        }

        // GET: Druzyna/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Druzyna/Create
        [HttpPost]
        public ActionResult Create(Druzyna druzyna)
        {
            string message;
            Druzyna duplikat = new Druzyna();
            duplikat = druzyny.FirstOrDefault(x => x.Nazwa == druzyna.Nazwa);

            if (duplikat != null)
                    return View();

            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(druzyna);



                        transaction.Commit();
                        druzyny = session.Query<Druzyna>().ToList();
                    }
                }
            }
            catch (Exception exception)
            {
                return View();
            }

            Druzyna nowadruzyna = druzyny.Find(x => x.Nazwa == druzyna.Nazwa);


            StatystykiDruzyny nowestatystyki = new StatystykiDruzyny();
            nowestatystyki.StatystykiDruzynyID = nowadruzyna.DruzynaID;
            nowestatystyki.IloscMeczy = 0;
            nowestatystyki.IloscWygranychMeczy = 0;
            Sklad nowysklad = new Sklad();
            nowysklad.SkladID = nowadruzyna.DruzynaID;
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {

                        session.Save(nowysklad);
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
                        nowadruzyna.StatystykiDruzynyID = nowadruzyna.DruzynaID;
                        nowadruzyna.SkladID = nowadruzyna.DruzynaID;
                        session.Update(nowadruzyna);
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

        // GET: Druzyna/Create
        public ActionResult CreateTyp()
        {
            return View();
        }

        // POST: Druzyna/Create
        [HttpPost]
        public ActionResult CreateTyp(TypDruzyny typdruzyny)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(typdruzyny);
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

        // GET: Druzyna/Edit/5
        public ActionResult Edit(int DruzynaID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var druzyna = session.Get<Druzyna>(DruzynaID);

                return View(druzyna);

            }
        }

        // POST: Druzyna/Edit/5
        [HttpPost]
        public ActionResult Edit(int DruzynaID, Druzyna druzyna)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(druzyna);
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

        // GET: Druzyna/Details/5
        public ActionResult Statystyki(int StatystykiDruzynyID)
        {

            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                var statystyki = session.Get<StatystykiDruzyny>(StatystykiDruzynyID);
                return View(statystyki);
            }
        }

        // GET: Druzyna/Edit/5
        public ActionResult EditStatystyki(int StatystykiDruzynyID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var statystyki = session.Get<StatystykiDruzyny>(StatystykiDruzynyID);

                return View(statystyki);

            }
        }

        // POST: Druzyna/Edit/5
        [HttpPost]
        public ActionResult EditStatystyki(int StatystykiDruzynyID, StatystykiDruzyny statystyki)
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

        // GET: Druzyna/Edit/5
        public ActionResult Sklad(int id)
        {
            return View();
        }

        public ActionResult CreateSklad()
        {
            return View();
        }

        // POST: Druzyna/Create
        [HttpPost]
        public ActionResult CreateSklad(Sklad sklad)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(sklad);
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


        // GET: Druzyna/Delete/5
        public ActionResult Delete(int DruzynaID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var druzyna = session.Get<Druzyna>(DruzynaID);

                return View(druzyna);

            }
        }

        // POST: Druzyna/Delete/5
        [HttpPost]
        public ActionResult Delete(int DruzynaID, Druzyna druzyna)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(druzyna);
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
