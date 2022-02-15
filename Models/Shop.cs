//<copyright file ="Shop.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="Shop" />.
    /// </summary>
    [Table("m_shop", Schema = "public")]
    public class Shop
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Please enter shop name")]
        //[Remote("check", "ShopController", ErrorMessage = "Invalid")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the phone_number_1.
        /// </summary>
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number cannot contain alphabets")]
        public string phone_number_1 { get; set; }

        /// <summary>
        /// Gets or sets the phone_number_2.
        /// </summary>
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number cannot contain alphabets")]
        public string phone_number_2 { get; set; }

        /// <summary>
        /// Gets or sets the shop_type.
        /// </summary>
        [Required(ErrorMessage = "Please select shop type")]
        public Int16 shop_type { get; set; }

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

        /// <summary>
        /// Gets or sets the company_id.
        /// </summary>
        public int company_id { get; set; }
    }
}
