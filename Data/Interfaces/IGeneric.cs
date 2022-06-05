namespace Data.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
