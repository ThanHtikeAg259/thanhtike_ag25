//<copyright file ="TerminalController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Models;
    using POS_OJT.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="TerminalController" />.
    /// </summary>
    public class TerminalController : Controller
    {
        /// <summary>
        /// Defines the terminalService.
        /// </summary>
        private TerminalService terminalService = new TerminalService();

        // GET: Terminal
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            DataTable dtTerminal = new DataTable();
            dtTerminal = terminalService.GetTerminalList();
           
            return View(dtTerminal);
        }

        // GET: Terminal/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            DataTable dtShop = new DataTable();
            List<Shop> shopList = new List<Shop>();
            dtShop = terminalService.GetShopNameList();

            shopList = (from DataRow dr in dtShop.Rows
                        select new Shop()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString()
                        }).ToList();
            SelectList list = new SelectList(shopList, "id", "name");
            ViewBag.shoplistname = list;
            return View();
        }

        // POST: Terminal/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Terminal terminal = new Terminal();
            terminal.name = collection[1];
            terminal.shop_id = Convert.ToInt32(collection[2]);
            terminal.create_user_id = 1;
            terminal.create_datetime = DateTime.Now;
            terminal.update_user_id = 1;
            terminal.update_datetime = DateTime.Now;
            terminal.is_deleted = 0;

            terminalService.Insert(terminal);
            ViewBag.Message = "Data Added!";
            return RedirectToAction("Index");
        }

        // GET: Terminal/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            DataTable dtShopList = new DataTable();
            List<Shop> shopNameList = new List<Shop>();

            dtShopList = terminalService.GetShopNameList();   
            shopNameList = (from DataRow dr in dtShopList.Rows
                        select new Shop()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString()
                        }).ToList();

            SelectList list = new SelectList(shopNameList, "id", "name");
            ViewBag.shoplistname = list;
            return View(terminalService.GetEdit().Find(item => item.id == id));
        }

        // POST: Terminal/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Terminal terminal = new Terminal();
            terminal.id = id;
            terminal.name = collection[1];
            terminal.shop_id = Convert.ToInt32(collection[2]);
            terminal.update_user_id = 1;
            terminal.update_datetime = DateTime.Now;

            terminalService.Update(terminal);
            return RedirectToAction("Index");
        }

        // POST: Terminal/Delete/5
        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            Terminal terminal = new Terminal();
            terminal.id = id;
            terminal.is_deleted = 1;

            terminalService.Delete(terminal);
            return RedirectToAction("Index");
        }
    }
}
