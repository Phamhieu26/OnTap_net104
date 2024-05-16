using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OnTap_net104.Models;

namespace OnTap_net104.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context;
        public CartController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            //Kiem tra du lieu dang nhap
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "Account");// chuyen huong ve trang login
            }
            else
            {
                var allCartItem = _context.CartDetails.Where(p => p.Username == check).ToList();
                return View(allCartItem);
            }
        }
        
        // POST: ProductController/Create
        
            public ActionResult AddToBill(/*List<CartDetails> details*/)
            {
                var check = HttpContext.Session.GetString("username");
                if (String.IsNullOrEmpty(check))
                {
                    return RedirectToAction("Login", "Account");// chuyen huong ve trang login
                }
                else
                {
                var CartItem = _context.CartDetails.FirstOrDefault(p => p.Username == check);
                if (CartItem == null) return Content("Trong giỏ có gì đâu mà mua???");
                    else
                    {
                        Bill bill = new Bill() { Id = Guid.NewGuid(), Status = 1, Username = check, CreateDate = DateTime.Today };
                    _context.Bills.Add(bill);
                    _context.SaveChanges();
                        foreach (var item in _context.CartDetails.Where(p => p.Username == check).ToList())
                        {
                            BillDetail detail = new BillDetail() {Id = Guid.NewGuid(), BillId = bill.Id, ProductId = item.ProductId, ProductPrice = item.ProductPrice, Quantity = item.Quantity,Status =1 };
                        var data = _context.Products.FirstOrDefault(p => p.ID == detail.ProductId);
                            data.Quantity = data.Quantity - detail.Quantity;
                            _context.BillDetails.Add(detail);
                            _context.CartDetails.Remove(item);
                        }
                        _context.SaveChanges();
                    }
                }
            return RedirectToAction("Index", "Bill");
            }
    }
}
