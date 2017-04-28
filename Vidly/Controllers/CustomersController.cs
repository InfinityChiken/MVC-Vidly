using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return List();
        }


        public ActionResult List()
        {
            var cus_list = _context.Customers.ToList();
            return View(cus_list);
        }


        [Route("Customers/Details/{CustomerID}")]
        public ActionResult Details(int CustomerID)
        {
            var mycustomer = _context.Customers.SingleOrDefault(c => c.Id == CustomerID);
                // _context.Customers.Where(c => c.Id == CustomerID).FirstOrDefault();

            if (mycustomer == null)
            {
                return HttpNotFound();
            }

            return View(mycustomer);
        }



        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}