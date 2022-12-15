using System;
namespace team1_backend_csharp_quiz_api.Contracts
{
	public interface IGenericRepository<T> where T : class
	{

        Task<T> GetAsync(Guid? id);

        Task<List<T>> GetAllAsync();

        Task<T> AddSync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);

        Task<bool> Exists(Guid id);

    }
}

