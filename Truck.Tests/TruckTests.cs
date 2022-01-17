using System;
using System.Collections.Generic;
using Truck.Domain.Entities;
using Truck.Domain.Interfaces;
using Truck.Infra.Data;
using Truck.Infra.Repository;
using Truck.Service.Services;
using Xunit;

namespace Truck.Tests
{
    public class TruckTests
    {
        TruckDbContext _context;
        IService<Caminhao> _service;
        IRepository<Caminhao> _repository;
        public TruckTests()
        {
            _context = new TruckDbContext();
            _repository = new BaseReposytory<Caminhao>(_context);
            _service = new BaseService<Caminhao>(_repository);
        }

        [Theory]
        [InlineData("AAA1234", "FH", 2022, 2022)]
        [InlineData("BBB1234", "FH", 2022, 2022)]
        public void Add_Caminhoes(string placa, string modelo, int anoFabric, int anoModel)
        {
            var c = new Caminhao(placa, modelo, anoFabric, anoModel);
            _service.Add(c);
        }


        [Fact]
        public void Get_DeveRetornarUmaLista()
        {
            // Act
            var okResult = _service.Get();
            // Assert
            var items = Assert.IsType<List<Caminhao>>(okResult);
            Assert.NotEmpty(items);
        }
               
       
        [Fact]
        public void Get_DeveRetornarUmCaminhao()
        {            
            // Act
            var okResult = _service.GetById(1);
            // Assert
            Assert.IsType<Caminhao>(okResult);
        }
    }
}
