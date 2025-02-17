﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAPI.Data;

namespace RestaurantAPI.Data.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20220404221940_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("FoodPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int");

                    b.HasKey("FoodId");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(75)");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantAPI.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderDetailQuantity")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Food", b =>
                {
                    b.HasOne("RestaurantAPI.Models.OrderDetail", "OrderDetail")
                        .WithMany("FoodsList")
                        .HasForeignKey("OrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Order", b =>
                {
                    b.HasOne("RestaurantAPI.Models.Customer", "Customer")
                        .WithMany("OrdersList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RestaurantAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("RestaurantAPI.Models.Order", "Order")
                        .WithMany("GetOrderDetailsList")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Customer", b =>
                {
                    b.Navigation("OrdersList");
                });

            modelBuilder.Entity("RestaurantAPI.Models.Order", b =>
                {
                    b.Navigation("GetOrderDetailsList");
                });

            modelBuilder.Entity("RestaurantAPI.Models.OrderDetail", b =>
                {
                    b.Navigation("FoodsList");
                });
#pragma warning restore 612, 618
        }
    }
}
