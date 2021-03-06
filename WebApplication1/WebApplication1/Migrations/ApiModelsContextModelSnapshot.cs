﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApiModelsContext))]
    partial class ApiModelsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.English", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("English");
                });

            modelBuilder.Entity("WebApplication1.Models.Thai", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EngId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EnglishId")
                        .HasColumnType("bigint");

                    b.Property<string>("word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnglishId");

                    b.ToTable("Thai");
                });

            modelBuilder.Entity("WebApplication1.Models.chart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("intent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("point")
                        .HasColumnType("int");

                    b.Property<string>("subintent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("charts");
                });

            modelBuilder.Entity("WebApplication1.Models.Thai", b =>
                {
                    b.HasOne("WebApplication1.Models.English", "English")
                        .WithMany()
                        .HasForeignKey("EnglishId");
                });
#pragma warning restore 612, 618
        }
    }
}
