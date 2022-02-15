using POS_OJT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_OJT.Controllers;
using System.Data;
using POS_OJT.Config;

namespace POS_OJT.DAOs
{
    public class LoginDAO
    {
        string strSql = string.Empty;

        private DbConnection connection = new DbConnection();
        public object GetPassword(string staff_number)
        {
            strSql = "SELECT password from m_staff where staff_number = '" + staff_number+"';";
            return connection.ExecuteScalar(CommandType.Text, strSql, null);
        }
    }
}