//<copyright file ="ShopController.cs"  company ="Seattle Consulting Myanmar">
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
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="ShopController" />.
    /// </summary>
    public class ShopController : Controller
    {
        /// <summary>
        /// Defines the shopService.
        /// </summary>
        private ShopService shopService = new ShopService();

        // GET: Shop/Index
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            DataTable dtShop = new DataTable();
            dtShop = shopService.GetShopList();
            return View(dtShop);
        }

        // GET: Shop/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create(Shop shop)
        {
            List<SelectListItem> shopType = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Retails Shop", Value = "1"
                },

                new SelectListItem
                {
                    Text = "Restaurant", Value = "2"
                }
            };
            ViewBag.ShopTypeList = shopType;

            return View(shop);
        }

        // POST: Shop/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Shop shop = new Shop();
            shop.name = collection[1];
            shop.address = collection[3];
            shop.shop_type = Convert.ToInt16(collection[2]);
            shop.phone_number_1 = collection[4];
            shop.phone_number_2 = collection[5];
            shop.is_deleted = 0;
            shop.create_user_id = 1;
            shop.create_datetime = DateTime.Now;
            shop.update_user_id = 1;
            shop.update_datetime = DateTime.Now;
            shop.company_id = 1;

            shopService.Insert(shop);
            return RedirectToAction("Index");
        }

        // GET: Shop/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            var selectShopTypeList = Convert.ToInt16(shopService.GetShopTypeList(id));

            List<SelectListItem> shopType = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Retails Shop", Value = "1", Selected= true ? selectShopTypeList==1 : false
                },

                new SelectListItem
                {
                    Text = "Restaurant", Value = "2", Selected= true ? selectShopTypeList==2 : false
                }
            };

            ViewBag.ShopTypeList = shopType;
            return View(shopService.GetEdit().Find(item => item.id == id));
        }

        // POST: Shop/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Shop shop = new Shop();
            shop.id = id;
            shop.name = collection[1];
            shop.shop_type = Convert.ToInt16(collection[2]);
            shop.address = collection[3];
            shop.phone_number_1 = collection[4];
            shop.phone_number_2 = collection[5];
            shop.update_datetime = DateTime.Now;

            shopService.Update(shop);
            return RedirectToAction("Index");
        }

        // GET: Shop/Delete/5
        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
