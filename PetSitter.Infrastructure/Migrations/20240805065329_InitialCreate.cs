using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSitter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sitters",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    animal_count = table.Column<int>(type: "integer", nullable: false),
                    preferences = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    building = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    index = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sitters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    building = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    index = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    type_kind = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    breed = table.Column<string>(type: "text", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    user_id1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animals", x => x.id);
                    table.ForeignKey(
                        name: "fk_animals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_animals_users_user_id1",
                        column: x => x.user_id1,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "announcements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receipt = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    transfer_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    completion_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_announcements", x => x.id);
                    table.ForeignKey(
                        name: "fk_announcements_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    symptom = table.Column<string>(type: "text", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diseases", x => x.id);
                    table.ForeignKey(
                        name: "fk_diseases_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_photos_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vaccinations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    duration_day = table.Column<int>(type: "integer", nullable: false),
                    is_time_limit = table.Column<bool>(type: "boolean", nullable: false),
                    animal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vaccinations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vaccinations_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_animals_user_id",
                table: "animals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_animals_user_id1",
                table: "animals",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "ix_announcements_animal_id",
                table: "announcements",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_diseases_animal_id",
                table: "diseases",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_photos_animal_id",
                table: "photos",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "ix_vaccinations_animal_id",
                table: "vaccinations",
                column: "animal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcements");

            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "sitters");

            migrationBuilder.DropTable(
                name: "vaccinations");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
