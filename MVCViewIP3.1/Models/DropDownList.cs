﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViewIP3._1.Models
{
    public static class DropDownList<T>
    {
        public static SelectList LoadItems(IList<T> collection, string value, string text)
        {
            return new SelectList(collection, value, text);
        }
    }
}