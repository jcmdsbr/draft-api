using System.Collections.Generic;

namespace Core.Contracts
{
    public interface IRepositoryBase<T> where T : IEntityBase 
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int entityId);
        T GetById(int entityId);
        List<T> FindAll();
    }
}