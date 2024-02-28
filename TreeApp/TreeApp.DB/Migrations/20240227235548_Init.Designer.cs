﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TreeApp.DB.Context;

#nullable disable

namespace TreeApp.DB.Migrations
{
    [DbContext(typeof(TreeAppDBContext))]
    [Migration("20240227235548_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TreeApp.DB.Entities.TreeNode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RootId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RootId");

                    b.HasIndex("ParentId", "Name")
                        .IsUnique();

                    b.ToTable("TreeNode", (string)null);
                });

            modelBuilder.Entity("TreeApp.DB.Entities.TreeNode", b =>
                {
                    b.HasOne("TreeApp.DB.Entities.TreeNode", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TreeApp.DB.Entities.TreeNode", "Root")
                        .WithMany("RootChildren")
                        .HasForeignKey("RootId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");

                    b.Navigation("Root");
                });

            modelBuilder.Entity("TreeApp.DB.Entities.TreeNode", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("RootChildren");
                });
#pragma warning restore 612, 618
        }
    }
}
