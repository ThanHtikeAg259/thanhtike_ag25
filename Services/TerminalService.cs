//<copyright file ="TerminalService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;
    using POS_OJT.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="TerminalService" />.
    /// </summary>
    public class TerminalService
    {
        /// <summary>
        /// Defines the terminalDao.
        /// </summary>
        private TerminalDAO terminalDao = new TerminalDAO();

        /// <summary>
        /// The GetTerminalList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetTerminalList()
        {
            return terminalDao.GetTerminal();
        }

        /// <summary>
        /// The GetShopNameList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopNameList()
        {
            return terminalDao.GetShopName();
        }

        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Insert(Terminal terminal)
        {
            terminalDao.Insert(terminal);
        }

        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="List{Terminal}"/>.</returns>
        public List<Terminal> GetEdit()
        {
            List<Terminal> terminalList = new List<Terminal>();
            DataTable dtTerminalList = terminalDao.GetEdit();
            foreach (DataRow rows in dtTerminalList.Rows)
            {
                terminalList.Add(new Terminal
                {
                    id = Convert.ToInt32(rows[0]),
                    shop_id = Convert.ToInt32(rows[2]),
                    name = Convert.ToString(rows[1])
                });
            }
            return terminalList;
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Update(Terminal terminal)
        {
            terminalDao.Update(terminal);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="terminal">The terminal<see cref="Terminal"/>.</param>
        public void Delete(Terminal terminal)
        {
            terminalDao.Delete(terminal);
        }
    }
}
