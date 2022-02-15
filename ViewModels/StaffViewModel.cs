//<copyright file ="StaffViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    using System;

    /// <summary>
    /// Defines the <see cref="StaffViewModel" />.
    /// </summary>
    public class StaffViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        public string photo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the staff_number.
        /// </summary>
        public string staff_number { get; set; }

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
        /// Gets or sets the name1.
        /// </summary>
        public string name1 { get; set; }

        /// <summary>
        /// Gets or sets the nrc_number.
        /// </summary>
        public string nrc_number { get; set; }

        /// <summary>
        /// Gets or sets the join_from.
        /// </summary>
        public DateTime join_from { get; set; }
    }
}
