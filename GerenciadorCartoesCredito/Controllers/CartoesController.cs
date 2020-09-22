using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorCartoesCredito.Data;
using GerenciadorCartoesCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorCartoesCredito.Controllers
{
    public class CartoesController : Controller
    {
        private readonly Contexto _contexto;

        public CartoesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> ListagemCartoes()
        {
            return View(await _contexto.Cartoes.ToListAsync());
        }

        [HttpGet]
        public IActionResult NovoCartao()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoCartao(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                TempData["Cadastro"] = "Cartão cadastrado com sucesso.";
                await _contexto.AddAsync(cartao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemCartoes));
            }

            return View(cartao);
        }

        [HttpGet]
        public async Task<IActionResult> EditarCartao(int cartaoId)
        {
            Cartao cartao = await _contexto.Cartoes.FindAsync(cartaoId);

            if(cartao == null)
            {
                return NotFound();
            }

            return View(cartao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCartao(int cartaoId, Cartao cartao)
        {
            if(cartaoId != cartao.CartaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                TempData["Atualizacao"] = "Cartão atualizado com sucesso.";
                _contexto.Update(cartao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemCartoes));
            }
            return View(cartao);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirCartao(int cartaoId)
        {
            TempData["Exclusao"] = "Cartão excluído com sucesso.";
            Cartao cartao = await _contexto.Cartoes.FindAsync(cartaoId);
            _contexto.Cartoes.Remove(cartao);
            await _contexto.SaveChangesAsync();
            return Json("Cartão excluído com sucesso.");
        } 
    }
}
