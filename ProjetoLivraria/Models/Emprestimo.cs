using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Models
{
    public class Emprestimo
    {
        public Guid Id { get; set; }
        public Guid LivroId { get; set; }
        public Guid PessoaId { get; set; }
        public Livro Livro { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
