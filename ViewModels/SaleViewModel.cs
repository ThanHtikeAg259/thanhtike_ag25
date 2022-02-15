//<copyright file ="SaleViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    using System;

    /// <summary>
    /// Defines the <see cref="SaleViewModel" />.
    /// </summary>
    public class SaleViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Gets or sets the invoice_number.
        /// </summary>
        public string invoice_number { get; set; }

        /// <summary>
        /// Gets or sets the sale_date.
        /// </summary>
        public DateTime sale_date { get; set; }

        /// <summary>
        /// Gets or sets the shop_name.
        /// </summary>
        public string shop_name { get; set; }

        /// <summary>
        /// Gets or sets the terminal_name.
        /// </summary>
        public string terminal_name { get; set; }

        /// <summary>
        /// Gets or sets the staff_name.
        /// </summary>
        public string staff_name { get; set; }

        /// <summary>
        /// Gets or sets the amount_tax.
        /// </summary>
        public Decimal amount_tax { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public Decimal amount { get; set; }

        /// <summary>
        /// Gets or sets the paid_amount.
        /// </summary>
        public Decimal paid_amount { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// Gets or sets the invoice_status.
        /// </summary>
        public Int16 invoice_status { get; set; }

        /// <summary>
        /// Gets or sets the product_name.
        /// </summary>
        public string product_name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public int price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }
    }
}
