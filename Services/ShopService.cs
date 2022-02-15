//<copyright file ="ShopService.cs"  company ="Seattle Consulting Myanmar">
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
    /// Defines the <see cref="ShopService" />.
    /// </summary>
    public class ShopService
    {
        /// <summary>
        /// Defines the shopDao.
        /// </summary>
        ShopDAO shopDao = new ShopDAO();

        //Get Shops
        /// <summary>
        /// The GetShopList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopList()
        {
            return shopDao.GetShop();
        }

        /// <summary>
        /// The GetShopTypeList.
        /// </summary>
        /// <param name="id">The id<see cref="int?"/>.</param>
        /// <returns>The <see cref="Object"/>.</returns>
        public object GetShopTypeList(int? id)
        {
            return shopDao.GetShopTypeList(id);
        }

        //Get Shop Names
        /// <summary>
        /// The GetShopNameList.
        /// </summary>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetShopNameList()
        {
            return shopDao.GetShopName();
        }

        //Add Shop
        /// <summary>
        /// The Insert.
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/>.</param>
        public void Insert(Shop shop)
        {
            shopDao.Insert(shop);
        }

        //POST: Edit Shop
        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="shop">The shop<see cref="Shop"/>.</param>
        public void Update(Shop shop)
        {
            shopDao.Update(shop);
        }

        //GET: Edit Shop
        /// <summary>
        /// The GetEdit.
        /// </summary>
        /// <returns>The <see cref="List{Shop}"/>.</returns>
        public List<Shop> GetEdit()
        {
            List<Shop> shopList = new List<Shop>();
            DataTable dtShopList = new DataTable();
            dtShopList = shopDao.GetEdit();
            foreach (DataRow rows in dtShopList.Rows)
            {
                shopList.Add(new Shop
                {
                    id = Convert.ToInt32(rows[0]),
                    name = Convert.ToString(rows[1]),
                    shop_type = Convert.ToInt16(rows[5]),
                    address = Convert.ToString(rows[2]),
                    phone_number_1 = Convert.ToString(rows[3]),
                    phone_number_2 = Convert.ToString(rows[4])
                });
            }

            return shopList;
        }
    }
}
