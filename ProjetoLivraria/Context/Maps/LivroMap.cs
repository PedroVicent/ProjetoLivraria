using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Context.Maps
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("livro", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_livro");
            builder.Property(x => x.Nome).HasColumnName("lv_nome");
            builder.Property(x => x.Descricao).HasColumnName("lv_descricao");
            builder.Property(x => x.Situacao).HasColumnName("lv_situacao");
        }
    }
}
