﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookApp.Models;

namespace bookApp.Migrations
{
    [DbContext(typeof(bookAppContext))]
    partial class bookAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("bookApp.Models.Books", b =>
                {
                    b.Property<long>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<long>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ClassificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .HasColumnType("TEXT");

                    b.Property<long>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassificationId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("bookApp.Models.CartLineItem", b =>
                {
                    b.Property<int>("lineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("lineID");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartLineItem");
                });

            modelBuilder.Entity("bookApp.Models.Categories", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bookApp.Models.Classifications", b =>
                {
                    b.Property<long>("ClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClassificationName")
                        .HasColumnType("TEXT");

                    b.HasKey("ClassificationId");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("bookApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("addressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("country")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("zip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("bookApp.Models.Books", b =>
                {
                    b.HasOne("bookApp.Models.Categories", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bookApp.Models.Classifications", "Classification")
                        .WithMany("Books")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bookApp.Models.CartLineItem", b =>
                {
                    b.HasOne("bookApp.Models.Books", "book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("bookApp.Models.Order", null)
                        .WithMany("lines")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}