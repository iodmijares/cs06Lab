using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public interface IRepository<T>
    {
        void Add(T newT);
        void Delete(T item);
        Task<T> GetById<K>(K id);
        Task<bool> SaveAllChangesAsync();
    }
}