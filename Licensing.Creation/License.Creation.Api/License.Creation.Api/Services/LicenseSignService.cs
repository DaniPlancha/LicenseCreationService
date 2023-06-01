using System.Security.Cryptography;
using System.Text;
using DocuWare.Management.Managed;
using DWLicenseSigningRSA;
using License.Creation.Api.Services.LicenseInfoContracts;

namespace License.Creation.Api.Services
{
    internal class LicenseSignService
    {
        private readonly LicenseInfo _license;

        public LicenseSignService(LicenseInfo license)
        {
            _license = license;
        }

        public string Sign()
        {
            /*ValidateNamedLicense();*/
            CreateSignature();

            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream, null, -1, true);
            _license.SaveXMLTo(writer);
            stream.Seek(0, SeekOrigin.Begin);

            if (string.Compare(_license.General.Version, "610", StringComparison.Ordinal) >= 0)
            {
                var signedStream = LicenseSigning.SignLicense(stream);
                signedStream.Seek(0, SeekOrigin.Begin);

                return ToString(signedStream);
            }
            return ToString(stream);
        }

        private static string ToString(Stream signedStream)
        {
            var reader = new StreamReader(signedStream);
            return reader.ReadToEnd();
        }

        /*private void ValidateNamedLicense()
        {
            if (_license.ProductInfos.Items.Any(pi => pi.Product == DWProductTypes.ReadAndApproveClient && pi.ConcurentLicenses.Count > 0))
                throw new ArgumentException("Generated license is not correct. 'Read and Approve' client license cannot have concurrent license count!");
        }*/

        private void CreateSignature()
        {
            _license.DWSignature = null;

            if (_license.General.Version == "500" || _license.General.Version == "510")
                _license.DWSignature = EncryptWithHash(_license.GetXML(), true);
            else
                _license.DWSignature = EncryptWithHash(_license.GetXML());
        }

        private string EncryptWithHash(string data, bool useDefaultEncoding = false)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            byte[] hash;
            if (useDefaultEncoding)
                hash = sha1.ComputeHash(Encoding.Default.GetBytes(data.ToCharArray()));
            else
                hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(data.ToCharArray()));

            var encryptedValue = Encrypt(hash);

            for (var i = 0; i < hash.Length; i++) hash[i] = 0;

            return encryptedValue;
        }

        private static string Encrypt(byte[] data) => ConversionService.Convert(data);



    }
}
