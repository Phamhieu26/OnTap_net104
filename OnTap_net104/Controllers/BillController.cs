using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTap_net104.Models;

namespace OnTap_net104.Controllers
{
    public class BillController : Controller
    {
        AppDbContext _context;
        public BillController()
        {
            _context = new AppDbContext();
        }
        // GET: BillController
        public ActionResult Index()
        {
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "Account");// chuyen huong ve trang login
            }
            else
            {
                var data = _context.Bills.Where(p => p.Username == check).ToList();
                return View(data);
            }
                
        }

        // GET: BillController/Details/5
        public ActionResult Details(Guid id)
        {
            var data = _context.BillDetails.Where(p =>p.BillId == id).ToList();

            return View(data);
        }

        // GET: BillController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BillController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var BillDelete = _context.Bills.Find(id);
            BillDelete.Status = 100;
            _context.Bills.Update(BillDelete);
            var BilDelDetail = _context.BillDetails.Where(_ => _.BillId == id).ToList();
            foreach (var item in BilDelDetail)
            {
                item.Status = 100;
                _context.BillDetails.Update(item);
                var product = _context.Products.Find(item.ProductId);
                product.Quantity += item.Quantity;
                _context.Products.Update(product);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: BillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //var deleteItem = _context.Products.Find(id);
        //_context.Products.Remove(deleteItem);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        public ActionResult Edit(Bill bill)
        {
            try
            {
                var editBill = _context.Bills.Find(bill.Id);
                editBill.Status = bill.Status;
                editBill.CreateDate = bill.CreateDate;
                _context.Bills.Update(editBill);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BillController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BillController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
