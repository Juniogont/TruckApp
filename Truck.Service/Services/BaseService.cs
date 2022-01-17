using System;
using System.Collections.Generic;
using System.Text;
using Truck.Domain.Entities;
using Truck.Domain.Interfaces;

namespace Truck.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _baseRepository;
        public BaseService(IRepository<T> baseReposytory)
        {
            _baseRepository = baseReposytory;
        }

        public void Add(T input)
        {
            _baseRepository.Insert(input);
        }

        public IList<T> Get() => _baseRepository.Select();

        public T GetById(int? id) => _baseRepository.Select(id);
        public void Delete(int id) => _baseRepository.Delete(id);
        public T Update(T input)
        {
            _baseRepository.Update(input);
            return input;
        }
    }
}
