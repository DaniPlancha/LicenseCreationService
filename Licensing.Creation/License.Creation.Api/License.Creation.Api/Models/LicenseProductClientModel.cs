namespace License.Creation.Api.Models
{
    public class LicenseProductClientModel
    {
        public LicenseProductClientModel(int id, int count)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative");
            }
            Id = id;
            Count = count;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }

        
    }
}
