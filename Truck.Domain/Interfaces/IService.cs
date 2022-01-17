using System;
using System.Collections.Generic;
using System.Text;
using Truck.Domain.Entities;

namespace Truck.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity    
    {
        void Add(T input);
        IList<T> Get();        
        T GetById(int? id);
        void Delete(int id);
        T Update(T input);
    }
}
