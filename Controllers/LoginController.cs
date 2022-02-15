//<copyright file ="LoginController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>9/30/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Models;
    using POS_OJT.Services;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="LoginController" />.
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Defines the loginService.
        /// </summary>
        LoginService loginService = new LoginService();

        // GET: Login
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            Staff staff = new Staff();
            return View(staff);
        }

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Login(Staff staff)
        {
            var password = loginService.GetPassword(staff.staff_number);

            if (password == null)
            {
                Response.Write("<script language=javascript>alert('User number or password is incorrect.')</script>");
                return View("Index", staff);
            }
            else
            {
                var isValid = loginService.ValidatePassword(staff.password, password.ToString());
                if (!isValid)
                {
                    Response.Write("<script language=javascript>alert('User number or password is incorrect.')</script>");
                    return View("Index");
                }

                Session["username"] = staff.staff_number;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        /// <summary>
        /// The LogOut.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult LogOut()
        {
            string username = Session["username"].ToString();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
