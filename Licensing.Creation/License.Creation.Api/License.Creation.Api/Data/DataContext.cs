using Microsoft.EntityFrameworkCore;

namespace License.Creation.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContractType> ContractTypes => Set<ContractType>();

        public DbSet<LicenseProduct> LicenseProducts => Set<LicenseProduct>();

        public DbSet<InstallationType> InstallationTypes => Set<InstallationType>();

        public DbSet<InstallationTypesToLicenseProductsModel> InstallationTypesToLicenseProductsEntities => Set<InstallationTypesToLicenseProductsModel>();
    }
}
