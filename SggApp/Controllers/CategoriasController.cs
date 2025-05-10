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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaService categoriaService, UserManager<Usuario> userManager, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: /Categorias/
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.ObtenerTodasAsync();
            var viewModels = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);
            return View(viewModels);
        }

        // GET: /Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = _mapper.Map<Categoria>(viewModel);
                await _categoriaService.AgregarAsync(categoria);
                TempData["SuccessMessage"] = "Categoría creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.ObtenerPorIdAsync(id.Value);
            if (categoria == null) return NotFound();
            var viewModel = _mapper.Map<CategoriaFormViewModel>(categoria);
            return View(viewModel);
        }

        // POST: /Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoriaFormViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var categoria = _mapper.Map<Categoria>(viewModel);
                await _categoriaService.ActualizarAsync(categoria);
                TempData["SuccessMessage"] = "Categoría actualizada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.ObtenerPorIdAsync(id.Value);
            if (categoria == null) return NotFound();
            var viewModel = _mapper.Map<CategoriaViewModel>(categoria);
            return View(viewModel);
        }

        // GET: /Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.ObtenerPorIdAsync(id.Value);
            if (categoria == null) return NotFound();
            var viewModel = _mapper.Map<CategoriaViewModel>(categoria);
            return View(viewModel);
        }

        // POST: /Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.EliminarAsync(id);
            TempData["SuccessMessage"] = "Categoría eliminada exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}