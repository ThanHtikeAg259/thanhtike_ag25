//<copyright file ="Staff.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="Staff" />.
    /// </summary>
    [Table("m_staff", Schema = "public")]
    public class Staff
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]

        public int id { get; set; }

        /// <summary>
        /// Gets or sets the staff_number.
        /// </summary>
        public string staff_number { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmPassword.
        /// </summary>
        [NotMapped]
        [Compare("password", ErrorMessage = "Password doesn't match!")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public int role { get; set; }

        /// <summary>
        /// Gets or sets the staff_type.
        /// </summary>
        public int staff_type { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// Gets or sets the bank_account_number.
        /// </summary>
        public string bank_account_number { get; set; }

        /// <summary>
        /// Gets or sets the graduated_univeristy.
        /// </summary>
        public string graduated_univeristy { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// Gets or sets the nrc_number.
        /// </summary>
        public string nrc_number { get; set; }

        /// <summary>
        /// Gets or sets the dob.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dob { get; set; }

        /// <summary>
        /// Gets or sets the marital_status.
        /// </summary>
        public int marital_status { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        public string race { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Photo can't be empty!")]
        public string photo { get; set; }

        /// <summary>
        /// Gets or sets the phone_number_1.
        /// </summary>
        public string phone_number_1 { get; set; }

        /// <summary>
        /// Gets or sets the phone_number_2.
        /// </summary>
        public string phone_number_2 { get; set; }

        /// <summary>
        /// Gets or sets the join_from.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> join_from { get; set; }

        /// <summary>
        /// Gets or sets the join_to.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> join_to { get; set; }

        /// <summary>
        /// Gets or sets the staff_status.
        /// </summary>
        public int staff_status { get; set; }

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
        /// Gets or sets the old_id.
        /// </summary>
        public int old_id { get; set; }

        /// <summary>
        /// Gets or sets the warehouse_id.
        /// </summary>
        public int warehouse_id { get; set; }

        /// <summary>
        /// Gets or sets the shop_id.
        /// </summary>
        public int shop_id { get; set; }

        /// <summary>
        /// Gets or sets the company_id.
        /// </summary>
        public int company_id { get; set; }
    }
}
