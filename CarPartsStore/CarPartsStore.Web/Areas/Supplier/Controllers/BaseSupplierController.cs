namespace CarPartsStore.Web.Areas.Supplier.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.SupplierArea)]
    [Authorize(Roles = WebConstants.SupplierRole)]
    public abstract class BaseSupplierController : Controller
    {

    }
}
