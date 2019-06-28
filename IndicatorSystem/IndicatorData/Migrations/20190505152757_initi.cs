using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndicatorData.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicatorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: true),
                    Limit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfos",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfos", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorPersons",
                columns: table => new
                {
                    MobilePhone = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    typeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorPersons", x => x.MobilePhone);
                    table.ForeignKey(
                        name: "FK_IndicatorPersons_IndicatorTypes_typeId",
                        column: x => x.typeId,
                        principalTable: "IndicatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    LoginInfoEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_LoginInfos_LoginInfoEmail",
                        column: x => x.LoginInfoEmail,
                        principalTable: "LoginInfos",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<string>(nullable: true),
                    amount = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    workerMobilePhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorTable_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicatorTable_IndicatorPersons_workerMobilePhone",
                        column: x => x.workerMobilePhone,
                        principalTable: "IndicatorPersons",
                        principalColumn: "MobilePhone",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorPersons_typeId",
                table: "IndicatorPersons",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorTable_userId",
                table: "IndicatorTable",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorTable_workerMobilePhone",
                table: "IndicatorTable",
                column: "workerMobilePhone");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoginInfoEmail",
                table: "Users",
                column: "LoginInfoEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicatorTable");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IndicatorPersons");

            migrationBuilder.DropTable(
                name: "LoginInfos");

            migrationBuilder.DropTable(
                name: "IndicatorTypes");
        }
    }
}
