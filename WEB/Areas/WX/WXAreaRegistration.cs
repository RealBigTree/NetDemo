using System.Web.Mvc;

namespace WEB.Areas.WX
{
    public class WXAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WX";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WX_default",
                "WX/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}