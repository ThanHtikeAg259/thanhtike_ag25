//<copyright file ="Stock.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Stock" />.
    /// </summary>
    [Table("t_stock", Schema = "public")]
    public class Stock
    {
        /// <summary>
        /// Defines the name.
        /// </summary>
        internal string name;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the warehouse_id.
        /// </summary>
        public int warehouse_id { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the product_id.
        /// </summary>
        public int product_id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// Gets or sets the inout_flg.
        /// </summary>
        public int inout_flg { get; set; }

        /// <summary>
        /// Gets or sets the source_location_id.
        /// </summary>
        public int source_location_id { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// Gets or sets the is_deleted.
        /// </summary>
        public Int16 is_deleted { get; set; }

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
    }
}
