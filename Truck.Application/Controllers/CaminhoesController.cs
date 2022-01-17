using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Truck.Domain.Entities;
using Truck.Domain.Interfaces;
using Truck.Infra.Data;

namespace Truck.Application.Controllers
{
    public class CaminhoesController : Controller
    {
        private readonly IService<Caminhao> _service;

        public CaminhoesController(IService<Caminhao> service)
        {
            _service = service;
        }

        // GET: Caminhoes
        public IActionResult Index()
        {
            return View(_service.Get());
        }

        // GET: Caminhoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = _service.GetById(id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caminhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Placa,Modelo,AnoFabricacao,AnoModelo,Id")] Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {               
                _service.Add(caminhao);
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhoes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = _service.GetById(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return View(caminhao);
        }

        // POST: Caminhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Placa,Modelo,AnoFabricacao,AnoModelo,Id")] Caminhao caminhao)
        {
            if (id != caminhao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(caminhao);
                }
                catch (DbUpdateConcurrencyException ex)               
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhoes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = _service.GetById(id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerificaAnoFabricacao(int anoFabricacao)
        {
            if (anoFabricacao != DateTime.Now.Year)
            {
                return Json($"A user named {anoFabricacao} already exists.");
            }

            return Json(true);
        }
    }
}
