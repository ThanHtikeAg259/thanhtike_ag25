//<copyright file ="CategoryVM.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="CategoryVM" />.
    /// </summary>
    public class CategoryVM
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the parent_category.
        /// </summary>
        public string parent_category { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the CategoriesLists.
        /// </summary>
        public IEnumerable<SelectListItem> CategoriesLists { get; set; }

        /// <summary>
        /// Gets or sets the ShopList.
        /// </summary>
        public IEnumerable<SelectListItem> ShopList { get; set; }
    }
}
