using License.Creation.Api.Data;
using License.Creation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace License.Creation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypesController : ControllerBase
    {
        private readonly ContractTypesService _service;
        public ContractTypesController(ContractTypesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<ContractType> Get()
        {
            return _service.GetAllModels();
        }
        
        [HttpGet("{id}")]
        public ContractType Get(int id)
        {
            return _service.GetModel(id);
        }
        
        [HttpPost]
        public ContractType Post([FromBody] ContractType value)
        {
            return _service.AddNewEntity(value.Id, value.Name);
        }
        
        [HttpPut("{id}")]
        public ContractType Put(int id, [FromBody] ContractType value)
        {
            return _service.UpdateEntity(id, value);
        }
        
        [HttpDelete("{id}")]
        public ContractType Delete(int id)
        {
            return _service.DeleteEntity(id);
        }
    }
}
