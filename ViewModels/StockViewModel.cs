//<copyright file ="StockViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    /// <summary>
    /// Defines the <see cref="StockViewModel" />.
    /// </summary>
    public class StockViewModel
    {
        /// <summary>
        /// Gets or sets the stock_id.
        /// </summary>
        public int stock_id { get; set; }

        /// <summary>
        /// Gets or sets the product_name.
        /// </summary>
        public string product_name { get; set; }

        /// <summary>
        /// Gets or sets the product_code.
        /// </summary>
        public string product_code { get; set; }

        /// <summary>
        /// Gets or sets the product_image.
        /// </summary>
        public string product_image { get; set; }

        /// <summary>
        /// Gets or sets the shop_name.
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// Gets or sets the warehouse_name.
        /// </summary>
        public string warehouse_name { get; set; }

        /// <summary>
        /// Gets or sets the stock_quantity.
        /// </summary>
        public int stock_quantity { get; set; }

        /// <summary>
        /// Gets or sets the stock_price.
        /// </summary>
        public decimal stock_price { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the warehouse_id.
        /// </summary>
        public int warehouse_id { get; set; }

        /// <summary>
        /// Gets or sets the product_id.
        /// </summary>
        public int product_id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// Gets or sets the wsp_id.
        /// </summary>
        public int wsp_id { get; set; }
    }
}
