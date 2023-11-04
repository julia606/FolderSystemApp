﻿// <auto-generated />
using System;
using DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(FoldersContext))]
    partial class FoldersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Creating Digital Images"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Resourses",
                            ParentFolderId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Evidence",
                            ParentFolderId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Graphic Products",
                            ParentFolderId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Primary Sourses",
                            ParentFolderId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Secondary Sourses",
                            ParentFolderId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Process",
                            ParentFolderId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Final Product",
                            ParentFolderId = 4
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Folder", b =>
                {
                    b.HasOne("DataAccess.Entities.Folder", "ParentFolder")
                        .WithMany("Subfolders")
                        .HasForeignKey("ParentFolderId");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("DataAccess.Entities.Folder", b =>
                {
                    b.Navigation("Subfolders");
                });
#pragma warning restore 612, 618
        }
    }
}