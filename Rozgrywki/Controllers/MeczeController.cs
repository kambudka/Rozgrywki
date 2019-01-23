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
        List<Mecz> mecze = new List<Mecz>();
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                mecze = session.Query<Mecz>().ToList();

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
                        mecze = session.Query<Mecz>().ToList();
                    }
                }
            }
            catch (Exception exception)
            {

                return View();
            }

            Mecz nowymecz = mecze.Find(x => x.DataMeczu == mecz.DataMeczu);
            StatystykiMeczu nowestatystyki = new StatystykiMeczu();
            nowestatystyki.StatystykiMeczuID = nowymecz.MeczID;
            nowestatystyki.IloscRoznych = 0;
            nowestatystyki.IloscKarnych = 0;
            nowestatystyki.IloscFauli = 0;

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
                        nowymecz.StatystykiMeczuID = nowymecz.MeczID;
                        session.Update(nowymecz);
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

        public ActionResult Edit(int MeczID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var mecz = session.Get<Mecz>(MeczID);

                return View(mecz);

            }
        }
        [HttpPost]
        public ActionResult Edit(int MeczID, Mecz mecz)
        {
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Update(mecz);
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

        public ActionResult Statystyki(int StatystykiMeczuID)
        {

            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {
                var statystyki = session.Get<StatystykiMeczu>(StatystykiMeczuID);
                return View(statystyki);
            }
        }

        public ActionResult EditStatystyki(int StatystykiMeczuID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var statystyki = session.Get<StatystykiMeczu>(StatystykiMeczuID);

                return View(statystyki);

            }
        }

        [HttpPost]
        public ActionResult EditStatystyki(int StatystykiMEczuID, StatystykiMeczu statystyki)
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

        public ActionResult Delete(int MeczID)
        {
            using (NHibernate.ISession session = NHIbernateSession.OpenSession())
            {

                var mecz = session.Get<Mecz>(MeczID);

                return View(mecz);

            }
        }

        [HttpPost]
        public ActionResult Delete(int MeczID, Mecz mecz)
        {
            int StatystykiMeczuID = MeczID;
            try
            {
                using (NHibernate.ISession session = NHIbernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        
                        session.Delete(mecz);
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
                        var statystyki = session.Get<StatystykiMeczu>(StatystykiMeczuID);
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
