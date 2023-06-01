using License.Creation.Api.Data;
using License.Creation.Api.Models;
using License.Creation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace License.Creation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationTypesController : ControllerBase
    {
        private readonly InstallationTypesService _service;
        public InstallationTypesController(InstallationTypesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<InstallationTypeClientModel> Get()
        {
            return _service.GetInstallationTypes();
        }
        
        [HttpGet("{id}")]
        public InstallationTypeClientModel Get(int id)
        {
            return _service.GetInstallationType(id);
        }
        
        [HttpPost]
        public void Post([FromBody] InstallationTypeClientModel model)
        {
            _service.CreateInstallationType(model);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] InstallationTypeClientModel model)
        {
            _service.UpdateInstallationType(id, model);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteInstallationType(id);
        }
    }
}
