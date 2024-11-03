namespace BusinessLogic.IHelper
{
    public interface IBaseHelper<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAsync(T model);
        public Task UpdateAsync(T model);
        public Task<bool> SoftDeleteAsync(int id);
        public Task RestoreAsync(int id);
        public Task DeleteAsync(int id);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Create(T model);
        public void Update(T model);
        public bool SoftDelete(int id);
        public void Restore(int id);
        public void Delete(int id);

    }
}
