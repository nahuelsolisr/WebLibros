﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLibreria.Models;
using ProyectoLibreria.Models.Entidades;

namespace ProyectoLibreria.Controllers
{
    public class AutoresController : Controller
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Autores.ToListAsync());
        }
        public IActionResult Crear() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Autor autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(autor);
                    await _context.SaveChangesAsync();
                    TempData["AlertaMessage"] = "Autor creado exitosamente!";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, "ha ocurrido un error");
                }

            }
            return View(autor);
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if(id == null || _context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores.FindAsync(id);
            if(autor == null)
            {
                return NotFound();
            }
            return View(autor);


        }

        public async Task<IActionResult> Editar(int id, Autor autor)
        {
            if(id != autor.Id)
            {
                return NotFound();
            }   
            if(ModelState.IsValid)
            {
                try
                {
                _context.Update(autor);
                    await _context.SaveChangesAsync();
                    TempData["AlertaMessage"] = "Autor actualizado exitosamente!";
                    return RedirectToAction("Lista");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error al actualizar");
                }
            }
            return View(autor);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores.FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            try
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                TempData["AlertaMessage"] = "Autor eliminado exitosamente!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "No se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(Lista));
        }

        }

}
