using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjOrder.Models;

namespace prjOrder.Controllers
{
    public class HomeController : Controller
    {
        dbOrderEntities db = new dbOrderEntities();
        // GET: Home
        public ActionResult Index()
        {
            var orders = db.tOrder.OrderBy(m=>m.order_no).ToList();
            return View(orders);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string order_no, string order_content, DateTime order_date, string order_status, string order_money, string remark )
        {
            tOrder order = new tOrder();
            order.order_no = order_no;
            order.order_content = order_content;
            order.order_date = order_date;
            order.order_status = order_status;
            order.order_money = order_money;
            order.remark = remark;
            db.tOrder.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var order = db.tOrder.Where(m => m.Id == id).FirstOrDefault();
            db.tOrder.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var order = db.tOrder.Where(m => m.Id == id).FirstOrDefault();
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(int id ,string order_no, string order_content, DateTime order_date, string order_status, string order_money, string remark)
        {
            var order = db.tOrder.Where(m => m.Id == id).FirstOrDefault();
            order.order_no = order_no;
            order.order_content = order_content;
            order.order_date = order_date;
            order.order_status = order_status;
            order.order_money = order_money;
            order.remark = remark;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}