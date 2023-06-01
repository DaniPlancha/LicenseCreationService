using License.Creation.Api.Data;
using License.Creation.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace License.Creation.Api.Services
{
    public class InstallationTypesService
    {
        private readonly DataContext _dataContext;
        public InstallationTypesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<InstallationTypeClientModel> GetInstallationTypes() =>
            _dataContext.InstallationTypes
                .Include(x => x.ProductRelations)!
                .ThenInclude(x => x.LicenseProduct)
                .Select(x => new InstallationTypeClientModel(x.Id, x.Name)
                {
                    LicenseProducts = x.ProductRelations!.Select(y =>
                        new LicenseProductClientModel(y.LicenseProductId, y.Count)
                        {
                            Name = y.LicenseProduct!.Name
                        })
                });

        public InstallationTypeClientModel GetInstallationType(int id) =>
            GetInstallationTypes().First(x => x.Id == id);

        public void CreateInstallationType(InstallationTypeClientModel installationTypePostModel)
        {
            var entityToAdd = new InstallationType(installationTypePostModel.Id, installationTypePostModel.Name)
            {
                ProductRelations = installationTypePostModel.LicenseProducts.Select(lp =>
                    new InstallationTypesToLicenseProductsModel
                    {
                        InstallationTypeId = installationTypePostModel.Id,
                        LicenseProductId = lp.Id,
                        Count = lp.Count
                    }).ToList()
            };
            _dataContext.InstallationTypes.Add(entityToAdd);
            _dataContext.SaveChanges();
        }

        public void UpdateInstallationType(int id, InstallationTypeClientModel model)
        {
            var entityToUpdate = _dataContext.InstallationTypes
                .Include(x => x.ProductRelations)
                .FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException("Entity not found");

            if (entityToUpdate.ProductRelations!.Count < model.LicenseProducts.Count())
            {
                var product = model.LicenseProducts.Last();

                if (product.Count < 1 || (_dataContext.LicenseProducts.First(x => x.Id == product.Id).IssuedType == "Module" && product.Count != 1))
                {
                    throw new ArgumentException("Invalid count for product");
                }

                entityToUpdate.ProductRelations.Add(new InstallationTypesToLicenseProductsModel
                {
                    InstallationTypeId = model.Id,
                    LicenseProductId = product.Id,
                    Count = product.Count
                });
            }
            else if (entityToUpdate.ProductRelations!.Count > model.LicenseProducts.Count())
            {
                var relation = entityToUpdate.ProductRelations
                    .First(r => model.LicenseProducts
                        .All(x => x.Id != r.LicenseProductId));

                entityToUpdate.ProductRelations.Remove(relation);
            }

            entityToUpdate.Name = model.Name;
            _dataContext.Update(entityToUpdate);
            _dataContext.SaveChanges();
        }

        public void DeleteInstallationType(int id)
        {
            _dataContext.InstallationTypes
                .Remove(_dataContext.InstallationTypes.FirstOrDefault(x => x.Id == id)!);
            _dataContext.SaveChanges();
        }
    }
}
