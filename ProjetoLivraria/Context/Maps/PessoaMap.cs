using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Context.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_pessoa");
            builder.Property(x => x.Nome).HasColumnName("pe_nome");
            builder.Property(x => x.Endereco).HasColumnName("pe_endereco");
            builder.Property(x => x.Telefone).HasColumnName("pe_telefone");

        }
    }
}
