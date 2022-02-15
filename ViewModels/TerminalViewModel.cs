//<copyright file ="TerminalViewModel.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.ViewModels
{
    using POS_OJT.Models;

    /// <summary>
    /// Defines the <see cref="TerminalViewModel" />.
    /// </summary>
    public class TerminalViewModel
    {
        /// <summary>
        /// Gets or sets the terminalVM.
        /// </summary>
        public Terminal terminalVM { get; set; }

        /// <summary>
        /// Gets or sets the shopVM.
        /// </summary>
        public Shop shopVM { get; set; }
    }
}
