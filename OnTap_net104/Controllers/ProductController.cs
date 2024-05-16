using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTap_net104.Models;

namespace OnTap_net104.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        AppDbContext _context;
        public ProductController()
        {
            _context = new AppDbContext();
        }
        public ActionResult Index()
        {
            var data = _context.Products.ToList();
            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(Guid id)
        {
            var data = _context.Products.Find(id);
            return View(data);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var data = _context.Products.Find(id);

            return View(data);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product product)
        {
            try
            {
                var editProduct = _context.Products.Find(product.ID);
                editProduct.Name = product.Name;
                editProduct.Description = product.Description;
                _context.Products.Update(editProduct);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var deleteItem = _context.Products.Find(id);
            _context.Products.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //Add to cart
        public IActionResult AddToCart(Guid id, int quantity, decimal price)
        {
            //kiem tra xem co dang dang nhap ko, neus ko th bat dang nhap
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check))
            {
                return RedirectToAction("Login", "Account");// chuyen huong ve trang login
            }
            else
            {
                //lay ra tu danh sach cart detail cua user do dang dang nhapxem cos sa pham nao trung id ko
                var CartItem = _context.CartDetails.FirstOrDefault( p  => p.Username == check && p.ProductId == id);
                // ktra item co chua r them moi hoac tang so luong item trong cart
                if (CartItem == null) { 
                    CartDetails details = new CartDetails()
                        { 
                        Id = Guid.NewGuid(),
                        ProductId = id,
                        Username = check,
                        Quantity = quantity,
                        Status = 1,
                        ProductPrice = price
                        };
                    _context.CartDetails.Add(details);
                    _context.SaveChanges();
                }else
                {
                    CartItem.Quantity = CartItem.Quantity + quantity;
                    _context.CartDetails.Update(CartItem);_context.SaveChanges();
                }

            }
            return RedirectToAction("Index", "Product");
        }
        
    }
}
