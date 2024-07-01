﻿// <auto-generated />
using System;
using FoodOnWheels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodOnWheels.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20220604094846_review+quantityInOrder")]
    partial class reviewquantityInOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodOnWheels.Models.Customer", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eamil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FristName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("UserName");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("FoodOnWheels.Models.FoodItems", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SubMenuMenuId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("SubMenuMenuId");

                    b.ToTable("foodItems");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Manager", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Man");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RiderUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerUserName");

                    b.HasIndex("ItemId");

                    b.HasIndex("ManagerUserName");

                    b.HasIndex("RiderUserName");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerUserName");

                    b.HasIndex("ManagerUserName");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Rider", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("UserName");

                    b.ToTable("rid");
                });

            modelBuilder.Entity("FoodOnWheels.Models.SubMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"), 1L, 1);

                    b.Property<string>("ManagerUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.HasIndex("ManagerUserName");

                    b.ToTable("subMenus");
                });

            modelBuilder.Entity("FoodOnWheels.Models.FoodItems", b =>
                {
                    b.HasOne("FoodOnWheels.Models.SubMenu", null)
                        .WithMany("foodItems")
                        .HasForeignKey("SubMenuMenuId");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Order", b =>
                {
                    b.HasOne("FoodOnWheels.Models.Customer", null)
                        .WithMany("orders")
                        .HasForeignKey("CustomerUserName");

                    b.HasOne("FoodOnWheels.Models.FoodItems", "foodItem")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodOnWheels.Models.Manager", null)
                        .WithMany("orders")
                        .HasForeignKey("ManagerUserName");

                    b.HasOne("FoodOnWheels.Models.Rider", null)
                        .WithMany("orders")
                        .HasForeignKey("RiderUserName");

                    b.Navigation("foodItem");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Review", b =>
                {
                    b.HasOne("FoodOnWheels.Models.Customer", null)
                        .WithMany("review")
                        .HasForeignKey("CustomerUserName");

                    b.HasOne("FoodOnWheels.Models.Manager", null)
                        .WithMany("review")
                        .HasForeignKey("ManagerUserName");
                });

            modelBuilder.Entity("FoodOnWheels.Models.SubMenu", b =>
                {
                    b.HasOne("FoodOnWheels.Models.Manager", null)
                        .WithMany("subMenus")
                        .HasForeignKey("ManagerUserName");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Customer", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("review");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Manager", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("review");

                    b.Navigation("subMenus");
                });

            modelBuilder.Entity("FoodOnWheels.Models.Rider", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("FoodOnWheels.Models.SubMenu", b =>
                {
                    b.Navigation("foodItems");
                });
#pragma warning restore 612, 618
        }
    }
}