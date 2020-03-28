using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryOfOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryOfOrigins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(32,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(maxLength: 32, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaLocations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 555, nullable: true),
                    Length = table.Column<DateTime>(nullable: false),
                    PremiereDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DirectorId = table.Column<int>(nullable: true),
                    CountryOfOriginId = table.Column<int>(nullable: true),
                    Poster = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_CountryOfOrigins_CountryOfOriginId",
                        column: x => x.CountryOfOriginId,
                        principalTable: "CountryOfOrigins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    PassportData = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    RowsCount = table.Column<int>(nullable: false),
                    SeatsCount = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: true),
                    CinemaLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_CinemaLocations_CinemaLocationId",
                        column: x => x.CinemaLocationId,
                        principalTable: "CinemaLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaHalls_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaLocationId = table.Column<int>(nullable: false),
                    FoodProductsId = table.Column<int>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodAmounts_CinemaLocations_CinemaLocationId",
                        column: x => x.CinemaLocationId,
                        principalTable: "CinemaLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodAmounts_FoodProducts_FoodProductsId",
                        column: x => x.FoodProductsId,
                        principalTable: "FoodProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDateAndTime = table.Column<DateTime>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    WorkerId1 = table.Column<Guid>(nullable: true),
                    PaidPrice = table.Column<decimal>(type: "decimal(32,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_AspNetUsers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodcourtChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDateAndTime = table.Column<DateTime>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    WorkerId1 = table.Column<Guid>(nullable: true),
                    PaidPrice = table.Column<decimal>(type: "decimal(32,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodcourtChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodcourtChecks_AspNetUsers_WorkerId1",
                        column: x => x.WorkerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    CinemaHallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showings_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Showings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodcourtCheckProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodcourtCheckId = table.Column<int>(nullable: false),
                    FoodAmountId = table.Column<int>(nullable: false),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodcourtCheckProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodcourtCheckProducts_FoodAmounts_FoodAmountId",
                        column: x => x.FoodAmountId,
                        principalTable: "FoodAmounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodcourtCheckProducts_FoodcourtChecks_FoodcourtCheckId",
                        column: x => x.FoodcourtCheckId,
                        principalTable: "FoodcourtChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowingId = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(32,2)", nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Showings_ShowingId",
                        column: x => x.ShowingId,
                        principalTable: "Showings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(nullable: false),
                    CheckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketChecks_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketChecks_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_WorkerId1",
                table: "Checks",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_CinemaLocationId",
                table: "CinemaHalls",
                column: "CinemaLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_TechnologyId",
                table: "CinemaHalls",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaLocations_CityId",
                table: "CinemaLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAmounts_CinemaLocationId",
                table: "FoodAmounts",
                column: "CinemaLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAmounts_FoodProductsId",
                table: "FoodAmounts",
                column: "FoodProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodcourtCheckProducts_FoodAmountId",
                table: "FoodcourtCheckProducts",
                column: "FoodAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodcourtCheckProducts_FoodcourtCheckId",
                table: "FoodcourtCheckProducts",
                column: "FoodcourtCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodcourtChecks_WorkerId1",
                table: "FoodcourtChecks",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CountryOfOriginId",
                table: "Movies",
                column: "CountryOfOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_CinemaHallId",
                table: "Showings",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_MovieId",
                table: "Showings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketChecks_CheckId",
                table: "TicketChecks",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketChecks_TicketId",
                table: "TicketChecks",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowingId",
                table: "Tickets",
                column: "ShowingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FoodcourtCheckProducts");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "TicketChecks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FoodAmounts");

            migrationBuilder.DropTable(
                name: "FoodcourtChecks");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "FoodProducts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Showings");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "CinemaLocations");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "CountryOfOrigins");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
