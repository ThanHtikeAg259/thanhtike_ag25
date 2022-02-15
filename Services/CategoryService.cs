//<copyright file ="CategoryService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="CategoryService" />.
    /// </summary>
    public class CategoryService
    {
        /// <summary>
        /// Defines the categoryDAO.
        /// </summary>
        private CategoryDAO categoryDAO = new CategoryDAO();

        /// <summary>
        /// The GetCategoryList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetCategoryList(int? id)
        {
            return categoryDAO.GetCategory(id);
        }

        /// <summary>
        /// The GetParentCategory.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetParentCategory()
        {
            return categoryDAO.GetParentCategory();
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        /// <param name="shopCategory">The shopCategory<see cref="ShopCategory"/>.</param>
        /// <param name="arrayval">The arrayval<see cref="string[]"/>.</param>
        public void Insert(Category category, ShopCategory shopCategory, string[] arrayval)
        {
            int id = categoryDAO.Insert(category);

            for (int i = 0; i < arrayval.Length; i++)
            {
                if (!string.IsNullOrEmpty(arrayval[i]))
                {
                    shopCategory.shop_id = Convert.ToInt32(arrayval[i]);
                    categoryDAO.Insert(shopCategory, id);
                }
            }
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Update(Category category)
        {
            categoryDAO.Update(category);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="category">The category<see cref="Category"/>.</param>
        public void Delete(Category category)
        {
            categoryDAO.Delete(category);
        }

        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            return categoryDAO.GetShopList();
        }
    }
}
