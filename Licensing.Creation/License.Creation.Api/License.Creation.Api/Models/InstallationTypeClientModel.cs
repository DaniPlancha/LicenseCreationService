namespace License.Creation.Api.Models
{
    public class InstallationTypeClientModel
    {
        public InstallationTypeClientModel(int id, string name)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative");
            }
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            LicenseProducts = new List<LicenseProductClientModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LicenseProductClientModel> LicenseProducts { get; set; }
    }
}
