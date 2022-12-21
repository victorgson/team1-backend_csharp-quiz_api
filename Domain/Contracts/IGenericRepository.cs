using System;
namespace Quiz.Domain.Contracts
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

