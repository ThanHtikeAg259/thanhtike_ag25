//<copyright file ="ShopListViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ShopListViewModel" />.
    /// </summary>
    [Table("m_shop", Schema = "public")]
    public class ShopListViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string name { get; set; }
    }
}
