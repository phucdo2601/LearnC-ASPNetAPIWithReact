﻿// <auto-generated />
using LearnCRUDRestAPIAspNetRestaurantApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnCRUDRestAPIAspNetRestaurantApp.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.FoodItem", b =>
                {
                    b.Property<int>("FoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodItemId"), 1L, 1);

                    b.Property<string>("FoodItemName")
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("FoodItemName");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.HasKey("FoodItemId");

                    b.ToTable("FoodItems");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderDetail", b =>
                {
                    b.Property<long>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderDetailId"), 1L, 1);

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("FoodItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("OrderMasterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("OrderMasterId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderMaster", b =>
                {
                    b.Property<long>("OrderMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderMasterId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("GTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PMethod")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("OrderMasterId");

                    b.HasIndex("CustomerId");

                    b.ToTable("OrderMasters");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderDetail", b =>
                {
                    b.HasOne("LearnCRUDRestAPIAspNetRestaurantApp.Models.FoodItem", "FoodItem")
                        .WithMany("OrderDetails")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderMaster", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderMaster", b =>
                {
                    b.HasOne("LearnCRUDRestAPIAspNetRestaurantApp.Models.Customer", "Customer")
                        .WithMany("OrderMasters")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.Customer", b =>
                {
                    b.Navigation("OrderMasters");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.FoodItem", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("LearnCRUDRestAPIAspNetRestaurantApp.Models.OrderMaster", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
