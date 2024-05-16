using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnTap_net104.Models;

namespace OnTap_net104.Controllers
{
    public class AccountController : Controller
    {
        //Khoi tao context va tao contructor
        AppDbContext context;
        public AccountController()
        {
            context = new AppDbContext();
        }
        //cac action thuc thi
        public ActionResult Login( string username, string password)
        {
            if (username == null && password == null)
            {
                return View();
            }
            else
            {
                var account = context.Accounts.FirstOrDefault(p => p.Username == username && p.Password == password);
                if (account == null) return Content("Tài khoản bạn đang đăng nhập khum tồn tại");
                else
                {
                    HttpContext.Session.SetString("username",username);// luu username vao session
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        // GET: AccountController/Details/5
        public ActionResult Details(string username)//xem thong tin tk
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Account account)// tạo tài khoản - thục hiện tạo mới account
        {
            try
            {
                context.Accounts.Add(account);
                Cart cart = new Cart()
                { 
                    Username = account.Username,
                    Status = 1,
                    Description = "Dep trai"
                };
                context.Carts.Add(cart);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Create account Successfully";
                return RedirectToAction("Login", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
