﻿// <auto-generated />
using System;
using JwtAuthAPI.Models.BankModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JwtAuthAPI.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20230405081754_InitialCode")]
    partial class InitialCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.Balance", b =>
                {
                    b.Property<int>("BalanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalBalance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BalanceID");

                    b.HasIndex("AccountID");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.Deposit", b =>
                {
                    b.Property<int>("DepositID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepositID");

                    b.HasIndex("AccountID");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.TransferMoney", b =>
                {
                    b.Property<int>("TransferMoneyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DepositDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RecipientAccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAccountNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferMoneyID");

                    b.HasIndex("AccountID");

                    b.ToTable("TransferMoneys");
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.Balance", b =>
                {
                    b.HasOne("JwtAuthAPI.Models.BankModel.Account", "Account")
                        .WithMany("Balances")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.Deposit", b =>
                {
                    b.HasOne("JwtAuthAPI.Models.BankModel.Account", "Account")
                        .WithMany("Deposits")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JwtAuthAPI.Models.BankModel.TransferMoney", b =>
                {
                    b.HasOne("JwtAuthAPI.Models.BankModel.Account", "Account")
                        .WithMany("TransferMoneys")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
