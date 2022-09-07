﻿// <auto-generated />
using System;
using ChangeTrackerIssue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChangeTrackerIssue.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220907081244_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChangeTrackerIssue.Entities.MainEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("TimeUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimeUnitId");

                    b.ToTable("MainEntities");
                });

            modelBuilder.Entity("ChangeTrackerIssue.Entities.TimeUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TimeUnits");
                });

            modelBuilder.Entity("ChangeTrackerIssue.Entities.MainEntity", b =>
                {
                    b.HasOne("ChangeTrackerIssue.Entities.TimeUnit", "TimeUnit")
                        .WithMany()
                        .HasForeignKey("TimeUnitId");

                    b.Navigation("TimeUnit");
                });
#pragma warning restore 612, 618
        }
    }
}
