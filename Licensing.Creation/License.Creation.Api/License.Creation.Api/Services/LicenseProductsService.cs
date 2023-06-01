using License.Creation.Api.Data;

namespace License.Creation.Api.Services;

public class LicenseProductsService
{
    private readonly DataContext _dataContext;

    public LicenseProductsService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<LicenseProduct> GetLicenseProducts()
    {
        return _dataContext.LicenseProducts;
    }

    public LicenseProduct GetLicenseProduct(int id)
    {
        var licenseProduct = _dataContext.LicenseProducts.FirstOrDefault(p => p.Id == id);
        if (licenseProduct == null) throw new Exception("license product is null");
        return licenseProduct;
    }

    public void CreateLicenseProduct(LicenseProduct model)
    {
        _dataContext.LicenseProducts.Add(model);
        _dataContext.SaveChanges();
    }

    public void UpdateLicenseProduct(int id, LicenseProduct model)
    {
        var licenseProduct = _dataContext.LicenseProducts.FirstOrDefault(x => x.Id == id);
        if (licenseProduct == null) throw new Exception("No matches found");
        licenseProduct.Name = model.Name;
        licenseProduct.IssuedType = model.IssuedType;
        _dataContext.Update(licenseProduct);
        _dataContext.SaveChanges();
    }
    public void DeleteLicenseProduct(int id)
    {
        var licenseProduct = _dataContext.LicenseProducts.FirstOrDefault(x=>x.Id == id) ?? throw new Exception("No matches found");
        _dataContext.Remove(licenseProduct);
        _dataContext.SaveChanges();
    }
}