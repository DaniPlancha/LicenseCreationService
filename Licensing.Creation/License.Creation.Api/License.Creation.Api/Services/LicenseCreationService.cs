using System.Reflection.Metadata.Ecma335;
using DocuWare.Settings.Licenses;
using License.Creation.Api.Data;
using License.Creation.Api.Models;
using License.Creation.Api.Services.LicenseInfoContracts;

namespace License.Creation.Api.Services
{
    public class LicenseCreationService
    {
        private DataContext _dataContext;
        public LicenseCreationService(DataContext data )
        {
            _dataContext= data;
        }
        public LicenseInfo CreateLicense(LicenseCreationClientModel licenseToBeCreated)
        {
            return new LicenseInfo()
            {
                General = new GeneralInfo()
                {
                    Version = licenseToBeCreated.Version,
                    Company = licenseToBeCreated.Company,
                    Phone = licenseToBeCreated.Phone,
                    EMail = licenseToBeCreated.Email,
                },
                OrganizationKey = licenseToBeCreated.OrganizationKey,
                
                ProductInfos = GetProductInfos(licenseToBeCreated.AllLicenseProducts),
                
                
            };


        }

        private  ProductInfos GetProductInfos(IEnumerable<LicenseProductClientModel> allLicenseProducts)
        {

            return new ProductInfos()
            {
                Items = allLicenseProducts.Select(GetProductInfo).ToList()
            };
        }

        private  ProductInfo GetProductInfo(LicenseProductClientModel productModel)
        {
            var issueType = GetIssueType(productModel.Id);
            var issuedTypeEnum = Enum.Parse<IssuedType>(issueType);
            var result = new ProductInfo()
            {
                   
                Product = productModel.Name,
                InfoType = new ProductType()
                {
                    ExpirationDate = DateTime.Now + TimeSpan.FromDays(365)
                },
                LiceseType = GetLicenseType(issuedTypeEnum),
            };
            if (issuedTypeEnum is IssuedType.Concurrent or IssuedType.Module or IssuedType.Server)
                result.ConcurentLicenses = new ConcurentLicense()
                {
                    Count = productModel.Count
                };
            else if (issuedTypeEnum == IssuedType.Named)
                result.NamedLicenses = Enumerable.Repeat(new NamedLicense(), productModel.Count).ToList();
            else
                throw new Exception($"Unknown issued type {issuedTypeEnum}");

            return result;
        }

        private readonly Dictionary<IssuedType, DWLicenseTypes> _issuedToLicenseTypeMap= new()
        {
            { IssuedType.Concurrent, DWLicenseTypes.ConcurrentClient },
            { IssuedType.Named, DWLicenseTypes.NamedClient},
            { IssuedType.Server, DWLicenseTypes.Server},
            { IssuedType.Module, DWLicenseTypes.ConcurrentClient},
        };

        private DWLicenseTypes GetLicenseType(IssuedType issuedTypeEnum) =>
            _issuedToLicenseTypeMap.TryGetValue(issuedTypeEnum, out var licenseTypes)
                ? licenseTypes
                : throw new Exception($"Cannot map  {issuedTypeEnum} to DWLicenseTypes");

        private string GetIssueType(int productModelId)
        {
            var licenseProduct = _dataContext.LicenseProducts.First(licenseProduct => licenseProduct.Id == productModelId);
            return licenseProduct.IssuedType;
        }

        public enum IssuedType
        {
            Module ,
            Concurrent ,
            Named ,
            Server
        }
    }   
    }

