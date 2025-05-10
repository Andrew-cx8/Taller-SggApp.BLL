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
    public class PresupuestosController : Controller
    {
        private readonly IPresupuestoService _presupuestoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMonedaService _monedaService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public PresupuestosController(IPresupuestoService presupuestoService, ICategoriaService categoriaService, IMonedaService monedaService, UserManager<Usuario> userManager, IMapper mapper)
        {
            _presupuestoService = presupuestoService;
            _categoriaService = categoriaService;
            _monedaService = monedaService;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: /Presupuestos/
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var presupuestos = await _presupuestoService.ObtenerPorUsuarioAsync(userId.Value);
            var viewModels = _mapper.Map<IEnumerable<PresupuestoViewModel>>(presupuestos);
            return View(viewModels);
        }

        // GET: /Presupuestos/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new PresupuestoFormViewModel
            {
                CategoriasDisponibles = await GetCategoriasSelectList(),
                MonedasDisponibles = await GetMonedasSelectList()
            };
            return View(viewModel);
        }

        // POST: /Presupuestos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PresupuestoFormViewModel viewModel)
        {
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            if (ModelState.IsValid)
            {
                var presupuesto = _mapper.Map<Presupuesto>(viewModel);
                presupuesto.UsuarioId = userId.Value;
                await _presupuestoService.AgregarAsync(presupuesto);
                TempData["SuccessMessage"] = "Presupuesto creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            viewModel.CategoriasDisponibles = await GetCategoriasSelectList();
            viewModel.MonedasDisponibles = await GetMonedasSelectList();
            return View(viewModel);
        }

        // GET: /Presupuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id.Value);
            if (presupuesto == null || presupuesto.UsuarioId != userId.Value) return NotFound();
            var viewModel = _mapper.Map<PresupuestoFormViewModel>(presupuesto);
            viewModel.CategoriasDisponibles = await GetCategoriasSelectList();
            viewModel.MonedasDisponibles = await GetMonedasSelectList();
            return View(viewModel);
        }

        // POST: /Presupuestos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PresupuestoFormViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var originalPresupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
            if (originalPresupuesto == null || originalPresupuesto.UsuarioId != userId.Value) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _mapper.Map(viewModel, originalPresupuesto);
                    originalPresupuesto.UsuarioId = userId.Value;
                    await _presupuestoService.ActualizarAsync(originalPresupuesto);
                    TempData["SuccessMessage"] = "Presupuesto actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PresupuestoExists(viewModel.Id, userId.Value)) return NotFound();
                    else throw;
                }
            }
            viewModel.CategoriasDisponibles = await GetCategoriasSelectList();
            viewModel.MonedasDisponibles = await GetMonedasSelectList();
            return View(viewModel);
        }

        // GET: /Presupuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id.Value);
            if (presupuesto == null || presupuesto.UsuarioId != userId.Value) return NotFound();
            var viewModel = _mapper.Map<PresupuestoViewModel>(presupuesto);
            return View(viewModel);
        }

        // GET: /Presupuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id.Value);
            if (presupuesto == null || presupuesto.UsuarioId != userId.Value) return NotFound();
            var viewModel = _mapper.Map<PresupuestoViewModel>(presupuesto);
            return View(viewModel);
        }

        // POST: /Presupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetCurrentUser Id();
            if (userId == null) return Challenge();
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
            if (presupuesto == null || presupuesto.UsuarioId != userId.Value) return NotFound();
            await _presupuestoService.EliminarAsync(id);
            TempData["SuccessMessage"] = "Presupuesto eliminado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        // --- Helper Methods ---
        private int? GetCurrentUser Id()
        {
            var userIdString = _userManager.GetUser Id(User);
            if (int.TryParse(userIdString, out int userId)) return userId;
            return null;
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriasSelectList()
        {
            var categorias = await _categoriaService.ObtenerTodasAsync();
            return categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre });
        }

        private async Task<IEnumerable<SelectListItem>> GetMonedasSelectList()
        {
            var monedas = await _monedaService.ObtenerTodasAsync();
            return monedas.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = $"{m.Nombre} ({m.Codigo})" });
        }

        private async Task<bool> PresupuestoExists(int id, int userId)
        {
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
            return presupuesto != null && presupuesto.UsuarioId == userId;
        }
    }
}