using DocuWare.Settings.Licenses;
using Microsoft.AspNetCore.Mvc;
using License.Creation.Api.Services;
using License.Creation.Api.Data;

namespace License.Creation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseCreationController : ControllerBase
    {
        private readonly LicenseCreationService _service;
        public LicenseCreationController(LicenseCreationService service)
        {
            this._service = service;
        }
        [HttpPost]
        public string CreateLicense([FromBody] LicenseCreationClientModel licenseToBeCreated)
        {
            var licenseInfo = _service.CreateLicense(licenseToBeCreated);
            return new LicenseSignService(licenseInfo).Sign();
        }
    }
}
