﻿// <auto-generated />
using System;
using AppCareClinicMed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppCareClinicMed.Migrations
{
    [DbContext(typeof(AppCareClinicMedContext))]
    [Migration("20190502142048_payment")]
    partial class payment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppCareClinicMed.Models.AGENDAMENTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CONVENIOId");

                    b.Property<DateTime>("Data_agendamento");

                    b.Property<int>("FORMA_PAGAMENTOId");

                    b.Property<int>("MEDICOId");

                    b.Property<int>("PACIENTEId");

                    b.Property<int>("TIPO_CONSULTAId");

                    b.Property<string>("retorno")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.HasIndex("CONVENIOId");

                    b.HasIndex("FORMA_PAGAMENTOId");

                    b.HasIndex("MEDICOId");

                    b.HasIndex("PACIENTEId");

                    b.HasIndex("TIPO_CONSULTAId");

                    b.ToTable("AGENDAMENTO");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.CLINICA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20);

                    b.Property<int>("ESTADOSId");

                    b.Property<string>("Endereco")
                        .HasMaxLength(50);

                    b.Property<string>("Nome_fantasia")
                        .HasMaxLength(50);

                    b.Property<int>("Numero");

                    b.Property<int>("PAISId");

                    b.Property<string>("Razao_social")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ESTADOSId");

                    b.HasIndex("PAISId");

                    b.ToTable("CLINICA");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.CONVENIO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CONVENIO");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.ESPECIALIDADE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ESPECIALIDADE");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.ESTADOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("ESTADOS");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.FORMA_PAGAMENTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("FORMA_PAGAMENTO");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.HISTORICO_PACIENTE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_historico");

                    b.Property<string>("Historico")
                        .HasMaxLength(2000);

                    b.Property<int>("MEDICOId");

                    b.Property<int>("PACIENTEId");

                    b.HasKey("Id");

                    b.HasIndex("MEDICOId");

                    b.HasIndex("PACIENTEId");

                    b.ToTable("HISTORICO_PACIENTE");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.MEDICO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crm")
                        .HasMaxLength(20);

                    b.Property<int>("ESPECIALIDADEId");

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ESPECIALIDADEId");

                    b.ToTable("MEDICO");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.PACIENTE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CONVENIOId");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Cpf")
                        .HasMaxLength(15);

                    b.Property<DateTime>("Data_nascimento");

                    b.Property<int>("ESTADOSId");

                    b.Property<string>("Endereco")
                        .HasMaxLength(50);

                    b.Property<string>("Estado_civil")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<int>("Numero");

                    b.Property<int>("PAISId");

                    b.Property<string>("Rg")
                        .HasMaxLength(20);

                    b.Property<string>("Sexo")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CONVENIOId");

                    b.HasIndex("ESTADOSId");

                    b.HasIndex("PAISId");

                    b.ToTable("PACIENTE");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.PAIS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pais")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PAIS");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.TIPO_CONSULTA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TIPO_CONSULTA");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.USUARIOS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("senha")
                        .HasMaxLength(20);

                    b.Property<string>("usuario")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("AppCareClinicMed.Models.AGENDAMENTO", b =>
                {
                    b.HasOne("AppCareClinicMed.Models.CONVENIO", "Convenio")
                        .WithMany()
                        .HasForeignKey("CONVENIOId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.FORMA_PAGAMENTO", "Forma_pagamento")
                        .WithMany()
                        .HasForeignKey("FORMA_PAGAMENTOId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.MEDICO", "Medico")
                        .WithMany()
                        .HasForeignKey("MEDICOId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.PACIENTE", "Paciente")
                        .WithMany()
                        .HasForeignKey("PACIENTEId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.TIPO_CONSULTA", "Tipo_consulta")
                        .WithMany()
                        .HasForeignKey("TIPO_CONSULTAId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCareClinicMed.Models.CLINICA", b =>
                {
                    b.HasOne("AppCareClinicMed.Models.ESTADOS", "Estado")
                        .WithMany()
                        .HasForeignKey("ESTADOSId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.PAIS", "Pais")
                        .WithMany()
                        .HasForeignKey("PAISId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCareClinicMed.Models.HISTORICO_PACIENTE", b =>
                {
                    b.HasOne("AppCareClinicMed.Models.MEDICO", "Medico")
                        .WithMany()
                        .HasForeignKey("MEDICOId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.PACIENTE", "Paciente")
                        .WithMany()
                        .HasForeignKey("PACIENTEId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCareClinicMed.Models.MEDICO", b =>
                {
                    b.HasOne("AppCareClinicMed.Models.ESPECIALIDADE", "Especialidade")
                        .WithMany()
                        .HasForeignKey("ESPECIALIDADEId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppCareClinicMed.Models.PACIENTE", b =>
                {
                    b.HasOne("AppCareClinicMed.Models.CONVENIO", "Convenio")
                        .WithMany()
                        .HasForeignKey("CONVENIOId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.ESTADOS", "Estado")
                        .WithMany()
                        .HasForeignKey("ESTADOSId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppCareClinicMed.Models.PAIS", "Pais")
                        .WithMany()
                        .HasForeignKey("PAISId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
