using License.Creation.Api.Data;
using License.Creation.Api.Services;
using Microsoft.AspNetCore.Mvc;


namespace License.Creation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseProductsController : ControllerBase
    {
        private readonly LicenseProductsService _licenseProducts;

        public LicenseProductsController(LicenseProductsService licenseProducts)
        {
            _licenseProducts = licenseProducts;
        }
        
        [HttpGet]
        public IEnumerable<LicenseProduct> Get()
        {
            return _licenseProducts.GetLicenseProducts();
        }
        
        [HttpGet ("{id}")]
        public LicenseProduct Get(int id)
        {
            return _licenseProducts.GetLicenseProduct(id);
        }
        
        [HttpPost]
        public void Create([FromBody] LicenseProduct model)
        {
            _licenseProducts.CreateLicenseProduct(model);
        }
        [HttpPut]
        public void Update(int id, [FromBody] LicenseProduct model)
        {
            _licenseProducts.UpdateLicenseProduct(id,model);
        }
        
        [HttpDelete]
        public void Delete([FromBody]int id)
        {
            _licenseProducts.DeleteLicenseProduct(id);
        }
    }
}
