using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Context.Maps;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Context
{
    public class ProjetoLivrariaContext : DbContext
    {
        public ProjetoLivrariaContext(DbContextOptions<ProjetoLivrariaContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
