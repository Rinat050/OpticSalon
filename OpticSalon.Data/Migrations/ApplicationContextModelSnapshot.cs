﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpticSalon.Data;

#nullable disable

namespace OpticSalon.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OpticSalon.Data.Models.BrandDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_brands");

                    b.ToTable("brands", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.ClientDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.ClientPreferencesDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<int>("FrameColorId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_color_id");

                    b.Property<int>("FrameMaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_material_id");

                    b.Property<int>("FrameSizesId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_sizes_id");

                    b.Property<int>("FrameTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_type_id");

                    b.HasKey("Id")
                        .HasName("pk_client_preferences");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_client_preferences_client_id");

                    b.HasIndex("FrameColorId")
                        .HasDatabaseName("ix_client_preferences_frame_color_id");

                    b.HasIndex("FrameMaterialId")
                        .HasDatabaseName("ix_client_preferences_frame_material_id");

                    b.HasIndex("FrameSizesId")
                        .HasDatabaseName("ix_client_preferences_frame_sizes_id");

                    b.HasIndex("FrameTypeId")
                        .HasDatabaseName("ix_client_preferences_frame_type_id");

                    b.ToTable("client_preferences", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.ColorDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_colors");

                    b.ToTable("colors", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.DefectDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_defects");

                    b.ToTable("defects", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.EmployeeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.EyeDataDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Axis")
                        .HasColumnType("integer")
                        .HasColumnName("axis");

                    b.Property<double>("Cyl")
                        .HasColumnType("double precision")
                        .HasColumnName("cyl");

                    b.Property<double>("Sph")
                        .HasColumnType("double precision")
                        .HasColumnName("sph");

                    b.HasKey("Id")
                        .HasName("pk_eye_data");

                    b.ToTable("eye_data", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameColorDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ColorId")
                        .HasColumnType("integer")
                        .HasColumnName("color_id");

                    b.Property<int>("FrameId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_id");

                    b.HasKey("Id")
                        .HasName("pk_frame_colors");

                    b.HasIndex("ColorId")
                        .HasDatabaseName("ix_frame_colors_color_id");

                    b.HasIndex("FrameId")
                        .HasDatabaseName("ix_frame_colors_frame_id");

                    b.ToTable("frame_colors", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer")
                        .HasColumnName("brand_id");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("cost");

                    b.Property<int>("GenderId")
                        .HasColumnType("integer")
                        .HasColumnName("gender_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("MainImageName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("main_image_name");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer")
                        .HasColumnName("material_id");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<int>("SizesId")
                        .HasColumnType("integer")
                        .HasColumnName("sizes_id");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    b.HasKey("Id")
                        .HasName("pk_frames");

                    b.HasIndex("BrandId")
                        .HasDatabaseName("ix_frames_brand_id");

                    b.HasIndex("GenderId")
                        .HasDatabaseName("ix_frames_gender_id");

                    b.HasIndex("MaterialId")
                        .HasDatabaseName("ix_frames_material_id");

                    b.HasIndex("SizesId")
                        .HasDatabaseName("ix_frames_sizes_id");

                    b.HasIndex("TypeId")
                        .HasDatabaseName("ix_frames_type_id");

                    b.ToTable("frames", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameMaterialDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_frame_materials");

                    b.ToTable("frame_materials", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameSizesDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DistanceBetweenLens")
                        .HasColumnType("integer")
                        .HasColumnName("distance_between_lens");

                    b.Property<int>("LensWidth")
                        .HasColumnType("integer")
                        .HasColumnName("lens_width");

                    b.Property<int>("TempleLenght")
                        .HasColumnType("integer")
                        .HasColumnName("temple_lenght");

                    b.HasKey("Id")
                        .HasName("pk_frame_sizes");

                    b.ToTable("frame_sizes", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameTypeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_frame_types");

                    b.ToTable("frame_types", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.GenderDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_genders");

                    b.ToTable("genders", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.LensPackageDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_lens_packages");

                    b.ToTable("lens_packages", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.OrderDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_phone_number");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("FrameColorId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_color_id");

                    b.Property<int>("FrameId")
                        .HasColumnType("integer")
                        .HasColumnName("frame_id");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("issue_date");

                    b.Property<int>("LensPackageId")
                        .HasColumnType("integer")
                        .HasColumnName("lens_package_id");

                    b.Property<int>("MasterId")
                        .HasColumnType("integer")
                        .HasColumnName("master_id");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer")
                        .HasColumnName("recipe_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_orders_client_id");

                    b.HasIndex("FrameColorId")
                        .HasDatabaseName("ix_orders_frame_color_id");

                    b.HasIndex("FrameId")
                        .HasDatabaseName("ix_orders_frame_id");

                    b.HasIndex("LensPackageId")
                        .HasDatabaseName("ix_orders_lens_package_id");

                    b.HasIndex("MasterId")
                        .HasDatabaseName("ix_orders_master_id");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_orders_recipe_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.PurposeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_purposes");

                    b.ToTable("purposes", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.RecipeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Dp")
                        .HasColumnType("integer")
                        .HasColumnName("dp");

                    b.Property<int>("LeftEyeId")
                        .HasColumnType("integer")
                        .HasColumnName("left_eye_id");

                    b.Property<int>("PurposeId")
                        .HasColumnType("integer")
                        .HasColumnName("purpose_id");

                    b.Property<int>("RightEyeId")
                        .HasColumnType("integer")
                        .HasColumnName("right_eye_id");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.HasIndex("LeftEyeId")
                        .HasDatabaseName("ix_recipes_left_eye_id");

                    b.HasIndex("PurposeId")
                        .HasDatabaseName("ix_recipes_purpose_id");

                    b.HasIndex("RightEyeId")
                        .HasDatabaseName("ix_recipes_right_eye_id");

                    b.ToTable("recipes", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.RepairWorkDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_repair_works");

                    b.ToTable("repair_works", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.WarrantyRepairDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("DefectId")
                        .HasColumnType("integer")
                        .HasColumnName("defect_id");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("issue_date");

                    b.Property<int>("MasterId")
                        .HasColumnType("integer")
                        .HasColumnName("master_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_warranty_repairs");

                    b.HasIndex("DefectId")
                        .HasDatabaseName("ix_warranty_repairs_defect_id");

                    b.HasIndex("MasterId")
                        .HasDatabaseName("ix_warranty_repairs_master_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_warranty_repairs_order_id");

                    b.ToTable("warranty_repairs", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.WarrantyRepairWorkDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RepairWorkId")
                        .HasColumnType("integer")
                        .HasColumnName("repair_work_id");

                    b.Property<int>("WarrantyRepairId")
                        .HasColumnType("integer")
                        .HasColumnName("warranty_repair_id");

                    b.HasKey("Id")
                        .HasName("pk_warranty_repair_works");

                    b.HasIndex("RepairWorkId")
                        .HasDatabaseName("ix_warranty_repair_works_repair_work_id");

                    b.HasIndex("WarrantyRepairId")
                        .HasDatabaseName("ix_warranty_repair_works_warranty_repair_id");

                    b.ToTable("warranty_repair_works", (string)null);
                });

            modelBuilder.Entity("OpticSalon.Data.Models.ClientPreferencesDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.ClientDb", "Client")
                        .WithMany("Preferences")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_preferences_clients_client_id");

                    b.HasOne("OpticSalon.Data.Models.ColorDb", "FrameColor")
                        .WithMany()
                        .HasForeignKey("FrameColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_preferences_colors_frame_color_id");

                    b.HasOne("OpticSalon.Data.Models.FrameMaterialDb", "FrameMaterial")
                        .WithMany()
                        .HasForeignKey("FrameMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_preferences_frame_materials_frame_material_id");

                    b.HasOne("OpticSalon.Data.Models.FrameSizesDb", "FrameSizes")
                        .WithMany()
                        .HasForeignKey("FrameSizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_preferences_frame_sizes_frame_sizes_id");

                    b.HasOne("OpticSalon.Data.Models.FrameTypeDb", "FrameType")
                        .WithMany()
                        .HasForeignKey("FrameTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_client_preferences_frame_types_frame_type_id");

                    b.Navigation("Client");

                    b.Navigation("FrameColor");

                    b.Navigation("FrameMaterial");

                    b.Navigation("FrameSizes");

                    b.Navigation("FrameType");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameColorDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.ColorDb", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frame_colors_colors_color_id");

                    b.HasOne("OpticSalon.Data.Models.FrameDb", "Frame")
                        .WithMany("Colors")
                        .HasForeignKey("FrameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frame_colors_frames_frame_id");

                    b.Navigation("Color");

                    b.Navigation("Frame");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.BrandDb", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frames_brands_brand_id");

                    b.HasOne("OpticSalon.Data.Models.GenderDb", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frames_genders_gender_id");

                    b.HasOne("OpticSalon.Data.Models.FrameMaterialDb", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frames_frame_materials_material_id");

                    b.HasOne("OpticSalon.Data.Models.FrameSizesDb", "Sizes")
                        .WithMany()
                        .HasForeignKey("SizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frames_frame_sizes_sizes_id");

                    b.HasOne("OpticSalon.Data.Models.FrameTypeDb", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_frames_frame_types_type_id");

                    b.Navigation("Brand");

                    b.Navigation("Gender");

                    b.Navigation("Material");

                    b.Navigation("Sizes");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.OrderDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.ClientDb", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_clients_client_id");

                    b.HasOne("OpticSalon.Data.Models.ColorDb", "FrameColor")
                        .WithMany()
                        .HasForeignKey("FrameColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_colors_frame_color_id");

                    b.HasOne("OpticSalon.Data.Models.FrameDb", "Frame")
                        .WithMany()
                        .HasForeignKey("FrameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_frames_frame_id");

                    b.HasOne("OpticSalon.Data.Models.LensPackageDb", "LensPackage")
                        .WithMany()
                        .HasForeignKey("LensPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_lens_packages_lens_package_id");

                    b.HasOne("OpticSalon.Data.Models.EmployeeDb", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_employees_master_id");

                    b.HasOne("OpticSalon.Data.Models.RecipeDb", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_recipes_recipe_id");

                    b.Navigation("Client");

                    b.Navigation("Frame");

                    b.Navigation("FrameColor");

                    b.Navigation("LensPackage");

                    b.Navigation("Master");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.RecipeDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.EyeDataDb", "LeftEye")
                        .WithMany()
                        .HasForeignKey("LeftEyeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_eye_data_left_eye_id");

                    b.HasOne("OpticSalon.Data.Models.PurposeDb", "Purpose")
                        .WithMany()
                        .HasForeignKey("PurposeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_purposes_purpose_id");

                    b.HasOne("OpticSalon.Data.Models.EyeDataDb", "RightEye")
                        .WithMany()
                        .HasForeignKey("RightEyeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_eye_data_right_eye_id");

                    b.Navigation("LeftEye");

                    b.Navigation("Purpose");

                    b.Navigation("RightEye");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.WarrantyRepairDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.DefectDb", "Defect")
                        .WithMany()
                        .HasForeignKey("DefectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_warranty_repairs_defects_defect_id");

                    b.HasOne("OpticSalon.Data.Models.EmployeeDb", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_warranty_repairs_employees_master_id");

                    b.HasOne("OpticSalon.Data.Models.OrderDb", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_warranty_repairs_orders_order_id");

                    b.Navigation("Defect");

                    b.Navigation("Master");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.WarrantyRepairWorkDb", b =>
                {
                    b.HasOne("OpticSalon.Data.Models.RepairWorkDb", "RepairWork")
                        .WithMany()
                        .HasForeignKey("RepairWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_warranty_repair_works_repair_works_repair_work_id");

                    b.HasOne("OpticSalon.Data.Models.WarrantyRepairDb", "WarrantyRepair")
                        .WithMany("Works")
                        .HasForeignKey("WarrantyRepairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_warranty_repair_works_warranty_repairs_warranty_repair_id");

                    b.Navigation("RepairWork");

                    b.Navigation("WarrantyRepair");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.ClientDb", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Preferences");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.FrameDb", b =>
                {
                    b.Navigation("Colors");
                });

            modelBuilder.Entity("OpticSalon.Data.Models.WarrantyRepairDb", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
