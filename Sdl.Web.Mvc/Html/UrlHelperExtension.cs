﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sdl.Web.Mvc.Html
{
    public static class UrlHelperExtension
    {
        public static string VersionedContent(this UrlHelper helper, string path, string localization = "")
        {
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }
            string version = Configuration.CurrentVersion;
            if (!String.IsNullOrEmpty(version))
            {
                version = "/" + version;
            }
            path = "~/" + localization + "system" + version + path;
            return helper.Content(path);
        }
    }
}