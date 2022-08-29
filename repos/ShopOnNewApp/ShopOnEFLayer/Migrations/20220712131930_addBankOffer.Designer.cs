﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopOnEFLayer.Models;

namespace ShopOnEFLayer.Migrations
{
    [DbContext(typeof(db_shoponContext))]
    [Migration("20220712131930_addBankOffer")]
    partial class addBankOffer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopOnEFLayer.Models.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IFSC")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Category", b =>
                {
                    b.Property<int>("Categoryid")
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    b.Property<string>("Category1")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("category");

                    b.HasKey("Categoryid");

                    b.ToTable("category");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Company", b =>
                {
                    b.Property<int>("Companyid")
                        .HasColumnType("int")
                        .HasColumnName("companyid");

                    b.Property<string>("Companyname")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("companyname");

                    b.Property<string>("Companystatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("companystatus")
                        .IsFixedLength(true);

                    b.Property<bool?>("Isdeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isdeleted");

                    b.HasKey("Companyid");

                    b.ToTable("company");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("OfferType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferId");

                    b.HasIndex("BankId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Product", b =>
                {
                    b.Property<int>("Pid")
                        .HasColumnType("int")
                        .HasColumnName("pid");

                    b.Property<string>("Availablestatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("availablestatus")
                        .IsFixedLength(true);

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int")
                        .HasColumnName("categoryid");

                    b.Property<int?>("Companyid")
                        .HasColumnType("int")
                        .HasColumnName("companyid");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("imageUrl");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted");

                    b.Property<double?>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("Productname")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("productname");

                    b.HasKey("Pid")
                        .HasName("PK__product__DD37D91A44BAD04F");

                    b.HasIndex("Categoryid");

                    b.HasIndex("Companyid");

                    b.ToTable("product");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Offer", b =>
                {
                    b.HasOne("ShopOnEFLayer.Models.Bank", "Bank")
                        .WithMany("Offers")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Product", b =>
                {
                    b.HasOne("ShopOnEFLayer.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Categoryid")
                        .HasConstraintName("fk_category_caid");

                    b.HasOne("ShopOnEFLayer.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("Companyid")
                        .HasConstraintName("fk_company_id");

                    b.Navigation("Category");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Bank", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopOnEFLayer.Models.Company", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
