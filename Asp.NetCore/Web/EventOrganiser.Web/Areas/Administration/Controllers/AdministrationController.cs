namespace EventOrganiser.Web.Areas.Administration.Controllers
{
    using EventOrganiser.Common;
    using EventOrganiser.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
