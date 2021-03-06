﻿using System;
namespace Sdl.Web.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string value)
        {
            return value.Replace(" ", string.Empty);
        }

        public static string ToCombinePath(this string value, bool prefixWithSlash = false)
        {
            return (prefixWithSlash ? "\\" : "") + value.Replace('/', '\\').Trim('\\');
        }

        /// <summary>
        /// Returns a new string in which all occurances of a specifid string are replaced with a new string
        /// using the provided string comparison option
        /// </summary>
        /// <param name="str">Original string</param>
        /// <param name="oldValue">Value to replace</param>
        /// <param name="newValue">Replacement</param>
        /// <param name="comparisonType">String comparison</param>
        /// <returns></returns>
        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (str == null || oldValue == null || newValue == null) return str;
            int n = oldValue.Length;
            string lhs = "";
            string rhs = str;
            while (true)
            {   // go through looking for all matches of oldValue and replace
                int index = rhs.IndexOf(oldValue, comparisonType);
                if (index == -1) break;
                string tmp = rhs.Substring(index + n);
                lhs = lhs + rhs.Substring(0, index) + newValue;
                rhs = tmp;
            }
            return lhs + rhs;
        }

        /// <summary>
        /// Normalizes a URL path for a Page.
        /// </summary>
        /// <remarks>
        /// The following normalization actions are taken:
        /// <list type="bullet">
        ///     <item>Ensure the URL path is extensionless.</item>
        ///     <item>Ensure the URL path for an index page ends with "/index".</item>
        /// </list>
        /// </remarks>
        /// <param name="urlPath">The input URL path (the subject for this extension method).</param>
        /// <returns>The normalized URL path.</returns>
        public static string NormalizePageUrlPath(this string urlPath)
        {
            if (urlPath == null)
            {
                return null;
            }
            if (urlPath.EndsWith(Constants.DefaultExtension))
            {
                urlPath = urlPath.Substring(0, urlPath.Length - Constants.DefaultExtension.Length);
            }
            if (urlPath.EndsWith("/"))
            {
                urlPath += Constants.DefaultExtensionLessPageName;
            }
            return urlPath;
        }
    }
}
