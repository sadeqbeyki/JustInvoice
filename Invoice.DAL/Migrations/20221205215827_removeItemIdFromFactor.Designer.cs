﻿// <auto-generated />
using System;
using Invoice.DAL.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invoice.DAL.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    [Migration("20221205215827_removeItemIdFromFactor")]
    partial class removeItemIdFromFactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Invoice.Domain.FactorAgg.Factor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Total")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Factors", (string)null);
                });

            modelBuilder.Entity("Invoice.Domain.ItemAgg.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("FactorId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("Sum")
                        .HasColumnType("bigint");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FactorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("Invoice.Domain.ProductAgg.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Invoice.Domain.UnitAgg.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units", (string)null);
                });

            modelBuilder.Entity("Invoice.Domain.ItemAgg.Item", b =>
                {
                    b.HasOne("Invoice.Domain.FactorAgg.Factor", "FactorName")
                        .WithMany("Items")
                        .HasForeignKey("FactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoice.Domain.ProductAgg.Product", "ProductName")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Invoice.Domain.UnitAgg.Unit", "UnitName")
                        .WithMany("Items")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FactorName");

                    b.Navigation("ProductName");

                    b.Navigation("UnitName");
                });

            modelBuilder.Entity("Invoice.Domain.FactorAgg.Factor", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Invoice.Domain.ProductAgg.Product", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Invoice.Domain.UnitAgg.Unit", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}