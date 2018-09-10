using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLivraria.Context.Maps
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimo", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_emprestimo");
            builder.Property(x => x.LivroId).HasColumnName("cd_livro");
            builder.Property(x => x.PessoaId).HasColumnName("cd_pessoa");
            builder.HasOne(x => x.Livro).WithMany().HasForeignKey(x => x.LivroId).IsRequired();
            builder.HasOne(x => x.Pessoa).WithMany().HasForeignKey(x => x.PessoaId).IsRequired();
        }
    }
}
