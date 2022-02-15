//<copyright file ="CategoryController.cs"  company ="Seattle Consulting Myanmar">
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
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="CategoryController" />.
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// Defines the categoryService.
        /// </summary>
        private CategoryService categoryService = new CategoryService();

        /// <summary>
        /// Defines the shopService.
        /// </summary>
        private ShopService shopService = new ShopService();

        /// <summary>
        /// Defines the parentCategoryList.
        /// </summary>
        private DataTable parentCategoryList = new DataTable();

        /// <summary>
        /// Defines the category.
        /// </summary>
        private Category category;

        //GET: Category
        /// <summary>
        /// The Index.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                id = 0;
            }

            DataTable dtCategory = categoryService.GetCategoryList(id);
            List<SelectListItem> categoryList = new List<SelectListItem>();

            for (int i = 0; i < dtCategory.Rows.Count; i++)
            {
                categoryList.Add(new SelectListItem { Text = dtCategory.Rows[i]["name"].ToString(), Value = dtCategory.Rows[i]["id"].ToString() });
            }

            ViewBag.Category = categoryList;

            return View(dtCategory);
        }

        // GET: Category/Details/5
        /// <summary>
        /// The Details.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Details(int? id)
        {
            return View();
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        // GET: Category/Create
        public ActionResult Create(Category category)
        {
            parentCategoryList = categoryService.GetParentCategory();
            DataTable dtShop = categoryService.GetShopList();
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> shopList = new List<SelectListItem>();

            for (int i = 0; i < parentCategoryList.Rows.Count; i++)
            {
                items.Add(new SelectListItem
                {
                    Text = parentCategoryList.Rows[i]["name"].ToString(),
                    Value = parentCategoryList.Rows[i]["id"].ToString()
                });
            }

            for (int i = 0; i < dtShop.Rows.Count; i++)
            {
                shopList.Add(new SelectListItem { Text = dtShop.Rows[i]["name"].ToString(), Value = dtShop.Rows[i]["id"].ToString() });
            }

            Category model = new Category();
            model.CategoriesList = items.ToList();
            ViewBag.ShopList = shopList;
            return View(model);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            category = new Category();
            DataTable dtCategory = categoryService.GetCategoryList(id);

            if (dtCategory.Rows.Count > 0)
            {
                category.name = dtCategory.Rows[0]["name"].ToString();
                category.id = Convert.ToInt32(dtCategory.Rows[0]["id"]);
                category.description = dtCategory.Rows[0]["description"].ToString();
            }

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,parent_category_id,name,description,is_deleted,create_user_id,create_datetime,update_user_id,update_datetime,company_id")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.update_datetime = DateTime.Now;
                categoryService.Update(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            DataTable dtCategory = categoryService.GetCategoryList(id);
            category = new Category();
            category.id = id;
            category.is_deleted = 1;

            categoryService.Delete(category);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="categoryEntity">The categoryEntity<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Insert(FormCollection categoryEntity)
        {
            category = new Category();
            ShopCategory shopCate = new ShopCategory();
            string strDDLValue2 = Request.Form["ddlShop"].ToString();
            string strDDLValue3 = Request.Form["parent_category_id"].ToString();

            category.name = categoryEntity[0];

            if (!String.IsNullOrEmpty(strDDLValue3))
            {
                category.parent_category_id = Convert.ToInt32(strDDLValue3);
            }

            category.description = categoryEntity[3];
            category.company_id = 1;
            category.is_deleted = 0;
            category.create_datetime = DateTime.Now;
            category.update_datetime = DateTime.Now;
            category.create_user_id = 1;
            category.update_user_id = 1;

            string[] arrayval = strDDLValue2.Split(',');
            shopCate.create_datetime = DateTime.Now;
            shopCate.update_datetime = DateTime.Now;
            shopCate.create_user_id = 1;
            shopCate.update_user_id = 1;

            categoryService.Insert(category, shopCate, arrayval);
            ViewBag.Message = "Data Insert Successfully";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Search()
        {
            int cateId = Convert.ToInt32(Request.Form["ddl"].ToString());

            return RedirectToAction("Index", "Category", new { ID = cateId });
        }
    }
}
