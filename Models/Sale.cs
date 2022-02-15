//<copyright file ="Sale.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="Sale" />.
    /// </summary>
    [Table("t_sale", Schema = "public")]
    public class Sale
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the invoice_number.
        /// </summary>
        public string invoice_number { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the terminal_id.
        /// </summary>
        public int terminal_id { get; set; }

        /// <summary>
        /// Gets or sets the sale_date.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime sale_date { get; set; }

        /// <summary>
        /// Gets or sets the remark.
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public double amount { get; set; }

        /// <summary>
        /// Gets or sets the amount_tax.
        /// </summary>
        public double amount_tax { get; set; }

        /// <summary>
        /// Gets or sets the paid_amount.
        /// </summary>
        public double paid_amount { get; set; }

        /// <summary>
        /// Gets or sets the change_amount.
        /// </summary>
        public double change_amount { get; set; }

        /// <summary>
        /// Gets or sets the invoice_status.
        /// </summary>
        public Int16 invoice_status { get; set; }

        /// <summary>
        /// Gets or sets the print_count.
        /// </summary>
        public int print_count { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string reason { get; set; }

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
        /// Defines the MonthOfYear.
        /// </summary>
        public enum MonthOfYear
        {
            /// <summary>
            /// Defines the January.
            /// </summary>
            January = 1,

            /// <summary>
            /// Defines the Febuary.
            /// </summary>
            Febuary = 2,

            /// <summary>
            /// Defines the March.
            /// </summary>
            March = 3,

            /// <summary>
            /// Defines the April.
            /// </summary>
            April = 4,

            /// <summary>
            /// Defines the May.
            /// </summary>
            May = 5,

            /// <summary>
            /// Defines the June.
            /// </summary>
            June = 6,

            /// <summary>
            /// Defines the July.
            /// </summary>
            July = 7,

            /// <summary>
            /// Defines the August.
            /// </summary>
            August = 8,

            /// <summary>
            /// Defines the September.
            /// </summary>
            September = 9,

            /// <summary>
            /// Defines the October.
            /// </summary>
            October = 10,

            /// <summary>
            /// Defines the November.
            /// </summary>
            November = 11,

            /// <summary>
            /// Defines the December.
            /// </summary>
            December = 12
        }

        /// <summary>
        /// Gets the monthOfYear.
        /// </summary>
        public MonthOfYear monthOfYear { get; }
    }
}
