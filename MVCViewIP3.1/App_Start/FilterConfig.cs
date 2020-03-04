using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;

namespace MVCViewIP3._1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".." + @"\IntroductoryProject3.1\App_Data")));

        }
    }
}
