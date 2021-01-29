using Microsoft.AspNetCore.Mvc;

namespace MultitenantWebApp
{
    public class HomeController : Controller
    {
        private readonly ITenantContext _tenantContext;

        public HomeController(ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var tenantName = _tenantContext.CurrentTenant.Name;

            return View(new HomeViewModel
            {
                Message = $"Tenant: '{tenantName}'"
            });
        }
    }

    public class HomeViewModel
    {
        public string Message { get; set; }
    }
}