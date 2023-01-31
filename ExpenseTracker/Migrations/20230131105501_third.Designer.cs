﻿// <auto-generated />
using ExpenseTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseTracker.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230131105501_third")]
    partial class third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseTracker.Models.ExpenseCategoroies", b =>
                {
                    b.Property<int>("ExpenseCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseCategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseCategoryID");

                    b.ToTable("expenseCategoroies");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Expenses", b =>
                {
                    b.Property<int>("ExpenseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseID"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ExpenseCategoroyID")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("expenseCategoroiesExpenseCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ExpenseID");

                    b.HasIndex("expenseCategoroiesExpenseCategoryID");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("ExpenseTracker.Models.Expenses", b =>
                {
                    b.HasOne("ExpenseTracker.Models.ExpenseCategoroies", "expenseCategoroies")
                        .WithMany()
                        .HasForeignKey("expenseCategoroiesExpenseCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("expenseCategoroies");
                });
#pragma warning restore 612, 618
        }
    }
}
