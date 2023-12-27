﻿// <auto-generated />
using System;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightDocsSystem.Migrations
{
    [DbContext(typeof(FlightDocsSystemContext))]
    [Migration("20231217065427_DBInit5")]
    partial class DBInit5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlightDocsSystem.Models.Document", b =>
                {
                    b.Property<int>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentID"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Version")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DocumentID");

                    b.HasIndex("DocumentTypeID");

                    b.HasIndex("FlightID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeID"), 1L, 1);

                    b.Property<string>("DocumentTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentTypeID");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightID"), 1L, 1);

                    b.Property<string>("Arrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FlightID");

                    b.HasIndex("UserID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupID");

                    b.HasIndex("PermissionID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.HistoryDocument", b =>
                {
                    b.Property<int>("HistoryDocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryDocumentID"), 1L, 1);

                    b.Property<int>("DocumentID")
                        .HasColumnType("int");

                    b.Property<string>("DocumentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Version")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HistoryDocumentID");

                    b.HasIndex("DocumentID");

                    b.ToTable("HistoryDocument");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"), 1L, 1);

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Setting", b =>
                {
                    b.Property<int>("SettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingID"), 1L, 1);

                    b.Property<bool?>("Captcha")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SettingID");

                    b.HasIndex("UserID");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("GroupID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Document", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.DocumentType", "documentTypes")
                        .WithMany("document")
                        .HasForeignKey("DocumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocsSystem.Models.Flight", "Flight")
                        .WithMany("documents")
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("documentTypes");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Flight", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.User", "User")
                        .WithMany("flights")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Group", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.Permission", "Permission")
                        .WithMany("Groups")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.HistoryDocument", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.Document", "Document")
                        .WithMany("historyDocuments")
                        .HasForeignKey("DocumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Setting", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.User", "User")
                        .WithMany("Settings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.User", b =>
                {
                    b.HasOne("FlightDocsSystem.Models.Group", "Group")
                        .WithMany("users")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightDocsSystem.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Document", b =>
                {
                    b.Navigation("historyDocuments");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.DocumentType", b =>
                {
                    b.Navigation("document");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Flight", b =>
                {
                    b.Navigation("documents");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Group", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Permission", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FlightDocsSystem.Models.User", b =>
                {
                    b.Navigation("Settings");

                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}
