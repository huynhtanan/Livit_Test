using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Abc.Dal.Models;

namespace Abc.Dal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170102082126_InitializeDatabase")]
    partial class InitializeDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Abc.Dal.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbsenceStateId");

                    b.Property<int>("AbsenceTypeId");

                    b.Property<string>("Comments");

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int>("NumberOfDays");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UnvalidatedComments");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("ValidatedById");

                    b.Property<DateTime?>("ValidatedDate");

                    b.HasKey("AbsenceId");

                    b.HasIndex("AbsenceStateId");

                    b.HasIndex("AbsenceTypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UpdatedById");

                    b.HasIndex("ValidatedById");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("Abc.Dal.Models.AbsenceState", b =>
                {
                    b.Property<int>("AbsenceStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("AbsenceStateId");

                    b.ToTable("AbsenceState");
                });

            modelBuilder.Entity("Abc.Dal.Models.AbsenceType", b =>
                {
                    b.Property<int>("AbsenceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("AbsenceTypeId");

                    b.ToTable("AbsenceType");
                });

            modelBuilder.Entity("Abc.Dal.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<int>("EmployeeStatusId");

                    b.Property<int>("EmployeeTypeId");

                    b.Property<DateTime?>("EntryDate");

                    b.Property<DateTime?>("ExitDate");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CreatedById")
                        .IsUnique();

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("EmployeeTypeId");

                    b.HasIndex("UpdatedById")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Abc.Dal.Models.Employee_Role", b =>
                {
                    b.Property<int>("Employee_RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("RoleId");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Employee_RoleId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Employee_Role");
                });

            modelBuilder.Entity("Abc.Dal.Models.EmployeeStatus", b =>
                {
                    b.Property<int>("EmployeeStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("EmployeeStatusId");

                    b.ToTable("EmployeeStatus");
                });

            modelBuilder.Entity("Abc.Dal.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("EmployeeTypeId");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("Abc.Dal.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Abc.Dal.Models.Absence", b =>
                {
                    b.HasOne("Abc.Dal.Models.AbsenceState", "AbsenceState")
                        .WithMany()
                        .HasForeignKey("AbsenceStateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.AbsenceType", "AbsenceType")
                        .WithMany()
                        .HasForeignKey("AbsenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.Employee", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Abc.Dal.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.Employee", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");

                    b.HasOne("Abc.Dal.Models.Employee", "ValidatedBy")
                        .WithMany()
                        .HasForeignKey("ValidatedById");
                });

            modelBuilder.Entity("Abc.Dal.Models.Employee", b =>
                {
                    b.HasOne("Abc.Dal.Models.Employee", "CreatedBy")
                        .WithOne()
                        .HasForeignKey("Abc.Dal.Models.Employee", "CreatedById");

                    b.HasOne("Abc.Dal.Models.EmployeeStatus", "EmployeeStatus")
                        .WithMany()
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.EmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.Employee", "UpdatedBy")
                        .WithOne()
                        .HasForeignKey("Abc.Dal.Models.Employee", "UpdatedById");
                });

            modelBuilder.Entity("Abc.Dal.Models.Employee_Role", b =>
                {
                    b.HasOne("Abc.Dal.Models.Employee", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Abc.Dal.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Abc.Dal.Models.Employee", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });
        }
    }
}
