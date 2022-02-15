//<copyright file ="Product.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="Product" />.
    /// </summary>
    [Table("m_product", Schema = "public")]

    public class Product
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
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
        /// Gets or sets the barcode.
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the short_name.
        /// </summary>
        public string short_name { get; set; }

        /// <summary>
        /// Gets or sets the sale_price.
        /// </summary>
        public decimal sale_price { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the product_image_path.
        /// </summary>
        public string product_image_path { get; set; }

        /// <summary>
        /// Gets or sets the mfd_date.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime mfd_date { get; set; }
        public Nullable<DateTime> mfd_date { get; set; }

        /// <summary>
        /// Gets or sets the expire_date.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> expire_date { get; set; }

        //public DateTime expire_date { get; set; }
        /// <summary>
        /// Gets or sets the minimum_quantity.
        /// </summary>
        public int minimum_quantity { get; set; }

        /// <summary>
        /// Gets or sets the product_status.
        /// </summary>
        public int product_status { get; set; }

        /// <summary>
        /// Gets or sets the create_user_id.
        /// </summary>
        public int create_user_id { get; set; }

        /// <summary>
        /// Gets or sets the create_datetime.
        /// </summary>
        public DateTime create_datetime { get; set; }

        /// <summary>
        /// Gets or sets the update_user_id.
        /// </summary>
        public int update_user_id { get; set; }

        /// <summary>
        /// Gets or sets the update_datetime.
        /// </summary>
        public DateTime update_datetime { get; set; }

        /// <summary>
        /// Gets or sets the company_id.
        /// </summary>
        public int company_id { get; set; }

        /// <summary>
        /// Gets or sets the ProductList.
        /// </summary>
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
