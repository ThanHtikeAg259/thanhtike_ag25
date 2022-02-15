//<copyright file ="ShopCategory.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="ShopCategory" />.
    /// </summary>
    [Table("m_shop_category", Schema = "public")]
    public class ShopCategory
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the category_id.
        /// </summary>
        public int category_id { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

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
        /// Initializes a new instance of the <see cref="ShopCategory"/> class.
        /// </summary>
        public ShopCategory()
        {
            ShopCategoryEntity();
        }

        /// <summary>
        /// The ShopCategoryEntity.
        /// </summary>
        internal void ShopCategoryEntity()
        {
            this.id = 0;
            this.category_id = 0;
            this.shop_id = 0;
            this.create_user_id = 1;
            this.create_datetime = DateTime.Now;
            this.update_user_id = 1;
            this.update_datetime = DateTime.Now;
        }
    }
}
