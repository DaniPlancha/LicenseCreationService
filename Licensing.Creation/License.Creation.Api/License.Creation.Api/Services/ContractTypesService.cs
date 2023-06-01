using License.Creation.Api.Data;

namespace License.Creation.Api.Services
{
    public class ContractTypesService
    {
        private readonly DataContext _dataContext;
        public ContractTypesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<ContractType> GetAllModels()
        {
            return _dataContext.ContractTypes.ToList();
        }

        public ContractType GetModel(int id)
        {
            return _dataContext.ContractTypes.FirstOrDefault(ct => ct.Id == id) ?? throw new ArgumentNullException("Id not found");
        }

        public ContractType AddNewEntity(int id, string name)
        {
            var entityToAdd = new ContractType(id, name);
            _dataContext.ContractTypes.Add(entityToAdd);
            _dataContext.SaveChanges();
            return entityToAdd;
        }

        public ContractType UpdateEntity(int id, ContractType model)
        {
            var entityToUpdate = GetModel(id);
            //TODO: be able to update id (its primary key for now)
            //entityToUpdate.Id = model.Id;
            entityToUpdate.Name = model.Name;
            _dataContext.ContractTypes.Update(entityToUpdate);
            _dataContext.SaveChanges();
            return entityToUpdate;
        }

        public ContractType DeleteEntity(int id)
        {
            var entityToDelete = GetModel(id);
            _dataContext.ContractTypes.Remove(entityToDelete);
            _dataContext.SaveChanges();
            return entityToDelete;
        }
    }
}
