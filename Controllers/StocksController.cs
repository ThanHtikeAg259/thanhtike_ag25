using POS_OJT.Models;
using POS_OJT.Services;
using POS_OJT.Utilities;
using POS_OJT.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace POS_OJT.Controllers
{
    public class StocksController : Controller
    {
        private StockService stockService = new StockService();
        private DataTable dtShop = new DataTable(),
                          dtWarehouse = new DataTable();

        private Stock stock;

        ListToDataTable listToDt = new ListToDataTable();
        // GET: Stocks
        public ActionResult Index(string productName, string shoplist, string warehouselist, string stockSearch)
        {
            List<StockViewModel> dtToList = new List<StockViewModel>();
            List<StockViewModel> newList = new List<StockViewModel>();

            //Get Warehouse Name List
            dtWarehouse = stockService.GetWarehouseList();
            List<StockViewModel> warehouseList = new List<StockViewModel>();

            warehouseList = (from DataRow datarow in dtWarehouse.Rows
                          select new StockViewModel()
                          {
                              warehouse_id = Convert.ToInt32(datarow["id"]),
                              warehouse_name = datarow["name"].ToString()
                          }).ToList();

            SelectList warehousename = new SelectList(warehouseList, "warehouse_id", "warehouse_name");
            ViewBag.warehouselistname = warehousename;

            //Get Shop Name List
            dtShop = stockService.GetShopList();
            List<StockViewModel> shopList = new List<StockViewModel>();
            shopList = (from DataRow datarow in dtShop.Rows
                     select new StockViewModel()
                     {
                         shop_id = Convert.ToInt32(datarow["id"]),
                         shop_name = datarow["name"].ToString()
                     }).ToList();

            SelectList shopname = new SelectList(shopList, "shop_id", "shop_name");
            ViewBag.shoplistname = shopname;

            DataTable dtStock = stockService.GetStockList();
            if (stockSearch == "less_stock")
            {
                dtStock = stockService.GetLessStock();
                if (!String.IsNullOrEmpty(productName) || !String.IsNullOrEmpty(shoplist) || !String.IsNullOrEmpty(warehouselist) || !String.IsNullOrEmpty(stockSearch))
                {
                    dtToList = DataTableToList.ConvertToList<StockViewModel>(dtStock);
                    newList = dtToList.Where(
                         s => s.product_name == productName && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == String.Empty
                        || productName == null
                     || productName == String.Empty && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty && stockSearch == String.Empty
                     || productName == String.Empty && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || productName == String.Empty && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == "less_stock"
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty && stockSearch == String.Empty
                     || s.product_name == productName && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || s.product_name == productName && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == "less_stock"
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == "less_stock"
                     || productName == String.Empty && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == String.Empty).ToList();
                                        
                    dtStock = listToDt.ToDataTable(newList);
                }
            }
            else if (stockSearch == "quantity")
            {
                dtStock = stockService.GetStockASC();
                if (!String.IsNullOrEmpty(productName) || !String.IsNullOrEmpty(shoplist) || !String.IsNullOrEmpty(warehouselist) || !String.IsNullOrEmpty(stockSearch))
                {
                    
                    dtToList = DataTableToList.ConvertToList<StockViewModel>(dtStock);
                    newList = dtToList.Where(
                         s => s.product_name == productName && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == String.Empty
                        || productName == null
                     || productName == String.Empty && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty && stockSearch == String.Empty
                     || productName == String.Empty && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || productName == String.Empty && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == "quantity"
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty && stockSearch == String.Empty
                     || s.product_name == productName && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || s.product_name == productName && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == "quantity"
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == String.Empty
                     || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && Convert.ToString(s.warehouse_id) == warehouselist && stockSearch == "quantity"
                     || productName == String.Empty && shoplist == String.Empty && warehouselist == String.Empty && stockSearch == String.Empty).ToList();

                    dtStock = listToDt.ToDataTable(newList);
                }
            }
            // Data list
            else if (!String.IsNullOrEmpty(productName) || !String.IsNullOrEmpty(shoplist) || !String.IsNullOrEmpty(warehouselist))
            {
                dtToList = DataTableToList.ConvertToList<StockViewModel>(dtStock);

                newList = dtToList.Where(
                     s => s.product_name == productName && shoplist == String.Empty && warehouselist == String.Empty
                    || productName == null
                 || productName == String.Empty && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty
                 || productName == String.Empty && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist
                 || s.product_name == productName && shoplist == String.Empty && Convert.ToString(s.warehouse_id) == warehouselist
                 || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && warehouselist == String.Empty
                 || s.product_name == productName && Convert.ToString(s.shop_id) == shoplist && Convert.ToString(s.warehouse_id) == warehouselist
                 || productName == String.Empty && shoplist == String.Empty && warehouselist == String.Empty).ToList();

                dtStock = listToDt.ToDataTable(newList);
            }
            else
            {
                dtStock = stockService.GetStockList();
            }

            return View(dtStock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            // GET Parent Category Name
            DataTable dtCategory = stockService.GetParentCategoryNameList();
            List<Category> categoryList = new List<Category>();

            categoryList = (from DataRow datarow in dtCategory.Rows
                          select new Category()
                          {
                              id = Convert.ToInt32(datarow["id"]),
                              name = datarow["name"].ToString()
                          }).ToList();

            SelectList parentlist = new SelectList(categoryList, "id", "name");
            ViewBag.parentcategorylistname = parentlist;

            //Get Product Name
            DataTable dtProduct = stockService.GetProductNameList();
            List<Product> productsList = new List<Product>();
            productsList = (from DataRow datarow in dtProduct.Rows
                        select new Product()
                        {
                            id = Convert.ToInt32(datarow["id"]),
                            name = datarow["name"].ToString()
                        }).ToList();

            SelectList productList = new SelectList(productsList, "id", "name");
            ViewBag.productlistname = productList;

            //GET  Sub Category Name
            DataTable dtSubcategory = stockService.GetSubCategoryNameList();
            List<Category> subcategory = new List<Category>();

            subcategory = (from DataRow datarow in dtSubcategory.Rows
                           select new Category()
                           {
                               id = Convert.ToInt32(datarow["id"]),
                               name = datarow["name"].ToString()
                           }).ToList();

            SelectList subcategoryList = new SelectList(subcategory, "id", "name");
            ViewBag.subcategorylistname = subcategoryList;

            //Get Warehouse Name List
            dtWarehouse = stockService.GetWarehouseList();
            List<Warehouse> warehousesList = new List<Warehouse>();

            warehousesList = (from DataRow datarow in dtWarehouse.Rows
                          select new Warehouse()
                          {
                              id = Convert.ToInt32(datarow["id"]),
                              name = datarow["name"].ToString()
                          }).ToList();

            SelectList warehouselist = new SelectList(warehousesList, "id", "name");
            ViewBag.warehouselistname = warehouselist;

            //Get Shop Name List
            dtShop = stockService.GetShopList();
            List<Shop> shopsList = new List<Shop>();
            shopsList = (from DataRow datarow in dtShop.Rows
                     select new Shop()
                     {
                         id = Convert.ToInt32(datarow["id"]),
                         name = datarow["name"].ToString()
                     }).ToList();

            SelectList shoplist = new SelectList(shopsList, "id", "name");
            ViewBag.shoplistname = shoplist;

            //Get Product Quantity List
            DataTable dtProductQty = stockService.GetProductQuantityList();
            return View(dtProductQty);
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.Message = "Data added!";
            return RedirectToAction("index");
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            dtWarehouse = stockService.GetWarehouseList();
            List<Warehouse> warehousesList = new List<Warehouse>();
            warehousesList = (from DataRow datarow in dtWarehouse.Rows
                          select new Warehouse()
                          {
                              id = Convert.ToInt32(datarow["id"]),
                              name = datarow["name"].ToString()
                          }).ToList();

            SelectList warehouselist = new SelectList(warehousesList, "id", "name");
            ViewBag.warehouselistname = warehouselist;

            return View(stockService.GetEdit().Find(item => item.stock_id == id));
        }
        // POST: Stocks/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            stock = new Stock();
            WarehouseShopProduct warehouseShopProduct = new WarehouseShopProduct();
            stock.warehouse_id = Convert.ToInt32(collection[8]);
            stock.shop_id = Convert.ToInt32(collection[5]);
            stock.product_id = Convert.ToInt32(collection[2]);
            stock.quantity = Convert.ToInt32(collection[9]);
            stock.inout_flg = 1;
            stock.source_location_id = 2;
            stock.price = Convert.ToDouble(collection[10]);
            stock.remark = Convert.ToString(collection[9]);
            stock.is_deleted = 0;
            stock.create_user_id = 1;
            stock.create_datetime = DateTime.Now;
            stock.update_user_id = 1;
            stock.update_datetime = DateTime.Now;

            stockService.RemainStock(stock);
            return RedirectToAction("Index");
        }

        // POST: Stocks/Delete/5
        public ActionResult Delete(int id)
        {
            stock = new Stock();
            stock.id = id;
            stock.is_deleted = 1;

            stockService.Delete(stock);
            return RedirectToAction("Create");
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
    }    
}