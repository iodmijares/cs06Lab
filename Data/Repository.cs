using Student.Web.Api.Models;

namespace Student.Web.Api.Data
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T newT);
        void Update<K, T>(K id, T input);
        void Delete(T item);
    }
}