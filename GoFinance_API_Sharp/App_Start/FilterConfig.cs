﻿using System.Web;
using System.Web.Mvc;

namespace GoFinance_API_Sharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
