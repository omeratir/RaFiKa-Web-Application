using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaFiKaWebApplication.Models;


namespace NewsWebsite.Controllers
{
    public class SearchController : Controller
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: Search
        public ActionResult Index(string name, int? price, int? size, string type)
        {

            //IQueryable<Article> query = null;
            var query = from m in db.products select m;
            ViewBag.isSearched = false;

            if (!String.IsNullOrEmpty(name))
            {
                query = db.products.Where(article => article.NameProduct.Contains(name));
                ViewBag.isSearched = true;
            }

            if (price != null)
            {
                query = query.Where(article => article.PriceProduct == price);
                ViewBag.isSearched = true;
            }

            if (size != null)
            {
                query = query.Where(article => article.SizeProduct == size);
                ViewBag.isSearched = true;
            }


            //if (!String.IsNullOrEmpty(type))
            //{
            //    query = query.Where(article => article.TypeOfProduct.NameProductType.Equals(type));

            //    ViewBag.isSearched = true;
            //}

            if (!ViewBag.isSearched)
            {
                ViewBag.type = db.typesshoes.ToList();
                return View();
            }
            else
            {
                return View(query.ToList());
            }
        }
    }
}