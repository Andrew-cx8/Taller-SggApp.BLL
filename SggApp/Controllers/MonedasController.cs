using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SggApp.BLL.Interfaces;
using SggApp.DAL.Entities;
using SggApp.Web.Models;

namespace SggApp.Web.Controllers
{
    [Authorize]
    public class MonedasController : Controller
    {
        private readonly IMonedaService _monedaService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public MonedasController(IMonedaService monedaService, UserManager<Usuario> userManager, IMapper mapper)
        {
            _monedaService = monedaService;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: /Monedas/
        public async Task<IActionResult> Index()
        {
            var monedas = await _monedaService.ObtenerTodasAsync();
            var viewModels = _mapper.Map<IEnumerable<MonedaViewModel>>(monedas);
            return View(viewModels);
        }

        // GET: /Monedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Monedas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonedaFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var moneda = _mapper.Map<Moneda>(viewModel);
                await _monedaService.AgregarAsync(moneda);
                TempData["SuccessMessage"] = "Moneda creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Monedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var moneda = await _monedaService.ObtenerPorIdAsync(id.Value);
            if (moneda == null) return NotFound();
            var viewModel = _mapper.Map<MonedaFormViewModel>(moneda);
            return View(viewModel);
        }

        // POST: /Monedas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MonedaFormViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var moneda = _mapper.Map<Moneda>(viewModel);
                await _monedaService.ActualizarAsync(moneda);
                TempData["SuccessMessage"] = "Moneda actualizada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Monedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var moneda = await _monedaService.ObtenerPorIdAsync(id.Value);
            if (moneda == null) return NotFound();
            var viewModel = _mapper.Map<MonedaViewModel>(moneda);
            return View(viewModel);
        }

        // GET: /Monedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var moneda = await _monedaService.ObtenerPorIdAsync(id.Value);
            if (moneda == null) return NotFound();
            var viewModel = _mapper.Map<MonedaViewModel>(moneda);
            return View(viewModel);
        }

        // POST: /Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _monedaService.EliminarAsync(id);
            TempData["SuccessMessage"] = "Moneda eliminada exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}