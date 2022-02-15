//<copyright file ="ProductController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Controllers
{
    using OfficeOpenXml;
    using POS_OJT.Config;
    using POS_OJT.Models;
    using POS_OJT.Properties;
    using POS_OJT.Services;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Defines the <see cref="ProductController" />.
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the productService.
        /// </summary>
        private ProductService productService = new ProductService();

        /// <summary>
        /// Defines the dtCategory, dtShop.
        /// </summary>
        DataTable dtCategory = new DataTable(),
                      dtShop = new DataTable();

        /// <summary>
        /// Defines the categoryList.
        /// </summary>
        List<SelectListItem> categoryList = new List<SelectListItem>();

        /// <summary>
        /// Defines the shopList.
        /// </summary>
        List<SelectListItem> shopList = new List<SelectListItem>();

        /// <summary>
        /// Defines the product.
        /// </summary>
        Product product;

        /// <summary>
        /// Defines the shopProduct.
        /// </summary>
        ShopProduct shopProduct;

        /// <summary>
        /// Defines the arrShop.
        /// </summary>
        ArrayList arrShop = new ArrayList();

        /// <summary>
        /// The Index.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index(int? id, string name)
        {
            DataTable dtProduct = new DataTable();
            List<SelectListItem> productList = new List<SelectListItem>();

            if (id == null)
            {
                id = 0;
            }

            dtProduct = productService.GetProductList(id, name);

            for (int i = 0; i < dtProduct.Rows.Count; i++)
            {
                productList.Add(new SelectListItem { Text = dtProduct.Rows[i]["product_category"].ToString(), Value = dtProduct.Rows[i]["id"].ToString() });
            }

            ViewBag.Product = productList;

            return View(dtProduct);
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Search()
        {
            int productType = Convert.ToInt32(Request.Form["ddl"]);
            string productName = Request.Form["Name"];

            return RedirectToAction("Index", "Product", new { ID = productType, name = productName });
        }

        /// <summary>
        /// The ImportCSV.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult ImportCSV()
        {
            string uploadedFile = Request.Form["FileUpload"];
            return RedirectToAction("Index", "Product", new { File = uploadedFile });
        }

        // GET: Product/Details/5
        /// <summary>
        /// The Details.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();


            dtCategory = productService.GetCateList();
            dtShop = productService.GetShopList();

            for (int i = 0; i < dtCategory.Rows.Count; i++)
            {
                categoryList.Add(new SelectListItem { Text = dtCategory.Rows[i]["name"].ToString(), Value = dtCategory.Rows[i]["id"].ToString() });
            }
            for (int i = 0; i < dtShop.Rows.Count; i++)
            {
                shopList.Add(new SelectListItem { Text = dtShop.Rows[i]["name"].ToString(), Value = dtShop.Rows[i]["id"].ToString() });
            }

            ViewBag.CateList = categoryList;
            ViewBag.ShopList = shopList;
            return View();
        }

        // POST: Product/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// The ReadExcel.
        /// </summary>
        /// <param name="upload">The upload<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult ReadExcel(HttpPostedFileBase upload)
        {
            DataTable dtExcel = new DataTable();
            if (Path.GetExtension(upload.FileName) == ".xlsx" || Path.GetExtension(upload.FileName) == ".xls")
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(upload.InputStream);

                dtExcel = ExcelPackageExtensions.ToDataTable(package);
                DataTable dtCate = productService.JustCategory();
                product = new Product();
                foreach (DataRow row in dtExcel.Rows)
                {
                    var res = (from result in dtCate.AsEnumerable()
                               where result.Field<string>("name") == row["Category"].ToString()
                               select new
                               {
                                   categoryID = result.Field<int>("id"),
                                   ParentCategoryID = result.Field<int>("parent_category_id")
                               }).ToList();

                    if (res.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        var cateID = res[0].categoryID;
                        var pID = res[0].ParentCategoryID;
                        var productCode = productService.GetProductCode(Convert.ToInt32(cateID));
                        var productName = row["ProductName"];
                        var category = row["Category"];
                        var MFDDate = row["MFDDate"].ToString();
                        var ExpiredDate = row["ExpiredDate"].ToString();
                        var Description = row["Description"];
                        var Minimumqty = row["Minimumqty"];
                        var salePrice = row["SalePrice"];

                        List<Product> productList = new List<Product>();
                        product.product_type_id = cateID;
                        product.product_code = productCode;
                        product.name = productName.ToString();

                        if (MFDDate == string.Empty)
                        {
                            product.mfd_date = null;
                        }
                        else
                        {
                            product.mfd_date = Convert.ToDateTime(MFDDate);
                        }
                        if (ExpiredDate == string.Empty)
                        {
                            product.expire_date = null;
                        }
                        else
                        {
                            product.expire_date = Convert.ToDateTime(ExpiredDate);
                        }

                        product.short_name = "s";
                        product.description = Description.ToString();
                        product.minimum_quantity = Convert.ToInt32(Minimumqty);
                        product.sale_price = Convert.ToDecimal(salePrice);
                        product.product_status = 1;
                        product.company_id = 1;
                        product.create_datetime = DateTime.Now;
                        product.update_datetime = DateTime.Now;
                        product.create_user_id = 1;
                        product.update_user_id = 1;
                        productList.Add(product);
                        foreach (var item in productList)
                        {
                            productService.InsertList(item);
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Product", new { ID = 0, name = string.Empty });
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="search">The search<see cref="string"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id, string search)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            shopProduct = new ShopProduct();
            dtCategory = productService.GetProductList(id, search);
            product = new Product();
            product.id = Convert.ToInt32(dtCategory.Rows[0]["pid"]);
            product.name = dtCategory.Rows[0]["name"].ToString();
            product.short_name = dtCategory.Rows[0]["short_name"].ToString();
            int productCategory = Convert.ToInt32(dtCategory.Rows[0]["product_type_id"]);
            var category = productService.ShowProduct(productCategory);

            for (int i = 0; i < category.Rows.Count; i++)
            {
                categoryList.Add(new SelectListItem { Text = category.Rows[i]["name"].ToString() });
            }
            product.sale_price = Convert.ToInt32(dtCategory.Rows[0]["sale_price"]);
            product.product_image_path = dtCategory.Rows[0]["product_image_path"].ToString();
            product.minimum_quantity = Convert.ToInt32(dtCategory.Rows[0]["minimum_quantity"]);
            if (dtCategory.Rows[0]["mfd_date"].ToString() == string.Empty)
            {
                product.mfd_date = null;
            }
            else
            {
                product.mfd_date = Convert.ToDateTime(dtCategory.Rows[0]["mfd_date"]);
            }

            if (dtCategory.Rows[0]["expire_date"].ToString() == string.Empty)
            {
                product.expire_date = null;
            }
            else
            {
                product.expire_date = Convert.ToDateTime(dtCategory.Rows[0]["expire_date"]);
            }

            product.description = dtCategory.Rows[0]["description"].ToString();

            var shop = productService.GetShopList();
            var selectShopList = productService.GetSelectShopList(Convert.ToInt32(dtCategory.Rows[0]["pid"]));
            List<SelectListItem> shopList = new List<SelectListItem>();
            for (int i = 0; i < shop.Rows.Count; i++)
            {
                shopList.Add(new SelectListItem { Text = shop.Rows[i]["name"].ToString(), Value = shop.Rows[i]["id"].ToString() });
            }
            Session["shoplist"] = shopList;
            Session["categorylist"] = categoryList;
            List<SelectListItem> selectedShopList = new List<SelectListItem>();
            for (int i = 0; i < selectShopList.Rows.Count; i++)
            {
                selectedShopList.Add(new SelectListItem { Value = selectShopList.Rows[i]["shop_id"].ToString() });
            }
            ViewBag.selectshop = selectedShopList;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_type_id,product_code, barcode, name, short_name, sale_price, description,product_image_path,mfd_date, expire_date, minimum_quantity, product_status, create_user_id,create_datetime,update_user_id,update_datetime,company_id")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.update_datetime = DateTime.Now;
                productService.Update(product);
                return RedirectToAction("Index", "Product", new { ID = 0, name = string.Empty });
                //return RedirectToAction("Index");
            }
            return View(product);
        }

        /// <summary>
        /// The Clone.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="search">The search<see cref="string"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Clone(int id, string search)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            dtCategory = productService.GetProductList(id, search);

            shopProduct = new ShopProduct();

            product.id = Convert.ToInt32(dtCategory.Rows[0]["pid"]);
            product.name = dtCategory.Rows[0]["name"].ToString();
            product.short_name = dtCategory.Rows[0]["short_name"].ToString();
            product.product_type_id = Convert.ToInt32(dtCategory.Rows[0]["product_type_id"]);

            string productCode = productService.GetProductCode(product.product_type_id);
            product.product_code = productCode;
            product.product_image_path = dtCategory.Rows[0]["product_image_path"].ToString();
            int productCategory = Convert.ToInt32(dtCategory.Rows[0]["product_type_id"]);
            var category = productService.ShowProduct(productCategory);

            for (int i = 0; i < category.Rows.Count; i++)
            {
                categoryList.Add(new SelectListItem { Text = category.Rows[i]["name"].ToString() });
            }
            product.sale_price = Convert.ToInt32(dtCategory.Rows[0]["sale_price"]);
            product.minimum_quantity = Convert.ToInt32(dtCategory.Rows[0]["minimum_quantity"]);
            product.mfd_date = Convert.ToDateTime(dtCategory.Rows[0]["mfd_date"]);
            product.expire_date = Convert.ToDateTime(dtCategory.Rows[0]["expire_date"]);
            product.description = dtCategory.Rows[0]["description"].ToString();

            dtShop = productService.GetShopList();

            for (int i = 0; i < dtShop.Rows.Count; i++)
            {
                shopList.Add(new SelectListItem { Text = dtShop.Rows[i]["name"].ToString(), Value = dtShop.Rows[i]["id"].ToString() });
            }

            Session["shoplist"] = shopList;
            Session["categorylist"] = categoryList;

            string basePath = connection.GetIniString("ImageFolder", "PRODUCT_IMAGE_PATH", Constant.FILEPATH);
            string productPath = connection.GetIniString("ProductImageFolder", "PRODUCT_PATH", Constant.FILEPATH);
            product.product_status = 1;
            product.company_id = 1;
            product.create_datetime = DateTime.Now;
            product.update_datetime = DateTime.Now;
            product.create_user_id = 1;
            product.update_user_id = 1;

            //var idList = dtShop.AsEnumerable().Select(r => r.Field<int>("id")).ToArray();
            //string result1 = string.Join(",", idList);

            shopProduct.create_datetime = DateTime.Now;
            shopProduct.update_datetime = DateTime.Now;
            shopProduct.create_user_id = 1;
            shopProduct.update_user_id = 1;
            string[] result = dtShop.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            productService.Insert(product, shopProduct, result);

            if (product == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Product", new { ID = 0, name = string.Empty });
        }

        /// <summary>
        /// The CheckDirectory.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        public void CheckDirectory(string path)
        {
            bool folderExist = Directory.Exists(path);
            if (!folderExist)
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="productEntity">The productEntity<see cref="FormCollection"/>.</param>
        /// <param name="product_image_path">The product_image_path<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Insert(FormCollection productEntity, HttpPostedFileBase product_image_path)
        {
            string ddlShopValue = Request.Form["ddlShop"].ToString();
            string ddlCategoryValue = Request.Form["ddlCategory"].ToString();
            int ddlStatusValue = Convert.ToInt32(Request.Form["ddlCheckBox"]);
            string productCode;
            product = new Product();
            shopProduct = new ShopProduct();

            if (!String.IsNullOrEmpty(ddlCategoryValue))
            {
                product.product_type_id = Convert.ToInt32(ddlCategoryValue);
            }

            productCode = productService.GetProductCode(product.product_type_id);
            product.product_code = productCode;
            if (!string.IsNullOrEmpty(productEntity[6]))
            {
                product.barcode = productEntity[6];

            }
            else
            {
                product.barcode = product.product_code;
            }
            product.name = productEntity["name"];
            product.short_name = productEntity["short_name"];
            product.sale_price = Convert.ToInt32(productEntity["sale_price"]);
            product.description = productEntity["description"];

            if (product_image_path != null)
            {
                string ImageName = System.IO.Path.GetFileName(product_image_path.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/images/upload/product/"), ImageName);

                product_image_path.SaveAs(physicalPath);
                product.product_image_path = ImageName;
            }

            product.mfd_date = Convert.ToDateTime(productEntity["mfd_date"]);
            product.expire_date = Convert.ToDateTime(productEntity["expire_date"]);
            product.minimum_quantity = Convert.ToInt32(productEntity["minimum_quantity"]);
            if (ddlStatusValue == null || ddlStatusValue == 0)
            {
                product.product_status = 2;
            }
            else
            {
                product.product_status = 1;
            }
            product.company_id = 1;
            product.create_datetime = DateTime.Now;
            product.update_datetime = DateTime.Now;
            product.create_user_id = 1;
            product.update_user_id = 1;

            string[] arrayval = ddlShopValue.Split(',');
            shopProduct.create_datetime = DateTime.Now;
            shopProduct.update_datetime = DateTime.Now;
            shopProduct.create_user_id = 1;
            shopProduct.update_user_id = 1;

            productService.Insert(product, shopProduct, arrayval);
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("Index", "Product", new { ID = 0, name = string.Empty });
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            product = new Product();
            product.id = id;
            product.product_status = 3;

            productService.Delete(product);
            return RedirectToAction("Index", "Product", new { ID = 0, name = string.Empty });
        }
    }
}
