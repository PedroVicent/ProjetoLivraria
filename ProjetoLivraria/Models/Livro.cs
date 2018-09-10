﻿using ProjetoLivraria.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Models
{
   
    public class Livro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public SituacaoLivroEnum Situacao { get; set; }
    }
}
