using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using PadawanStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadawanStore.Web.UI.Controllers
{
    public class LoginFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            //string name = (string)context.RouteData.Values["Controller"];



            //if (name != "Auth" && context.HttpContext.Request.Cookies["Usuario"] == null)
            //{
            //    context.Result = new RedirectToRouteResult(
            //         new RouteValueDictionary
            //         {
            //            {"controller", "Auth"},
            //            {"action", "Index"}
            //         }
            //     );
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }

    }
}
