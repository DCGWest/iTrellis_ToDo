﻿using System.Web;
using System.Web.Mvc;

namespace iTrellis_ToDo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}