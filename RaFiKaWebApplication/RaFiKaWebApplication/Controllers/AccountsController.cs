using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaFiKaWebApplication.Models;

namespace RaFiKaWebApplication.Controllers
{
    public class AccountsController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: Accounts
        public ActionResult Index()
        {
            if (Session["Admin"] == "admin")
                return View(db.accounts.ToList());

            return RedirectToAction("ErrorMessage");

        }

        // GET: Accounts/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        ////[Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "AccountId,NameAccount,EmailAccount,PasswordAccount,isAdminAccount")] Account account)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account); ;
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "AccountId,NameAccount,EmailAccount,PasswordAccount,isAdminAccount")] Account account)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.accounts.Find(id);
            db.accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                db.accounts.Add(account);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = account.NameAccount + " Succesefully registered!";
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Login(Account account)
        {
            var user = db.accounts.FirstOrDefault(u => u.NameAccount == account.NameAccount && u.PasswordAccount == account.PasswordAccount);
            System.Web.HttpContext.Current.Session["UserId"] = account.AccountId;

            if (user != null)
            {
                Session["UserName"] = user.NameAccount.ToString();
                ViewBag.message = "Hi" + user.NameAccount;
                Session["Admin"] = user.isAdminAccount;

                if (user.isAdminAccount)
                {
                    Session["Admin"] = "admin";
                    return RedirectToAction("Index");
                }
                else 
                {
                    Session["Admin"] = "user";
                    return RedirectToAction("../Home");
                }
                Session["AccountId"] = user.AccountId.ToString();
                Session["wrong password"] = null;
                
                return RedirectToAction("../Home");
            }
            else
            {
                Session["wrong password"] = true;
                ModelState.AddModelError("", "User name or password is wrong");
            }
            //  return View();
            return View();


        }

        public ActionResult LoggedIn()
        {
            if (Session["UserName"] != null)
            {
                //return View();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult WishList(Account account)
        {

            return View();
        }

        public ActionResult ErrorMessage()
        {
            return View();
        }


    }


}


