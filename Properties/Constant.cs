using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace POS_OJT.Properties
{
    public class Constant
    {
        public static string INIPATH = "/Config/system.ini";

        /// <summary>
        /// Defines the BASEPATH.
        /// </summary>
        public static string BASEPATH = HostingEnvironment.ApplicationPhysicalPath;

        /// <summary>
        /// Defines the FILEPATH.
        /// </summary>
        public static string FILEPATH = Path.Combine(BASEPATH + INIPATH);
    }
}