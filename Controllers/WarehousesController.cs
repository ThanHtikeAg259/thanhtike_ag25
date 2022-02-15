//<copyright file ="WarehousesController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>9/30/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Models;
    using POS_OJT.Services;
    using System;
    using System.Data;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="WarehousesController" />.
    /// </summary>
    public class WarehousesController : Controller
    {
        /// <summary>
        /// Defines the warehouseService.
        /// </summary>
        private WarehouseService warehouseService = new WarehouseService();
        
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            DataTable dtWarehouse = warehouseService.GetWarehouseList();
            return View(dtWarehouse);
        }

        //Get/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="warehouse">The warehouse<see cref="Warehouse"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create(Warehouse warehouse)
        {
            string warehouseCode = warehouseService.GetWarehouseCode();
            warehouse.name = warehouseCode;
            ModelState.Clear();
            return View(warehouse);
        }

        // POST: Warehouses/Create
        /// <summary>
        /// The CreatePost.
        /// </summary>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(FormCollection collection)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.company_id = 1;
            warehouse.name = collection[1];
            warehouse.address = Convert.ToString(collection[2]);
            warehouse.phone_number_1 = Convert.ToString(collection[3]);
            warehouse.phone_number_2 = Convert.ToString(collection[4]);
            warehouse.create_user_id = 1;
            warehouse.create_datetime = DateTime.Now;
            warehouse.update_user_id = 1;
            warehouse.update_datetime = DateTime.Now;
            warehouse.is_deleted = 0;

            warehouseService.Insert(warehouse);
            ViewBag.Message = "Data Added!";
            return RedirectToAction("Index");
        }

        // GET: Warehouses/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int? id)
        {
            return View(warehouseService.GetEdit().Find(item => item.id == id));
        }

        // POST: Warehouses/Edit/5
        /// <summary>
        /// The EditPost.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, FormCollection collection)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.id = (int)id;
            warehouse.name = collection[2];
            warehouse.address = Convert.ToString(collection[3]);
            warehouse.phone_number_1 = Convert.ToString(collection[4]);
            warehouse.phone_number_2 = Convert.ToString(collection[5]);
            warehouse.update_user_id = 1;
            warehouse.update_datetime = DateTime.Now;

            warehouseService.Update(warehouse);
            return RedirectToAction("Index");
        }
    }
}
