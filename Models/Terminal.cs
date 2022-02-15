//<copyright file ="Terminal.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="Terminal" />.
    /// </summary>
    [Table("m_terminal", Schema = "public")]
    public class Terminal
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]

        public int id { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        [Required(ErrorMessage = "Please Select Shop Name")]
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Please Select Terminal Name")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the pc_serial_number.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string pc_serial_number { get; set; }

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
        /// Gets or sets the is_deleted.
        /// </summary>
        public Int16 is_deleted { get; set; }
    }
}
