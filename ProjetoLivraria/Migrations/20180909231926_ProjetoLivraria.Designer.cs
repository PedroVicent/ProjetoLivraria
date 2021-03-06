﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoLivraria.Context;

namespace ProjetoLivraria.Migrations
{
    [DbContext(typeof(ProjetoLivrariaContext))]
    [Migration("20180909231926_ProjetoLivraria")]
    partial class ProjetoLivraria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProjetoLivraria.Models.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_emprestimo");

                    b.Property<Guid>("LivroId")
                        .HasColumnName("cd_livro");

                    b.Property<Guid>("PessoaId")
                        .HasColumnName("cd_pessoa");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("emprestimo","dbo");
                });

            modelBuilder.Entity("ProjetoLivraria.Models.Livro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_livro");

                    b.Property<string>("Descricao")
                        .HasColumnName("lv_descricao");

                    b.Property<string>("Nome")
                        .HasColumnName("lv_nome");

                    b.Property<int>("Situacao")
                        .HasColumnName("lv_situacao");

                    b.HasKey("Id");

                    b.ToTable("livro","dbo");
                });

            modelBuilder.Entity("ProjetoLivraria.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cd_pessoa");

                    b.Property<string>("Endereco")
                        .HasColumnName("pe_endereco");

                    b.Property<string>("Nome")
                        .HasColumnName("pe_nome");

                    b.Property<int>("Telefone")
                        .HasColumnName("pe_telefone");

                    b.HasKey("Id");

                    b.ToTable("pessoa","dbo");
                });

            modelBuilder.Entity("ProjetoLivraria.Models.Emprestimo", b =>
                {
                    b.HasOne("ProjetoLivraria.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoLivraria.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
