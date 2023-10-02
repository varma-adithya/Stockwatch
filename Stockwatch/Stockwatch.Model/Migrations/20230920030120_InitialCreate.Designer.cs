﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stockwatch.Model;

#nullable disable

namespace Stockwatch.Model.Migrations
{
    [DbContext(typeof(StockwatchDbContext))]
    [Migration("20230920030120_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Stockwatch.Model.StockAlertRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Lowerlimit")
                        .HasColumnType("TEXT");

                    b.Property<int>("StocksymbolId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SymbolId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Upperlimit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StocksymbolId");

                    b.HasIndex("SymbolId")
                        .IsUnique();

                    b.ToTable("StockAlertRanges");
                });

            modelBuilder.Entity("Stockwatch.Model.Stocksymbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SymbolName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SymbolName")
                        .IsUnique();

                    b.ToTable("StockSymbols");
                });

            modelBuilder.Entity("Stockwatch.Model.StockAlertRange", b =>
                {
                    b.HasOne("Stockwatch.Model.Stocksymbol", "Stocksymbol")
                        .WithMany()
                        .HasForeignKey("StocksymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stocksymbol");
                });
#pragma warning restore 612, 618
        }
    }
}
