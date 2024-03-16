﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayWiseBackend.Domain.Context;

#nullable disable

namespace PayWiseBackend.Migrations
{
    [DbContext(typeof(PaywiseDbContext))]
    partial class PaywiseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContaId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SessaoId")
                        .HasColumnType("int");

                    b.Property<bool>("TemCartao")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TemConta")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("TentativaLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("SessaoId");

                    b.HasIndex("TentativaLoginId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<double>("LimitePixGeral")
                        .HasColumnType("double");

                    b.Property<double>("LimitePixNoturno")
                        .HasColumnType("double");

                    b.Property<int>("Numero")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RgImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.TentativaLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EstaBloqueado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumeroTentativas")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TempoBloqueio")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TentativasLogin");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Cliente", b =>
                {
                    b.HasOne("PayWiseBackend.Domain.Models.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.HasOne("PayWiseBackend.Domain.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId");

                    b.HasOne("PayWiseBackend.Domain.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayWiseBackend.Domain.Models.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("SessaoId");

                    b.HasOne("PayWiseBackend.Domain.Models.TentativaLogin", "TentativaLogin")
                        .WithMany()
                        .HasForeignKey("TentativaLoginId");

                    b.Navigation("Conta");

                    b.Navigation("Documento");

                    b.Navigation("Endereco");

                    b.Navigation("Sessao");

                    b.Navigation("TentativaLogin");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Conta", b =>
                {
                    b.HasOne("PayWiseBackend.Domain.Models.Historico", "Historico")
                        .WithMany()
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Historico");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Transacao", b =>
                {
                    b.HasOne("PayWiseBackend.Domain.Models.Historico", "Historico")
                        .WithMany("Transacoes")
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Historico");
                });

            modelBuilder.Entity("PayWiseBackend.Domain.Models.Historico", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
