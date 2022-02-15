//<copyright file ="WarehouseViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    using POS_OJT.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="WarehouseViewModel" />.
    /// </summary>
    public class WarehouseViewModel
    {
        /// <summary>
        /// Gets or sets the warehouses.
        /// </summary>
        public IEnumerable<Warehouse> warehouses { get; set; }

        /// <summary>
        /// Gets or sets the perPage.
        /// </summary>
        public int perPage { get; set; }

        /// <summary>
        /// Gets or sets the currentPage.
        /// </summary>
        public int currentPage { get; set; }
    }
}
