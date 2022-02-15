//<copyright file ="ProductVM.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="ProductVM" />.
    /// </summary>
    public class ProductVM
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the product_type_id.
        /// </summary>
        public int product_type_id { get; set; }

        /// <summary>
        /// Gets or sets the product_code.
        /// </summary>
        public string product_code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the ProductList.
        /// </summary>
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
