namespace HospitalManagment.CustomValidation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class UserValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserDetails"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}