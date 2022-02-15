//<copyright file ="WarehouseShopProduct.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="WarehouseShopProduct" />.
    /// </summary>
    [Table("t_warehouse_shop_product", Schema = "public")]
    public class WarehouseShopProduct
    {
        /// <summary>
        /// Gets or sets the warehouse_id.
        /// </summary>
        [Key]

        public int warehouse_id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// Gets or sets the company_id.
        /// </summary>
        public int company_id { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the product_id.
        /// </summary>
        public int product_id { get; set; }

        /// <summary>
        /// Gets or sets the minimum_quantity.
        /// </summary>
        public int minimum_quantity { get; set; }
    }
}
