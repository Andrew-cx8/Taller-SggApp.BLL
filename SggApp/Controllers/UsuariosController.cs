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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, UserManager<Usuario> userManager, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
            _mapper = mapper;
        }

        // GET: /Usuarios/
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();
            var viewModels = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);
            return View(viewModels);
        }

        // GET: /Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = _mapper.Map<Usuario>(viewModel);
                await _usuarioService.AgregarAsync(usuario);
                TempData["SuccessMessage"] = "Usuario creado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _usuarioService.ObtenerPorIdAsync(id.Value);
            if (usuario == null) return NotFound();
            var viewModel = _mapper.Map<UsuarioFormViewModel>(usuario);
            return View(viewModel);
        }

        // POST: /Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioFormViewModel viewModel)
        {
            if (id != viewModel.Id) return NotFound();
            if (ModelState.IsValid)
            {
                var usuario = _mapper.Map<Usuario>(viewModel);
                await _usuarioService.ActualizarAsync(usuario);
                TempData["SuccessMessage"] = "Usuario actualizado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _usuarioService.ObtenerPorIdAsync(id.Value);
            if (usuario == null) return NotFound();
            var viewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return View(viewModel);
        }

        // GET: /Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _usuarioService.ObtenerPorIdAsync(id.Value);
            if (usuario == null) return NotFound();
            var viewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return View(viewModel);
        }

        // POST: /Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.EliminarAsync(id);
            TempData["SuccessMessage"] = "Usuario eliminado exitosamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}