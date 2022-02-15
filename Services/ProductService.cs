//<copyright file ="ProductService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System;
    using System.Collections;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// Defines the productDao.
        /// </summary>
        private ProductDAO productDao = new ProductDAO();

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <param name="shopProduct">The shopProduct<see cref="ShopProduct"/>.</param>
        /// <param name="arrayval">The arrayval<see cref="string[]"/>.</param>
        public void Insert(Product product, ShopProduct shopProduct, string[] arrayval)
        {
            int id = productDao.Insert(product);

            for (int i = 0; i < arrayval.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayval[i]))
                {
                    shopProduct.shop_id = Convert.ToInt32(arrayval[i]);
                    productDao.Insert(shopProduct, id);
                }
            }
        }

        /// <summary>
        /// The InsertList.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        public void InsertList(Product product)
        {
            productDao.Insert(product);
        }

        /// <summary>
        /// The GetCateList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCateList()
        {
            return productDao.GetCateList();
        }

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            return productDao.GetShopList();
        }

        /// <summary>
        /// The GetSelectShopList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSelectShopList(int? id)
        {
            return productDao.GetSelectShopList(id);
        }

        /// <summary>
        /// The GetShopProduct.
        /// </summary>
        /// <param name="pid">The pid<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopProduct(int pid)
        {
            return productDao.GetShopProduct(pid);
        }

        /// <summary>
        /// The GetProductCode.
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int?"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetProductCode(int? categoryId)
        {
            object productCode = productDao.GetProductCode();
            object latestProductCode = productDao.GetLastestProductCode();

            object parentCateId = productDao.GetParentCategoryID(categoryId);

            string parentCategoryID = string.Empty;
            string productID = string.Empty;
            string categoryID = Convert.ToString(categoryId);
            string countryCode = "883";

            if (parentCateId == null)
            {
                parentCategoryID = "000";
            }
            else
            {
                parentCategoryID = parentCateId.ToString();
            }

            if (productCode == null)
            {
                productID = "000001";
            }
            else
            {
                string lastProductCode = latestProductCode.ToString();
                string codeNumber = lastProductCode.Substring(lastProductCode.Length - 6); //length -5 
                productID = string.Format("{0:000000}", Convert.ToInt32(codeNumber) + 1);
                productID = countryCode + parentCategoryID + categoryID + productID;
            }

            return productID;
        }

        /// <summary>
        /// The GetCategoryList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCategoryList(int? id)
        {
            return productDao.GetCategory();
        }

        /// <summary>
        /// The ShowProduct.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable ShowProduct(int? id)
        {
            return productDao.ShowProduct(id);
        }

        /// <summary>
        /// The JustCategory.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable JustCategory()
        {
            return productDao.JustCategory();
        }

        /// <summary>
        /// The GetProductList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <param name="searchName">The search<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetProductList(int? id, string searchName)
        {
            return productDao.GetProduct(id, searchName);
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        public void Update(Product product)
        {
            productDao.Update(product);
        }

        /// <summary>
        /// The UpdateShopProduct.
        /// </summary>
        /// <param name="arrayval">The arrayval<see cref="ArrayList"/>.</param>
        /// <param name="id">The id<see cref="int?"/>.</param>
        public void UpdateShopProduct(ArrayList arrayval, int? id)
        {
            productDao.UpdateShopProduct(arrayval, id);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        public void Delete(Product product)
        {
            productDao.Delete(product);
        }
    }
}
