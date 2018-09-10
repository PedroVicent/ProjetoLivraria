using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivraria.Context;
using ProjetoLivraria.Models;

namespace ProjetoLivraria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LivrariaController : Controller
    {
        private readonly ProjetoLivrariaContext _projetoLivrariaContext;

        public LivrariaController(ProjetoLivrariaContext projetoLivrariaContext)
        {
            _projetoLivrariaContext = projetoLivrariaContext;
        }

        [HttpGet]
        public IActionResult Livros()
        {
            var livros = _projetoLivrariaContext.Livros.ToList();
            return View(livros);

        }

        [HttpGet]
        public IActionResult CadastroDeLivros()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarLivro([FromForm] Livro livro)
        {
            livro.Id = Guid.NewGuid();
            livro.Situacao = Models.Enum.SituacaoLivroEnum.Disponivel;
            _projetoLivrariaContext.Livros.Add(livro);

            _projetoLivrariaContext.SaveChanges();

            return RedirectToAction("Livros");
        }

        [HttpGet]
        public IActionResult Pessoas()
        {
            return View(_projetoLivrariaContext.Pessoas.ToList());
        }

        [HttpGet]
        public IActionResult CadastroDePessoas()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPessoa([FromForm] Pessoa pessoa)
        {
            pessoa.Id = Guid.NewGuid();

            _projetoLivrariaContext.Pessoas.Add(pessoa);

            _projetoLivrariaContext.SaveChanges();

            return RedirectToAction("Pessoas");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeletarPessoa(Guid id)
        {
            var pessoa = _projetoLivrariaContext.Pessoas.Find(id);

            if (pessoa != null)
            {
                _projetoLivrariaContext.Pessoas.Remove(pessoa);

                _projetoLivrariaContext.SaveChanges();

            }

            return RedirectToAction("Pessoas");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeletarLivro(Guid id)
        {
            var livro = _projetoLivrariaContext.Livros.Find(id);

            if (livro != null)
            {
                _projetoLivrariaContext.Livros.Remove(livro);

                _projetoLivrariaContext.SaveChanges();

            }

            return RedirectToAction("Livros");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        public IActionResult EditarLivro(Guid id)
        {
            return View("EditarLivro",_projetoLivrariaContext.Livros.Find(id));
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public IActionResult EditorDoLivro([FromForm] Livro livro, Guid id)
        {
            if(livro != null)
            {
                livro.Situacao = Models.Enum.SituacaoLivroEnum.Disponivel;
                _projetoLivrariaContext.Livros.Update(livro);
                _projetoLivrariaContext.SaveChanges();
            }

            return RedirectToAction("Livros");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        public IActionResult EditarPessoa(Guid id)
        {
            return View("EditarPessoa", _projetoLivrariaContext.Pessoas.Find(id));
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public IActionResult EditorDePessoa([FromForm] Pessoa pessoa, Guid id)
        {
            if (pessoa != null)
            {
                _projetoLivrariaContext.Pessoas.Update(pessoa);
                _projetoLivrariaContext.SaveChanges();
            }

            return RedirectToAction("Pessoas");
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public IActionResult MudarSituacao([FromForm]Emprestimo emprestimo,Guid idpessoa,Guid idlivro)
        {
            emprestimo.Id = new Guid();
            emprestimo.LivroId = idlivro;
            emprestimo.PessoaId = idpessoa;
            _projetoLivrariaContext.Emprestimos.Add(emprestimo);
            _projetoLivrariaContext.SaveChanges();

            return RedirectToAction("Livros");
        }

        [HttpGet]
        public IActionResult DetalhesDoLivro(Guid id)
        {
            return View("DetalhesDoLivro", _projetoLivrariaContext.Livros.Find(id));
        }

        [HttpGet]
        public IActionResult DetalhesDaPessoa(Guid id)
        {
            return View("DetalhesDaPessoa", _projetoLivrariaContext.Pessoas.Find(id));
        }

        [HttpGet]
        public IActionResult CadastrarEmprestimo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroEmprestimo([FromForm]Emprestimo emprestimo)
        {
            emprestimo.Id = new Guid();
            _projetoLivrariaContext.Emprestimos.Add(emprestimo);
            var emprestar = _projetoLivrariaContext.Livros.SingleOrDefault(x => x.Id == emprestimo.LivroId);
            if (emprestar != null)
            {
                emprestar.Situacao = Models.Enum.SituacaoLivroEnum.Emprestado;
                _projetoLivrariaContext.SaveChanges();
            }
            _projetoLivrariaContext.SaveChanges();

            return View("Emprestimo");
        }

        [HttpGet]
        public IActionResult Emprestimo()
        {
            return View( _projetoLivrariaContext.Emprestimos.ToList());
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeletarEmprestimo(Guid id)
        {
            var emprestimo = _projetoLivrariaContext.Emprestimos.Find(id);
            var livroemprestado = _projetoLivrariaContext.Livros.SingleOrDefault(x => x.Id == emprestimo.LivroId);
            if (emprestimo != null)
            {
                livroemprestado.Situacao = Models.Enum.SituacaoLivroEnum.Disponivel;

                _projetoLivrariaContext.Emprestimos.Remove(emprestimo);

                _projetoLivrariaContext.SaveChanges();

            }

            return RedirectToAction("Emprestimo");
        }
    }
}