using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Models
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }

    }
}
