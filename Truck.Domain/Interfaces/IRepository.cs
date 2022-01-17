using System.Collections.Generic;
using Truck.Domain.Entities;

namespace Truck.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T input);
        void Update(T input);
        void Delete(int id);
        IList<T> Select();
        T Select(int? id);
    }
}
