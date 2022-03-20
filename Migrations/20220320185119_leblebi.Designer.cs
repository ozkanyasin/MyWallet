﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWallet;

#nullable disable

namespace MyWallet.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220320185119_leblebi")]
    partial class leblebi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyWallet.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ExpenseItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseItemId");

                    b.HasIndex("WalletId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("MyWallet.ExpenseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExpenseItems");
                });

            modelBuilder.Entity("MyWallet.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("SourceOfIncomeId")
                        .HasColumnType("int");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceOfIncomeId");

                    b.HasIndex("WalletId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("MyWallet.SourceOfIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SourceOfIncomes");
                });

            modelBuilder.Entity("MyWallet.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyWallet.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("MyWallet.Expense", b =>
                {
                    b.HasOne("MyWallet.ExpenseItem", "ExpenseItem")
                        .WithMany()
                        .HasForeignKey("ExpenseItemId");

                    b.HasOne("MyWallet.Wallet", null)
                        .WithMany("Expenses")
                        .HasForeignKey("WalletId");

                    b.Navigation("ExpenseItem");
                });

            modelBuilder.Entity("MyWallet.Income", b =>
                {
                    b.HasOne("MyWallet.SourceOfIncome", "SourceOfIncome")
                        .WithMany()
                        .HasForeignKey("SourceOfIncomeId");

                    b.HasOne("MyWallet.Wallet", null)
                        .WithMany("Incomes")
                        .HasForeignKey("WalletId");

                    b.Navigation("SourceOfIncome");
                });

            modelBuilder.Entity("MyWallet.Wallet", b =>
                {
                    b.HasOne("MyWallet.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyWallet.Wallet", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
