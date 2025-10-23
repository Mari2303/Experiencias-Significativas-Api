﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.MigrationsSqlServer
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionContribution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescruotionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    CodeDane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitucional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerritorialEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestsKnow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineThematics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordRecoveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordRecoveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeDane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailInstitutional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopulationGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departaments_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EEZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EEZones_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormModules_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecoveryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecoveryCodeExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleFormPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFormPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFormPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameExperiences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThematicLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developmenttime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recognition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstitucionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Institutions_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Development",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrossCuttingProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedagogicalStrategies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CovidPandemic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Development", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Development_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccompanimentRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    StateExperienceId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceGrades_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLineThematics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    LineThematicId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLineThematics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceLineThematics_LineThematics_LineThematicId",
                        column: x => x.LineThematicId,
                        principalTable: "LineThematics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperiencePopulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    PopulationGradeId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencePopulation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperiencePopulation_PopulationGrade_PopulationGradeId",
                        column: x => x.PopulationGradeId,
                        principalTable: "PopulationGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StateExperienceId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_StateExperiences_StateExperienceId",
                        column: x => x.StateExperienceId,
                        principalTable: "StateExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameLeaders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaders_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnfoqueExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Methodologias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InnovationExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    CriteriaId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Criteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationCriterias_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitorings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitoringEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sustainability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tranfer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitorings_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaphoricalPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Testimony = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportInformations_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "DescriptionContribution", "DescruotionType", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Pertinencia", true },
                    { 2, "02", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Fundamentación", true },
                    { 3, "03", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Innovación", true },
                    { 4, "04", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Resultados", true },
                    { 5, "05", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Empoderamiento", true },
                    { 6, "06", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Seguimiento y valoración", true },
                    { 7, "07", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Transformación", true },
                    { 8, "08", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Sostenibilidad", true },
                    { 9, "09", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "", "Transferencia", true }
                });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Icon", "Name", "Order", "Path", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Vista principal del sistema.", "fa-solid fa-house", "Inicio", 1, "dashboard", true },
                    { 2, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestión de experiencias significativas.", "fa-solid fa-star", "Experiencia", 2, "experiences", true },
                    { 3, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestión de evaluaciones.", "fa-solid fa-clipboard-check", "Evaluación", 3, "evaluation", true },
                    { 4, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestión de roles del sistema.", "fa-solid fa-users-gear", "Roles", 5, "roles", true },
                    { 5, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestión de usuarios.", "fa-solid fa-users", "Usuarios", 6, "users", true },
                    { 6, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestión de personas.", "fa-solid fa-user", "Personas", 7, "persons", true },
                    { 7, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Formulario de seguimiento.", "fa-solid fa-building-user", "Seguimiento", 4, "tracking", true },
                    { 8, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Allows you to assign specific permissions to users and roles, controlling access to functions, forms, and modules according to the system's needs and security policies.", "fa-solid fa-user-lock", "Permisos", 8, "permissions", true },
                    { 9, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Manages system modules, allowing users to define, modify, and assign modules available to them based on established roles and permissions.", "fa-solid fa-window-maximize", "Modulos", 9, "modules", true },
                    { 10, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Manages the forms available in the system, allowing the creation, modification, and deletion of forms associated with different functionalities and modules.", "fa-solid fa-window-restore", "Formularios", 10, "forms", true },
                    { 11, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestiona los roles de usuario dentro del sistema, permitiendo la asignación, modificación y eliminación de permisos según las responsabilidades y niveles de acceso de cada usuario.", "fa-solid fa-window-restore", "Asignación de Roles", 11, "usersRol", true },
                    { 12, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestiona la relación entre formularios y módulos del sistema, permitiendo organizar, vincular y estructurar los formularios dentro de las diferentes secciones o áreas funcionales.", "fa-solid fa-window-restore", "Asignación de Formularios", 12, "formModule", true },
                    { 13, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Gestiona la relación entre roles y formularios del sistema, permitiendo definir, organizar y controlar los permisos de acceso y acciones que cada rol puede realizar sobre los diferentes formularios.", "fa-solid fa-window-restore", "Asignación por permisos", 13, "rolFormPermission", true }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "Primaria", true },
                    { 2, "02", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "Secundaria", true },
                    { 3, "03", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "Media", true }
                });

            migrationBuilder.InsertData(
                table: "LineThematics",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Ciencia y Tecnología", true },
                    { 2, "02", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Educación Ambiental", true },
                    { 3, "03", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Interculturalidad Bilingüismo", true },
                    { 4, "04", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Arte, Cultura y Patrimonio", true },
                    { 5, "05", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Habilidades Comunicativas", true },
                    { 6, "06", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Academica Curricular", true },
                    { 7, "07", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Inclusion Diversidad", true },
                    { 8, "08", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Convivencia Escolar (Ciencias Sociales y Políticas)", true },
                    { 9, "09", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Danza, Deporte y Recreación", true }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "El módulo de seguridad gestiona autenticación, roles, permisos y acceso a los formularios del sistema.", "Security", true },
                    { 2, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "El módulo operativo gestiona los formularios funcionales principales del sistema.", "Operational", true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Allows the user to query, update, and delete records within the system, granting full access to the management of associated data.", "Reading and writing", true },
                    { 2, "0002", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Allows the user to only view records within the system, without permission to perform updates or deletions.", "Reading only", true }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CodeDane", "CreatedAt", "DeletedAt", "DocumentType", "Email", "EmailInstitutional", "FirstLastName", "FirstName", "IdentificationNumber", "MiddleName", "Phone", "SecondLastName", "State" },
                values: new object[,]
                {
                    { 1, "441001004839", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, "mariaalejan1080@gmail.com", "mariaa_marinh@soy.sena.com", "MARIN", "MARIA", "1000000000", "ALEJANDRA", 3243652328L, "HENRIQUEZ", true },
                    { 2, "441001004840", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, "juan.perez@correo.com", "juan_perez@soy.sena.com", "PEREZ", "JUAN", "2000000000", "CARLOS", 3123456789L, "GOMEZ", true }
                });

            migrationBuilder.InsertData(
                table: "PopulationGrade",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Indigenas", true },
                    { 2, "02", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Afrocolombianos", true },
                    { 3, "03", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Mestizos", true },
                    { 4, "04", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Palenqueros", true },
                    { 5, "05", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Pequeños Productores", true },
                    { 6, "06", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Raizales", true },
                    { 7, "07", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Rom", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "", "SUPERADMIN", true },
                    { 2, "0002", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Rol para profesores", "Profesor", true }
                });

            migrationBuilder.InsertData(
                table: "StateExperiences",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Name", "State" },
                values: new object[,]
                {
                    { 1, "01", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Naciente", true },
                    { 2, "02", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Creciente", true },
                    { 3, "03", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "Inspiradora", true }
                });

            migrationBuilder.InsertData(
                table: "FormModules",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "ModuleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, 2, true },
                    { 2, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 2, 2, true },
                    { 3, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 3, 2, true },
                    { 4, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 4, 1, true },
                    { 5, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 5, 1, true },
                    { 6, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 6, 1, true },
                    { 7, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 7, 2, true },
                    { 8, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 8, 1, true },
                    { 9, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 9, 1, true },
                    { 10, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 10, 1, true },
                    { 11, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 11, 1, true },
                    { 12, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 12, 1, true },
                    { 13, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 13, 1, true }
                });

            migrationBuilder.InsertData(
                table: "RoleFormPermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FormId", "PermissionId", "RoleId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, 1, 1, true },
                    { 2, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 2, 1, 1, true },
                    { 3, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 3, 1, 1, true },
                    { 4, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 4, 1, 1, true },
                    { 5, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 5, 1, 1, true },
                    { 6, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 6, 1, 1, true },
                    { 7, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 7, 1, 1, true },
                    { 8, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 8, 1, 1, true },
                    { 9, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 9, 1, 1, true },
                    { 10, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 10, 1, 1, true },
                    { 11, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, 2, 2, true },
                    { 12, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 2, 2, 2, true },
                    { 13, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 11, 1, 1, true },
                    { 14, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 12, 1, 1, true },
                    { 15, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 13, 1, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "Password", "PersonId", "RecoveryCode", "RecoveryCodeExpiration", "State", "Username" },
                values: new object[,]
                {
                    { 1, "0001", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "202CB962AC59075B964B07152D234B70", 1, null, null, true, "mariaalejan1080@gmail.com" },
                    { 2, "0002", new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, "202CB962AC59075B964B07152D234B70", 2, null, null, true, "juan.perez@correo.com" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 1, true, 1 },
                    { 2, new DateTime(2025, 10, 23, 0, 6, 44, 106, DateTimeKind.Utc).AddTicks(4319), null, 2, true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_InstitutionId",
                table: "Addresses",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_InstitutionId",
                table: "Communes",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_InstitutionId",
                table: "Departaments",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Development_ExperienceId",
                table: "Development",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ExperienceId",
                table: "Documents",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_EEZones_InstitutionId",
                table: "EEZones",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_CriteriaId",
                table: "EvaluationCriterias",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCriterias_EvaluationId",
                table: "EvaluationCriterias",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ExperienceId",
                table: "Evaluations",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StateExperienceId",
                table: "Evaluations",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_UserId",
                table: "Evaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_ExperienceId",
                table: "ExperienceGrades",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGrades_GradeId",
                table: "ExperienceGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_ExperienceId",
                table: "ExperienceLineThematics",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceLineThematics_LineThematicId",
                table: "ExperienceLineThematics",
                column: "LineThematicId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_ExperienceId",
                table: "ExperiencePopulation",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencePopulation_PopulationGradeId",
                table: "ExperiencePopulation",
                column: "PopulationGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_InstitucionId",
                table: "Experiences",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_StateExperienceId",
                table: "Experiences",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_FormId",
                table: "FormModules",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormModules_ModuleId",
                table: "FormModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_ExperienceId",
                table: "HistoryExperiences",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_StateExperienceId",
                table: "HistoryExperiences",
                column: "StateExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExperiences_UserId",
                table: "HistoryExperiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_ExperienceId",
                table: "Leaders",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_ObjectiveId",
                table: "Monitorings",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_InstitutionId",
                table: "Municipalities",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ExperienceId",
                table: "Objectives",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_FormId",
                table: "RoleFormPermissions",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_PermissionId",
                table: "RoleFormPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFormPermissions_RoleId",
                table: "RoleFormPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportInformations_ObjectiveId",
                table: "SupportInformations",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "Development");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EEZones");

            migrationBuilder.DropTable(
                name: "EvaluationCriterias");

            migrationBuilder.DropTable(
                name: "ExperienceGrades");

            migrationBuilder.DropTable(
                name: "ExperienceLineThematics");

            migrationBuilder.DropTable(
                name: "ExperiencePopulation");

            migrationBuilder.DropTable(
                name: "FormModules");

            migrationBuilder.DropTable(
                name: "HistoryExperiences");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Monitorings");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "PasswordRecoveries");

            migrationBuilder.DropTable(
                name: "RoleFormPermissions");

            migrationBuilder.DropTable(
                name: "SupportInformations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "LineThematics");

            migrationBuilder.DropTable(
                name: "PopulationGrade");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "StateExperiences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
