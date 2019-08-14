using System;
using System.Web.Mvc;

namespace OnRamp.Link
{
    /// <summary>
    /// this class contain the extension method for url and actionlinks
    /// </summary>
    public static class RootLinks
    {
        #region url for Action

        public static string UserAction(this UrlHelper url)
        {
            return url.Action("userlist", "Person");
        }

        #endregion

        #region For ActionLink

        //public static MvcHtmlString UserActionLink(this HtmlHelper html, String linkText)
        //{
        //    return html.ActionLink(linkText, "userlist", "system");
        //}

        #endregion

        public static string AbsoluteAction(this UrlHelper url, string action, string controller, object routeValues)
        {
            var requestUrl = url.RequestContext.HttpContext.Request.Url;

            var absoluteAction = string.Format("{0}{1}",
                requestUrl.GetLeftPart(UriPartial.Authority),
                url.Action(action, controller, routeValues));

            return absoluteAction;
        }

        public static int WordCount(this String str)
        {
            return str.Split(new[] { ' ', '.', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}