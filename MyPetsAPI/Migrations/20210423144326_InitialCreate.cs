using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace MyPetsAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INVESTIGATION_DOCUMENT",
                columns: table => new
                {
                    investigation_document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    file = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIGATION_DOCUMENT", x => x.investigation_document_id);
                });

            migrationBuilder.CreateTable(
                name: "INVESTIGATION_PERSON",
                columns: table => new
                {
                    investigation_person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    zip_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIGATION_PERSON", x => x.investigation_person_id);
                });

            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    zip_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    hierarchy = table.Column<int>(type: "int", nullable: false),
                    zone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "INVESTIGATION",
                columns: table => new
                {
                    investigation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    holder_investigator_id = table.Column<int>(type: "int", nullable: false),
                    investigation_offender_id = table.Column<int>(type: "int", nullable: false),
                    investigation_plaintiff_id = table.Column<int>(type: "int", nullable: false),
                    reason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    breed = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    number_of_pets = table.Column<int>(type: "int", nullable: false),
                    is_finish = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIGATION", x => x.investigation_id);
                    table.ForeignKey(
                        name: "INVESTIGATION_ibfk_1",
                        column: x => x.holder_investigator_id,
                        principalTable: "PERSON",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INVESTIGATION_ibfk_2",
                        column: x => x.investigation_offender_id,
                        principalTable: "INVESTIGATION_PERSON",
                        principalColumn: "investigation_person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INVESTIGATION_ibfk_3",
                        column: x => x.investigation_plaintiff_id,
                        principalTable: "INVESTIGATION_PERSON",
                        principalColumn: "investigation_person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROUND",
                columns: table => new
                {
                    round_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    date_round = table.Column<DateTime>(type: "date", nullable: false),
                    comment_round = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    investigator_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUND", x => x.round_id);
                    table.ForeignKey(
                        name: "ROUND_ibfk_1",
                        column: x => x.investigator_id,
                        principalTable: "PERSON",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT",
                columns: table => new
                {
                    investigation_to_investigation_document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    investigation_id = table.Column<int>(type: "int", nullable: false),
                    investigation_document_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIGATION_TO_INVESTIGATION_DOCUMENT", x => x.investigation_to_investigation_document_id);
                    table.ForeignKey(
                        name: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT_ibfk_1",
                        column: x => x.investigation_id,
                        principalTable: "INVESTIGATION",
                        principalColumn: "investigation_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT_ibfk_2",
                        column: x => x.investigation_document_id,
                        principalTable: "INVESTIGATION_DOCUMENT",
                        principalColumn: "investigation_document_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INVESTIGATION_TO_ROUND",
                columns: table => new
                {
                    investigation_to_round_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    round_id = table.Column<int>(type: "int", nullable: false),
                    investigation_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVESTIGATION_TO_ROUND", x => x.investigation_to_round_id);
                    table.ForeignKey(
                        name: "INVESTIGATION_TO_ROUND_ibfk_1",
                        column: x => x.round_id,
                        principalTable: "ROUND",
                        principalColumn: "round_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "INVESTIGATION_TO_ROUND_ibfk_2",
                        column: x => x.investigation_id,
                        principalTable: "INVESTIGATION",
                        principalColumn: "investigation_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROUND_TO_INVESTIGATION_DOCUMENT",
                columns: table => new
                {
                    round_to_investigation_document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    round_id = table.Column<int>(type: "int", nullable: false),
                    investigation_document_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUND_TO_INVESTIGATION_DOCUMENT", x => x.round_to_investigation_document_id);
                    table.ForeignKey(
                        name: "ROUND_TO_INVESTIGATION_DOCUMENT_ibfk_1",
                        column: x => x.round_id,
                        principalTable: "ROUND",
                        principalColumn: "round_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ROUND_TO_INVESTIGATION_DOCUMENT_ibfk_2",
                        column: x => x.investigation_document_id,
                        principalTable: "INVESTIGATION_DOCUMENT",
                        principalColumn: "investigation_document_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "holder_investigator_id",
                table: "INVESTIGATION",
                column: "holder_investigator_id");

            migrationBuilder.CreateIndex(
                name: "investigation_offender_id",
                table: "INVESTIGATION",
                column: "investigation_offender_id");

            migrationBuilder.CreateIndex(
                name: "investigation_plaintiff_id",
                table: "INVESTIGATION",
                column: "investigation_plaintiff_id");

            migrationBuilder.CreateIndex(
                name: "investigation_document_id",
                table: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT",
                column: "investigation_document_id");

            migrationBuilder.CreateIndex(
                name: "investigation_id",
                table: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT",
                column: "investigation_id");

            migrationBuilder.CreateIndex(
                name: "investigation_id1",
                table: "INVESTIGATION_TO_ROUND",
                column: "investigation_id");

            migrationBuilder.CreateIndex(
                name: "round_id",
                table: "INVESTIGATION_TO_ROUND",
                column: "round_id");

            migrationBuilder.CreateIndex(
                name: "investigator_id",
                table: "ROUND",
                column: "investigator_id");

            migrationBuilder.CreateIndex(
                name: "investigation_document_id1",
                table: "ROUND_TO_INVESTIGATION_DOCUMENT",
                column: "investigation_document_id");

            migrationBuilder.CreateIndex(
                name: "round_id1",
                table: "ROUND_TO_INVESTIGATION_DOCUMENT",
                column: "round_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVESTIGATION_TO_INVESTIGATION_DOCUMENT");

            migrationBuilder.DropTable(
                name: "INVESTIGATION_TO_ROUND");

            migrationBuilder.DropTable(
                name: "ROUND_TO_INVESTIGATION_DOCUMENT");

            migrationBuilder.DropTable(
                name: "INVESTIGATION");

            migrationBuilder.DropTable(
                name: "ROUND");

            migrationBuilder.DropTable(
                name: "INVESTIGATION_DOCUMENT");

            migrationBuilder.DropTable(
                name: "INVESTIGATION_PERSON");

            migrationBuilder.DropTable(
                name: "PERSON");
        }
    }
}
