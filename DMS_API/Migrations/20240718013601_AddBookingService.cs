using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FPTDMS");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "varchar(max)", maxLength: 40, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dorms",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "FPTDMS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "FPTDMS",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "FPTDMS",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Dorms_DormId",
                        column: x => x.DormId,
                        principalSchema: "FPTDMS",
                        principalTable: "Dorms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Floors_FloorId",
                        column: x => x.FloorId,
                        principalSchema: "FPTDMS",
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Houses_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "FPTDMS",
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "FPTDMS",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "FPTDMS",
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingServices",
                schema: "FPTDMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsageCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingServices_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "FPTDMS",
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "FPTDMS",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0da24f70-3cc9-44b1-a48e-aa9d93635514"), null, null, "Client", "CLIENT" },
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), null, null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"), 0, null, "cf32f04b-9f04-4dd1-868b-4fe6746ec15d", null, null, "client@fpt.vn", false, "User", "Female", "Normal", false, null, "CLIENT@FPT.VN", "CLIENT", "AQAAAAIAAYagAAAAEBvXWj/nFZibcSvrT3TG5Eptd8Hu4GFbuAj58taZ6IlNGrIhz/u5AgKHEhPfrZ+5Vw==", null, false, null, null, false, "client" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, null, "3ac595e0-af21-4d60-b1fa-51090e601457", null, null, "admin@fpt.vn", false, "Admin", "Male", "Admin", false, null, "ADMIN@FPT.VN", "ADMIN", "AQAAAAIAAYagAAAAEM2aZ/Jd5n21+yvf5NoF6xzjZbazdjlEKClvn/tGytMgvz+VWc8LVIjSSwHXB8jxzg==", null, false, null, null, false, "admin" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Dorms",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Description for Dorm A", "Dorm A" },
                    { new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Description for Dorm B", "Dorm B" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0da24f70-3cc9-44b1-a48e-aa9d93635514"), new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b") },
                    { new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Balances",
                columns: new[] { "Id", "Amount", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fdbc0f7-4dc0-45ba-abb6-0869ec6f7111"), 1111f, new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b") },
                    { new Guid("c8eb5899-6008-4d51-8e8d-1c95680eb331"), 9999999f, new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Floors",
                columns: new[] { "Id", "Description", "DormId", "Name" },
                values: new object[,]
                {
                    { new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "Description for Floor 4 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 4" },
                    { new Guid("101053cc-dc11-493b-975e-3903c182be08"), "Description for Floor 3 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 3" },
                    { new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "Description for Floor 5 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 5" },
                    { new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "Description for Floor 5 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 5" },
                    { new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "Description for Floor 3 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 3" },
                    { new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "Description for Floor 2 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 2" },
                    { new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "Description for Floor 4 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 4" },
                    { new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "Description for Floor 1 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 1" },
                    { new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "Description for Floor 1 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 1" },
                    { new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "Description for Floor 2 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 2" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Houses",
                columns: new[] { "Id", "Capacity", "Description", "FloorId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("02fd6815-529c-4cc6-bb88-b50fbea00418"), 13, "Description for House 3 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.403", "Available" },
                    { new Guid("04b432de-1cca-44b5-837c-1190385e6150"), 13, "Description for House 6 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.106", "Available" },
                    { new Guid("0ce2296d-c454-46cc-9317-2e5e07d3eb00"), 13, "Description for House 2 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.502", "Available" },
                    { new Guid("1274b730-fdba-45ec-8255-478ae1228ed8"), 13, "Description for House 3 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.403", "Available" },
                    { new Guid("13256588-5ed2-4bd5-bba0-94a8e91b2706"), 13, "Description for House 1 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.101", "Available" },
                    { new Guid("13b83d69-5d15-493a-852e-f2e4b16a6f1b"), 13, "Description for House 6 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.306", "Available" },
                    { new Guid("3063ff65-9af6-4959-bfbf-e87d68d4ca2d"), 13, "Description for House 1 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.501", "Available" },
                    { new Guid("358b7d7f-0ba8-4bfe-961d-9c5d2b9ec54f"), 13, "Description for House 3 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.103", "Available" },
                    { new Guid("379c59c2-0641-4e4b-98b5-adbf0d64e60c"), 13, "Description for House 2 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.302", "Available" },
                    { new Guid("382656c5-6b07-41b6-a2ec-ef6818c6caca"), 13, "Description for House 3 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.103", "Available" },
                    { new Guid("3bb630ef-7bde-49dc-88db-ba0b5a2e0979"), 13, "Description for House 2 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.202", "Available" },
                    { new Guid("3cbe7291-bc25-463c-a145-5bae50b06559"), 13, "Description for House 6 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.206", "Available" },
                    { new Guid("3ef01b35-da1e-4bae-b800-62664e3d68e1"), 13, "Description for House 5 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.305", "Available" },
                    { new Guid("3fed2eac-846b-4c34-bd0d-097178ac4e71"), 13, "Description for House 4 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.404", "Available" },
                    { new Guid("405ee79d-e7d8-4d89-86a8-23dc808338c5"), 13, "Description for House 1 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.301", "Available" },
                    { new Guid("44ac2299-5c5d-4fcb-a354-119a35fe9d26"), 13, "Description for House 5 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.405", "Available" },
                    { new Guid("48d94947-fe0f-4dbb-850a-c2f27a5ece83"), 13, "Description for House 1 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.401", "Available" },
                    { new Guid("4b2942bb-785f-48ef-a300-dfdcc52ac46a"), 13, "Description for House 2 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.502", "Available" },
                    { new Guid("54b91079-4b99-4e95-828d-6cf4869c8018"), 13, "Description for House 3 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.303", "Available" },
                    { new Guid("564f1cbd-dfde-47ee-bb5f-53bd649039cf"), 13, "Description for House 5 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.305", "Available" },
                    { new Guid("61c14b92-054e-4a91-888e-c37c838300f2"), 13, "Description for House 4 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.304", "Available" },
                    { new Guid("642ddd90-a672-4a97-9a4b-88b84e4a3d06"), 13, "Description for House 5 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.205", "Available" },
                    { new Guid("70580b32-9edb-41ba-95c2-08b185d7bd86"), 13, "Description for House 6 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.406", "Available" },
                    { new Guid("77a568d0-9b89-4fe9-b0f5-283438251a46"), 13, "Description for House 2 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.102", "Available" },
                    { new Guid("781bc5e6-a017-4304-9eef-23a082f2b031"), 13, "Description for House 1 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.101", "Available" },
                    { new Guid("82f262f7-09dc-427a-aa02-868e61c891a1"), 13, "Description for House 5 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.105", "Available" },
                    { new Guid("85ec957f-6e7d-4fc2-ae4e-c176e41fa430"), 13, "Description for House 6 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.206", "Available" },
                    { new Guid("8721d08f-c34e-4e53-8e01-b6946e49e4f0"), 13, "Description for House 1 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.201", "Available" },
                    { new Guid("8920f9b3-d2e2-4b44-9d8b-4b6640ed7aa1"), 13, "Description for House 4 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.304", "Available" },
                    { new Guid("8c856b3c-2e64-4fe9-bf11-27f9421115ce"), 13, "Description for House 5 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.505", "Available" },
                    { new Guid("8d7c4acd-c15e-496b-b028-2d6588681a00"), 13, "Description for House 1 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.201", "Available" },
                    { new Guid("8fa058c0-6591-47e6-a4f3-24c83d55777d"), 13, "Description for House 2 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.202", "Available" },
                    { new Guid("90f8a08f-5785-4d2d-a5e2-09066dd50256"), 13, "Description for House 2 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.402", "Available" },
                    { new Guid("953d189f-e825-4fb6-b785-14577db086c6"), 13, "Description for House 1 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.401", "Available" },
                    { new Guid("962b30b7-2d60-4e64-a38a-562dbace4209"), 13, "Description for House 6 on Floor 4", new Guid("925cf051-de17-4666-801e-e06878e12ee1"), "P.406", "Available" },
                    { new Guid("995bcc0a-353b-4651-9767-b23940b12cb0"), 13, "Description for House 3 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.503", "Available" },
                    { new Guid("a253adf5-a70a-46f0-b65b-deb0d5c602c7"), 13, "Description for House 5 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.505", "Available" },
                    { new Guid("ade1d604-19ca-450a-85ec-ae512161729b"), 13, "Description for House 4 on Floor 1", new Guid("dffdf004-23f1-4fb3-a20d-bb7d1540cab9"), "P.104", "Available" },
                    { new Guid("b077b700-4800-49b8-86d8-95a25bce747b"), 13, "Description for House 4 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.504", "Available" },
                    { new Guid("b5c5e3db-7fa4-42d5-9e89-3c152563794f"), 13, "Description for House 4 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.504", "Available" },
                    { new Guid("bc68607f-a2d1-4af3-9b78-fe2c41e00aa7"), 13, "Description for House 4 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.404", "Available" },
                    { new Guid("bf1e1b31-b582-439b-acec-3df36ccbe280"), 13, "Description for House 1 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.501", "Available" },
                    { new Guid("cac9646d-54ca-49aa-8e3f-a10314bd622f"), 13, "Description for House 5 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.205", "Available" },
                    { new Guid("cd11902d-c037-46f5-af5c-986eee7df15f"), 13, "Description for House 6 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.106", "Available" },
                    { new Guid("ce290740-5e2b-4f76-ac92-c30f60888331"), 13, "Description for House 6 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.506", "Available" },
                    { new Guid("d2ec0c55-c306-4572-8c43-914fc8983de8"), 13, "Description for House 4 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.204", "Available" },
                    { new Guid("d7f9b43b-b22f-4cf2-816e-88adacf8a858"), 13, "Description for House 6 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.306", "Available" },
                    { new Guid("dcd6b446-9c27-4638-a243-34312ee3f839"), 13, "Description for House 5 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.105", "Available" },
                    { new Guid("dda1a8a4-acfc-46ea-af01-e1f634fe2144"), 13, "Description for House 6 on Floor 5", new Guid("4666e934-6896-4661-8421-050f0b53b8f3"), "P.506", "Available" },
                    { new Guid("de6a5685-00d8-4379-b01e-691abae192cb"), 13, "Description for House 3 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.203", "Available" },
                    { new Guid("e350c7af-ad63-491a-a42f-49494f52873a"), 13, "Description for House 3 on Floor 5", new Guid("20799721-965c-4d5d-8cbf-8dda507a91b3"), "P.503", "Available" },
                    { new Guid("ea6855f2-fcf4-4735-963e-61d9cebd7799"), 13, "Description for House 4 on Floor 2", new Guid("82f38165-ba21-45f8-81a2-5f539393c780"), "P.204", "Available" },
                    { new Guid("ea9ac35f-a583-4310-9771-14dff612b128"), 13, "Description for House 2 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.102", "Available" },
                    { new Guid("eaa7cf50-7cf2-42d3-8b27-22a1b0d5cf57"), 13, "Description for House 2 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.302", "Available" },
                    { new Guid("eeeb95c0-fea7-4f8e-9ae8-d75a482c3da7"), 13, "Description for House 1 on Floor 3", new Guid("101053cc-dc11-493b-975e-3903c182be08"), "P.301", "Available" },
                    { new Guid("f372f622-8543-4b9a-a41b-878a831a5c89"), 13, "Description for House 2 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.402", "Available" },
                    { new Guid("f545cefa-b63b-41f8-bfc8-db4ed1e1721a"), 13, "Description for House 3 on Floor 2", new Guid("efb34973-a158-4b01-a556-773f3c28809e"), "P.203", "Available" },
                    { new Guid("f7978713-6108-4683-a900-e5faa39a45fd"), 13, "Description for House 3 on Floor 3", new Guid("6e216d5a-15d8-4b6f-8977-988a38ac3363"), "P.303", "Available" },
                    { new Guid("fa5bc56d-8c64-4dc7-9b37-549eb9d3bbb1"), 13, "Description for House 5 on Floor 4", new Guid("0ff43133-f314-4f30-8f5b-98d91ffdc785"), "P.405", "Available" },
                    { new Guid("fe368ccb-0a9c-47a1-bca0-6402051c1fd5"), 13, "Description for House 4 on Floor 1", new Guid("a9c247e6-a16f-4bbf-9eaf-5601b740689a"), "P.104", "Available" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HouseId", "Name", "Price", "RoomType", "Status" },
                values: new object[,]
                {
                    { new Guid("02cf8459-8eff-42f5-8afb-cf1cc374f0ad"), 6, "Room with 6 Beds", new Guid("ce290740-5e2b-4f76-ac92-c30f60888331"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0368d4df-e5a1-4c05-b618-85ac87977723"), 3, "Room with 3 Beds", new Guid("de6a5685-00d8-4379-b01e-691abae192cb"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("03ba0f8f-a8ca-460f-9f61-321f5476697a"), 4, "Room with 4 Beds", new Guid("82f262f7-09dc-427a-aa02-868e61c891a1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("04f33c52-7fec-4228-8dfd-d83ba1e9cf3b"), 4, "Room with 4 Beds", new Guid("8721d08f-c34e-4e53-8e01-b6946e49e4f0"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("04f835fc-8e4e-4766-8fb8-2974e2e99580"), 4, "Room with 4 Beds", new Guid("8d7c4acd-c15e-496b-b028-2d6588681a00"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("056ff2bb-5623-42d5-bb1d-d02604a49614"), 6, "Room with 6 Beds", new Guid("3fed2eac-846b-4c34-bd0d-097178ac4e71"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("08dbe564-ebf1-400c-b084-2b835e37a02f"), 6, "Room with 6 Beds", new Guid("13b83d69-5d15-493a-852e-f2e4b16a6f1b"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0a6a446b-cbd0-410a-a46e-460be0b26b60"), 3, "Room with 3 Beds", new Guid("f372f622-8543-4b9a-a41b-878a831a5c89"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("0b291ba9-a2f5-4a14-af87-e5df2d5fcc57"), 3, "Room with 3 Beds", new Guid("dda1a8a4-acfc-46ea-af01-e1f634fe2144"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("0c73a6f0-1981-4079-978c-0a83262b33eb"), 4, "Room with 4 Beds", new Guid("13b83d69-5d15-493a-852e-f2e4b16a6f1b"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0eb8a3b3-fbce-492f-802c-a40f290b3364"), 3, "Room with 3 Beds", new Guid("54b91079-4b99-4e95-828d-6cf4869c8018"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("1066699b-e5f3-4787-bc76-8a79be830345"), 4, "Room with 4 Beds", new Guid("f372f622-8543-4b9a-a41b-878a831a5c89"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("11857be1-86eb-4952-88b8-28c57bbba0d1"), 3, "Room with 3 Beds", new Guid("61c14b92-054e-4a91-888e-c37c838300f2"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("1353b572-2d8b-48f9-a1f9-c589d3826d42"), 3, "Room with 3 Beds", new Guid("0ce2296d-c454-46cc-9317-2e5e07d3eb00"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("15a257ba-1880-40be-bdd1-d786bad6acfc"), 4, "Room with 4 Beds", new Guid("1274b730-fdba-45ec-8255-478ae1228ed8"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("182681f5-7b76-47c1-9430-afa4552961fe"), 3, "Room with 3 Beds", new Guid("fa5bc56d-8c64-4dc7-9b37-549eb9d3bbb1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("1a115778-a6b3-4729-b5a6-e58bfcfbd4d9"), 3, "Room with 3 Beds", new Guid("564f1cbd-dfde-47ee-bb5f-53bd649039cf"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("1f6e3fb9-8a41-4983-ab91-220cd5095138"), 3, "Room with 3 Beds", new Guid("a253adf5-a70a-46f0-b65b-deb0d5c602c7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("2128f2db-d8ab-4f31-be73-222b27714475"), 4, "Room with 4 Beds", new Guid("a253adf5-a70a-46f0-b65b-deb0d5c602c7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("21c9e2c7-23b6-4891-a586-a5eb5f1d4b1f"), 6, "Room with 6 Beds", new Guid("d7f9b43b-b22f-4cf2-816e-88adacf8a858"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("22dc3b32-1650-4cd1-a421-e4b579046c4f"), 4, "Room with 4 Beds", new Guid("781bc5e6-a017-4304-9eef-23a082f2b031"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("234601c9-dd27-4211-85d0-b979d0ba5b8d"), 6, "Room with 6 Beds", new Guid("3ef01b35-da1e-4bae-b800-62664e3d68e1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("23e1a630-d40e-42ae-a3e3-2031f8215f93"), 6, "Room with 6 Beds", new Guid("61c14b92-054e-4a91-888e-c37c838300f2"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("23e4ad67-54b0-4fe3-937d-f5e097a311c1"), 3, "Room with 3 Beds", new Guid("48d94947-fe0f-4dbb-850a-c2f27a5ece83"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("24450ec5-e3c5-45a4-a0e9-dc694a623fcc"), 3, "Room with 3 Beds", new Guid("3cbe7291-bc25-463c-a145-5bae50b06559"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("251db052-94fb-496a-8f89-3bb259a217b7"), 4, "Room with 4 Beds", new Guid("eeeb95c0-fea7-4f8e-9ae8-d75a482c3da7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("25d81b72-ce3d-4df7-a049-e540fe38df31"), 6, "Room with 6 Beds", new Guid("b077b700-4800-49b8-86d8-95a25bce747b"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2613147e-32f6-49c8-8fd9-8002f10c0dcf"), 6, "Room with 6 Beds", new Guid("405ee79d-e7d8-4d89-86a8-23dc808338c5"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2741edae-7c2b-4c08-99dc-614d5546dd53"), 6, "Room with 6 Beds", new Guid("48d94947-fe0f-4dbb-850a-c2f27a5ece83"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2869a476-2bc7-44e9-be74-7ece85b36571"), 4, "Room with 4 Beds", new Guid("3ef01b35-da1e-4bae-b800-62664e3d68e1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("29c78854-dbf4-4b6c-895a-bb94bc143633"), 4, "Room with 4 Beds", new Guid("b077b700-4800-49b8-86d8-95a25bce747b"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("2e4679bb-592b-4e84-84b6-a05e066be450"), 6, "Room with 6 Beds", new Guid("1274b730-fdba-45ec-8255-478ae1228ed8"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2e7833c0-e6c7-410c-b9df-1b8cd703dd9b"), 6, "Room with 6 Beds", new Guid("eeeb95c0-fea7-4f8e-9ae8-d75a482c3da7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2ec4f33e-8547-441f-9e58-f03fceda46a1"), 3, "Room with 3 Beds", new Guid("bc68607f-a2d1-4af3-9b78-fe2c41e00aa7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("322a22a9-51b6-4087-9aad-e4a188808884"), 6, "Room with 6 Beds", new Guid("8920f9b3-d2e2-4b44-9d8b-4b6640ed7aa1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("341ac2da-bea1-47a6-bffd-f330c4e5de98"), 6, "Room with 6 Beds", new Guid("4b2942bb-785f-48ef-a300-dfdcc52ac46a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("35bf3e7b-9253-42a9-9c4d-d0d8f9b6be2a"), 4, "Room with 4 Beds", new Guid("995bcc0a-353b-4651-9767-b23940b12cb0"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("38e8f5a5-ca8f-4ecc-b943-eccda325dd7f"), 6, "Room with 6 Beds", new Guid("3063ff65-9af6-4959-bfbf-e87d68d4ca2d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3978b0a1-e67b-483c-9381-31387f2f13b2"), 3, "Room with 3 Beds", new Guid("dcd6b446-9c27-4638-a243-34312ee3f839"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("39a151d9-1b16-45fe-94df-b95679a37021"), 6, "Room with 6 Beds", new Guid("f545cefa-b63b-41f8-bfc8-db4ed1e1721a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3ab850fa-c10e-4771-be22-a15582be838c"), 6, "Room with 6 Beds", new Guid("bc68607f-a2d1-4af3-9b78-fe2c41e00aa7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3b84f1ce-2304-42c0-bd27-aff60071f15a"), 4, "Room with 4 Beds", new Guid("70580b32-9edb-41ba-95c2-08b185d7bd86"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("3be78a8f-bec4-4e7e-80ae-bccc182924b5"), 6, "Room with 6 Beds", new Guid("379c59c2-0641-4e4b-98b5-adbf0d64e60c"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("3c220599-cb4d-42b6-a137-47afe0028c79"), 3, "Room with 3 Beds", new Guid("90f8a08f-5785-4d2d-a5e2-09066dd50256"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("3e9d0ada-7ffb-4b94-9778-707ed05fc7a5"), 6, "Room with 6 Beds", new Guid("eaa7cf50-7cf2-42d3-8b27-22a1b0d5cf57"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("40f3b2c3-c25e-439c-ad47-db545075b464"), 3, "Room with 3 Beds", new Guid("8721d08f-c34e-4e53-8e01-b6946e49e4f0"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4177852c-ff02-452b-a5e5-9dcc64c82e5f"), 4, "Room with 4 Beds", new Guid("04b432de-1cca-44b5-837c-1190385e6150"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("437aff13-0fc2-448d-bec8-7a4fc141ff34"), 6, "Room with 6 Beds", new Guid("de6a5685-00d8-4379-b01e-691abae192cb"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("465ccc5a-92eb-40e6-a4f5-47bd1f81b69c"), 6, "Room with 6 Beds", new Guid("ade1d604-19ca-450a-85ec-ae512161729b"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4687035a-222d-4e91-acc1-78b5f6581270"), 3, "Room with 3 Beds", new Guid("995bcc0a-353b-4651-9767-b23940b12cb0"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("46d46067-e565-4f3a-9e1d-a3bad24a30c4"), 3, "Room with 3 Beds", new Guid("1274b730-fdba-45ec-8255-478ae1228ed8"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("475060a5-2cc8-446c-b855-2025fa07bb59"), 4, "Room with 4 Beds", new Guid("379c59c2-0641-4e4b-98b5-adbf0d64e60c"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("47e804ac-d743-428d-88d9-bdb0f37fd9fa"), 6, "Room with 6 Beds", new Guid("dcd6b446-9c27-4638-a243-34312ee3f839"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("48082426-03d4-4826-b9d7-cda5922e4bb3"), 6, "Room with 6 Beds", new Guid("02fd6815-529c-4cc6-bb88-b50fbea00418"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4a05562b-c20c-4be1-b40a-d5cd1c614c4b"), 3, "Room with 3 Beds", new Guid("3bb630ef-7bde-49dc-88db-ba0b5a2e0979"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4a2b8602-446f-4d55-9818-dc227eb4013d"), 4, "Room with 4 Beds", new Guid("953d189f-e825-4fb6-b785-14577db086c6"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4b89ca10-4f90-471f-9a09-cb9c5d6b84e3"), 3, "Room with 3 Beds", new Guid("cac9646d-54ca-49aa-8e3f-a10314bd622f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4c00d59d-c537-4edd-80f5-dbb07897cf84"), 4, "Room with 4 Beds", new Guid("ce290740-5e2b-4f76-ac92-c30f60888331"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4ea518f3-98b3-4cb3-95f0-113a92a797f9"), 4, "Room with 4 Beds", new Guid("564f1cbd-dfde-47ee-bb5f-53bd649039cf"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4ec54fcb-fda3-468f-8124-537d4d148472"), 4, "Room with 4 Beds", new Guid("f545cefa-b63b-41f8-bfc8-db4ed1e1721a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4eeda5c2-b2c9-4650-a29a-2f70edded689"), 6, "Room with 6 Beds", new Guid("962b30b7-2d60-4e64-a38a-562dbace4209"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4fd33ddf-97e7-4d25-bc6d-9924bdfc9709"), 4, "Room with 4 Beds", new Guid("3cbe7291-bc25-463c-a145-5bae50b06559"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("54bf2fd8-b0d3-4431-a3f8-71e13a9f0633"), 6, "Room with 6 Beds", new Guid("cd11902d-c037-46f5-af5c-986eee7df15f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("550eb1a4-4e1f-4ed0-bb1e-30becb4f40db"), 6, "Room with 6 Beds", new Guid("dda1a8a4-acfc-46ea-af01-e1f634fe2144"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("59b81d19-0275-4d2c-b65f-870732b495a4"), 4, "Room with 4 Beds", new Guid("de6a5685-00d8-4379-b01e-691abae192cb"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("5e89bbfe-b2b0-4648-9b3c-b8f2ea0e5a0c"), 3, "Room with 3 Beds", new Guid("bf1e1b31-b582-439b-acec-3df36ccbe280"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("5eefe9a2-f62d-4bd5-809a-8aa3739a261b"), 4, "Room with 4 Beds", new Guid("642ddd90-a672-4a97-9a4b-88b84e4a3d06"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("62463e99-0d40-41d7-aeaf-b94c941c32ba"), 3, "Room with 3 Beds", new Guid("44ac2299-5c5d-4fcb-a354-119a35fe9d26"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("631decb2-3aa5-4b75-8674-19ab02c31117"), 6, "Room with 6 Beds", new Guid("bf1e1b31-b582-439b-acec-3df36ccbe280"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6630f4e3-7222-4fdb-baf0-771c77a3602e"), 4, "Room with 4 Beds", new Guid("3fed2eac-846b-4c34-bd0d-097178ac4e71"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("6cc03553-0111-4f9f-b202-7243031dc2c8"), 3, "Room with 3 Beds", new Guid("8c856b3c-2e64-4fe9-bf11-27f9421115ce"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("6cc4382b-83c1-4b33-8933-f0328df461b3"), 6, "Room with 6 Beds", new Guid("382656c5-6b07-41b6-a2ec-ef6818c6caca"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6d3574f8-6418-4625-9f7a-7b08251046d3"), 3, "Room with 3 Beds", new Guid("3063ff65-9af6-4959-bfbf-e87d68d4ca2d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("6d568e71-3631-40d4-8447-c5d2fb990b5c"), 6, "Room with 6 Beds", new Guid("8c856b3c-2e64-4fe9-bf11-27f9421115ce"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6d5bab31-69f0-4f22-98aa-89e38d218d37"), 3, "Room with 3 Beds", new Guid("04b432de-1cca-44b5-837c-1190385e6150"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("6dffa16c-d756-4078-8d4a-7b393f1e2398"), 4, "Room with 4 Beds", new Guid("85ec957f-6e7d-4fc2-ae4e-c176e41fa430"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("6f97fdc4-6843-468c-99f8-c4713880b7cb"), 4, "Room with 4 Beds", new Guid("dda1a8a4-acfc-46ea-af01-e1f634fe2144"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("70c2cdab-ab96-483a-8005-fc8b26b6d053"), 4, "Room with 4 Beds", new Guid("cac9646d-54ca-49aa-8e3f-a10314bd622f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("73550dab-2b92-4650-aa33-b7701ab31c4c"), 6, "Room with 6 Beds", new Guid("8d7c4acd-c15e-496b-b028-2d6588681a00"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7454866f-ab1d-41fd-a963-dc18ca966418"), 4, "Room with 4 Beds", new Guid("382656c5-6b07-41b6-a2ec-ef6818c6caca"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("76756709-34b1-417d-86c7-2a8789ce33a4"), 3, "Room with 3 Beds", new Guid("358b7d7f-0ba8-4bfe-961d-9c5d2b9ec54f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("77c43239-03bc-40c2-a509-2ddfafd9f323"), 6, "Room with 6 Beds", new Guid("e350c7af-ad63-491a-a42f-49494f52873a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("782ab6da-e0ab-43e6-a3ab-7d1f434d2ea3"), 3, "Room with 3 Beds", new Guid("02fd6815-529c-4cc6-bb88-b50fbea00418"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("78cba6f2-8890-4243-9edc-9fa1d9dc2b20"), 6, "Room with 6 Beds", new Guid("3cbe7291-bc25-463c-a145-5bae50b06559"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7b984181-b9ae-49f1-ad63-99e8a33dad49"), 6, "Room with 6 Beds", new Guid("44ac2299-5c5d-4fcb-a354-119a35fe9d26"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7e8d8fee-65a1-4995-b554-ff8f16b67f50"), 3, "Room with 3 Beds", new Guid("82f262f7-09dc-427a-aa02-868e61c891a1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("7f2dd536-dbac-43fa-a78e-bb2cb55e55ae"), 4, "Room with 4 Beds", new Guid("ea6855f2-fcf4-4735-963e-61d9cebd7799"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("801b6fb2-311d-407a-a8a1-c564bf4cd85b"), 6, "Room with 6 Beds", new Guid("fe368ccb-0a9c-47a1-bca0-6402051c1fd5"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("80e98c6b-753d-48a3-b134-f592e9a60697"), 4, "Room with 4 Beds", new Guid("358b7d7f-0ba8-4bfe-961d-9c5d2b9ec54f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("81e96fdd-520c-40c4-bc33-57e082ac54cc"), 4, "Room with 4 Beds", new Guid("54b91079-4b99-4e95-828d-6cf4869c8018"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("86208ee9-cb99-442a-8a48-b4433854a41f"), 6, "Room with 6 Beds", new Guid("a253adf5-a70a-46f0-b65b-deb0d5c602c7"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("870f9463-ff18-4f79-9545-1fbee3c4c0cc"), 6, "Room with 6 Beds", new Guid("85ec957f-6e7d-4fc2-ae4e-c176e41fa430"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("88b3eab0-8541-4306-ab22-2e24f37829ac"), 3, "Room with 3 Beds", new Guid("b5c5e3db-7fa4-42d5-9e89-3c152563794f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("88d66015-c471-457d-b13d-6505686a1abe"), 6, "Room with 6 Beds", new Guid("f7978713-6108-4683-a900-e5faa39a45fd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("88f232c0-1ca6-4cc7-99cc-0169e87a55e7"), 3, "Room with 3 Beds", new Guid("379c59c2-0641-4e4b-98b5-adbf0d64e60c"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8b722113-7f8f-4f1c-bff7-762d3e47b193"), 3, "Room with 3 Beds", new Guid("e350c7af-ad63-491a-a42f-49494f52873a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8d02fab3-4324-413b-9cf9-8fa54e61e3b3"), 4, "Room with 4 Beds", new Guid("ea9ac35f-a583-4310-9771-14dff612b128"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("8d9df26e-2b89-4b0f-bd22-f7a44bba8f95"), 3, "Room with 3 Beds", new Guid("ea9ac35f-a583-4310-9771-14dff612b128"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8e221ada-0017-4371-abbe-cdb48a4c0d88"), 3, "Room with 3 Beds", new Guid("ea6855f2-fcf4-4735-963e-61d9cebd7799"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8ef6572a-5c7f-45d0-9f41-ce1e9b315027"), 4, "Room with 4 Beds", new Guid("f7978713-6108-4683-a900-e5faa39a45fd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("90cdcebf-7709-4c6c-be56-8074a689242f"), 3, "Room with 3 Beds", new Guid("3fed2eac-846b-4c34-bd0d-097178ac4e71"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("91e10e3d-4833-41eb-8f38-0c268e93db7d"), 6, "Room with 6 Beds", new Guid("642ddd90-a672-4a97-9a4b-88b84e4a3d06"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("943a5da6-6fd3-4989-955a-3e07c7681767"), 6, "Room with 6 Beds", new Guid("3bb630ef-7bde-49dc-88db-ba0b5a2e0979"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("951d7996-47fe-44a5-b07e-d07343259893"), 6, "Room with 6 Beds", new Guid("564f1cbd-dfde-47ee-bb5f-53bd649039cf"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("9573d51a-1dca-4882-bdc6-798770aa1e57"), 4, "Room with 4 Beds", new Guid("d2ec0c55-c306-4572-8c43-914fc8983de8"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("97fb7a4f-be5e-433a-9bf3-ca1a097e0a38"), 3, "Room with 3 Beds", new Guid("d2ec0c55-c306-4572-8c43-914fc8983de8"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("9c380377-13ef-4112-9108-15b21cb66e1c"), 4, "Room with 4 Beds", new Guid("8c856b3c-2e64-4fe9-bf11-27f9421115ce"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9ee0e410-e536-4cbc-a590-5f42462e094b"), 3, "Room with 3 Beds", new Guid("cd11902d-c037-46f5-af5c-986eee7df15f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a3b1b234-d5a8-457d-b828-cab90c1bc83c"), 6, "Room with 6 Beds", new Guid("82f262f7-09dc-427a-aa02-868e61c891a1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a521414c-5136-4a63-8239-66ee5c3f63b0"), 6, "Room with 6 Beds", new Guid("358b7d7f-0ba8-4bfe-961d-9c5d2b9ec54f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a845755e-fb24-4e90-9341-5b9d9644186d"), 3, "Room with 3 Beds", new Guid("fe368ccb-0a9c-47a1-bca0-6402051c1fd5"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a8a3cdb8-b8e6-4578-8633-89bfa6989f35"), 4, "Room with 4 Beds", new Guid("77a568d0-9b89-4fe9-b0f5-283438251a46"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("a9fb3512-0a1e-4125-a770-d1391d2faa6a"), 6, "Room with 6 Beds", new Guid("8fa058c0-6591-47e6-a4f3-24c83d55777d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("aac87d4c-a47f-45dd-9f92-945774c2d425"), 4, "Room with 4 Beds", new Guid("13256588-5ed2-4bd5-bba0-94a8e91b2706"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ad082e2e-4a2d-43c9-9163-66a3ca69a1c2"), 3, "Room with 3 Beds", new Guid("405ee79d-e7d8-4d89-86a8-23dc808338c5"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("af3fa88a-7cbd-4618-ba59-38dc16c12913"), 6, "Room with 6 Beds", new Guid("54b91079-4b99-4e95-828d-6cf4869c8018"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b0ff8f19-889e-4864-89b4-e7d47c6980f1"), 3, "Room with 3 Beds", new Guid("13256588-5ed2-4bd5-bba0-94a8e91b2706"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b18b3068-1d9a-4c57-abb3-9dfddf452ecb"), 3, "Room with 3 Beds", new Guid("382656c5-6b07-41b6-a2ec-ef6818c6caca"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b1d1a8b0-ee8b-4e28-9676-711f25a8c484"), 4, "Room with 4 Beds", new Guid("8920f9b3-d2e2-4b44-9d8b-4b6640ed7aa1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b1e56e16-0ea8-4174-acd6-045e9924d70c"), 4, "Room with 4 Beds", new Guid("4b2942bb-785f-48ef-a300-dfdcc52ac46a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b3f0716f-a831-4eac-b8c4-cd80f90fae1a"), 3, "Room with 3 Beds", new Guid("70580b32-9edb-41ba-95c2-08b185d7bd86"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b5a427ab-b3ad-4409-80b8-45152ff20cbb"), 6, "Room with 6 Beds", new Guid("995bcc0a-353b-4651-9767-b23940b12cb0"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b6d8a48d-1433-485b-8f00-a59fa9a9ee59"), 4, "Room with 4 Beds", new Guid("44ac2299-5c5d-4fcb-a354-119a35fe9d26"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("bae6ea6f-d93e-446d-b138-9ca419f43d12"), 4, "Room with 4 Beds", new Guid("eaa7cf50-7cf2-42d3-8b27-22a1b0d5cf57"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("bd07401e-43bd-42a6-8692-34c693ffd4ae"), 4, "Room with 4 Beds", new Guid("0ce2296d-c454-46cc-9317-2e5e07d3eb00"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("bda9c9bf-3db4-4bba-8c31-096b81a7d346"), 4, "Room with 4 Beds", new Guid("bf1e1b31-b582-439b-acec-3df36ccbe280"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("be6c854e-d363-44ca-914e-5654f2087ed2"), 6, "Room with 6 Beds", new Guid("f372f622-8543-4b9a-a41b-878a831a5c89"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c072a423-2816-44fa-8458-07879806b6f2"), 4, "Room with 4 Beds", new Guid("bc68607f-a2d1-4af3-9b78-fe2c41e00aa7"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c2958371-b878-4b9b-b21b-e312e02d72cf"), 6, "Room with 6 Beds", new Guid("781bc5e6-a017-4304-9eef-23a082f2b031"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c329127a-06be-432d-a773-9ab89133dceb"), 3, "Room with 3 Beds", new Guid("13b83d69-5d15-493a-852e-f2e4b16a6f1b"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c3b8eecb-1c02-4f7c-9807-721da4c4735c"), 3, "Room with 3 Beds", new Guid("ce290740-5e2b-4f76-ac92-c30f60888331"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c43153dc-7433-4093-8946-0d22cd47486d"), 4, "Room with 4 Beds", new Guid("cd11902d-c037-46f5-af5c-986eee7df15f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c4f41e9d-152c-47b6-8ed2-b283d7b10599"), 4, "Room with 4 Beds", new Guid("8fa058c0-6591-47e6-a4f3-24c83d55777d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c6dfb767-1c85-4858-b149-88b1fff2ec30"), 3, "Room with 3 Beds", new Guid("8d7c4acd-c15e-496b-b028-2d6588681a00"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c71f6eb1-c5c2-4237-949d-0a0efb4d8b85"), 6, "Room with 6 Beds", new Guid("b5c5e3db-7fa4-42d5-9e89-3c152563794f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c794c727-f87e-42b5-8ca6-8a106ab237de"), 3, "Room with 3 Beds", new Guid("3ef01b35-da1e-4bae-b800-62664e3d68e1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c7dc612f-d7c2-4f14-97dc-2524d13c85cc"), 6, "Room with 6 Beds", new Guid("8721d08f-c34e-4e53-8e01-b6946e49e4f0"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c8871f8d-8851-496d-9ae9-39498eab1add"), 4, "Room with 4 Beds", new Guid("dcd6b446-9c27-4638-a243-34312ee3f839"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("cc5a3eaa-7aae-411a-a3a0-48a5a6d8b527"), 3, "Room with 3 Beds", new Guid("642ddd90-a672-4a97-9a4b-88b84e4a3d06"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ccdf0ac0-19e2-4b82-bc47-0a27c4ac6ebf"), 3, "Room with 3 Beds", new Guid("ade1d604-19ca-450a-85ec-ae512161729b"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ce4f4489-2448-4a61-8754-45caffc0fce3"), 4, "Room with 4 Beds", new Guid("b5c5e3db-7fa4-42d5-9e89-3c152563794f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ce6968d5-0528-4b5c-b81d-1caf278ca217"), 6, "Room with 6 Beds", new Guid("90f8a08f-5785-4d2d-a5e2-09066dd50256"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("cfc2e620-4fa6-4ffd-a7ae-7fc062f95977"), 6, "Room with 6 Beds", new Guid("0ce2296d-c454-46cc-9317-2e5e07d3eb00"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d0ca1c32-72b0-48bb-9474-7d6817a00600"), 4, "Room with 4 Beds", new Guid("02fd6815-529c-4cc6-bb88-b50fbea00418"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d0f697f4-6e63-442c-92d7-a9be5f13cc22"), 3, "Room with 3 Beds", new Guid("8920f9b3-d2e2-4b44-9d8b-4b6640ed7aa1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d27096cb-cb69-4c85-9cfd-cdd38f42e660"), 4, "Room with 4 Beds", new Guid("405ee79d-e7d8-4d89-86a8-23dc808338c5"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d37a7d29-2311-4ab8-9955-08d2a41f3c09"), 4, "Room with 4 Beds", new Guid("d7f9b43b-b22f-4cf2-816e-88adacf8a858"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d4ccf43a-affe-4957-83f8-9e5ee8edc8b6"), 6, "Room with 6 Beds", new Guid("13256588-5ed2-4bd5-bba0-94a8e91b2706"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d5cf508a-fe28-4d66-a8db-821aaf8a1abd"), 4, "Room with 4 Beds", new Guid("48d94947-fe0f-4dbb-850a-c2f27a5ece83"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d66ff79e-6586-4da7-a780-7861dccca14f"), 4, "Room with 4 Beds", new Guid("962b30b7-2d60-4e64-a38a-562dbace4209"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d8048dc1-8567-45fc-84ad-37b36aa8785c"), 3, "Room with 3 Beds", new Guid("b077b700-4800-49b8-86d8-95a25bce747b"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d880d03d-ef70-4b96-8528-7b5f2a7c2580"), 4, "Room with 4 Beds", new Guid("e350c7af-ad63-491a-a42f-49494f52873a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d9766936-33f0-42b1-9ec8-13b7c55d40a1"), 6, "Room with 6 Beds", new Guid("ea6855f2-fcf4-4735-963e-61d9cebd7799"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d9a0c5df-76ce-4eca-84ea-bcca4ece1886"), 4, "Room with 4 Beds", new Guid("3063ff65-9af6-4959-bfbf-e87d68d4ca2d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("d9b2cfb2-c200-4b40-9058-4c7e40627c0a"), 3, "Room with 3 Beds", new Guid("f7978713-6108-4683-a900-e5faa39a45fd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d9c64683-438c-4d8e-b018-5bd3e304f5e1"), 3, "Room with 3 Beds", new Guid("85ec957f-6e7d-4fc2-ae4e-c176e41fa430"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("dadf73bd-488c-4c47-ad06-382c96f1708b"), 6, "Room with 6 Beds", new Guid("04b432de-1cca-44b5-837c-1190385e6150"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("dd1d5316-ddb9-475b-b224-11b9a69ac04e"), 4, "Room with 4 Beds", new Guid("90f8a08f-5785-4d2d-a5e2-09066dd50256"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("deead2f1-99fc-4946-860f-a4a574e9d8c0"), 6, "Room with 6 Beds", new Guid("d2ec0c55-c306-4572-8c43-914fc8983de8"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e13ce80d-aef5-4c7c-a33d-af831feead8e"), 3, "Room with 3 Beds", new Guid("953d189f-e825-4fb6-b785-14577db086c6"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e1ea12eb-d863-496a-ab4c-44f72c259bbd"), 3, "Room with 3 Beds", new Guid("f545cefa-b63b-41f8-bfc8-db4ed1e1721a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e2e743e0-8fe7-4a9e-8022-0f820a9711bd"), 3, "Room with 3 Beds", new Guid("eaa7cf50-7cf2-42d3-8b27-22a1b0d5cf57"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e3d25420-11b3-4e66-85b5-cb339524e007"), 4, "Room with 4 Beds", new Guid("ade1d604-19ca-450a-85ec-ae512161729b"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("eaa1c6af-8cac-4201-8816-f2a1412ad1ad"), 3, "Room with 3 Beds", new Guid("8fa058c0-6591-47e6-a4f3-24c83d55777d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("eacb62f6-7ab5-4a97-9c59-d18f96aef88d"), 4, "Room with 4 Beds", new Guid("fe368ccb-0a9c-47a1-bca0-6402051c1fd5"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("eeb11cd4-f095-47bf-b192-b19d7b9d7c7d"), 3, "Room with 3 Beds", new Guid("eeeb95c0-fea7-4f8e-9ae8-d75a482c3da7"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ef9b2ecb-1d21-43da-a148-0495a2ff6c71"), 6, "Room with 6 Beds", new Guid("70580b32-9edb-41ba-95c2-08b185d7bd86"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("f0f2d612-24b0-4668-80b4-7d4eb4483e4b"), 6, "Room with 6 Beds", new Guid("77a568d0-9b89-4fe9-b0f5-283438251a46"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("f189e57a-997a-415e-8d9f-3f1f203b9a86"), 3, "Room with 3 Beds", new Guid("4b2942bb-785f-48ef-a300-dfdcc52ac46a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f647aaa2-4d1a-4238-bb97-77fa91487bd2"), 4, "Room with 4 Beds", new Guid("fa5bc56d-8c64-4dc7-9b37-549eb9d3bbb1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f6909dd8-fdc1-4eb0-bf88-8537c1147708"), 6, "Room with 6 Beds", new Guid("ea9ac35f-a583-4310-9771-14dff612b128"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("f93b0447-6661-4116-a908-e06dc22a857b"), 6, "Room with 6 Beds", new Guid("fa5bc56d-8c64-4dc7-9b37-549eb9d3bbb1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("f96264b9-017e-4ba0-a1ee-bf740061155a"), 3, "Room with 3 Beds", new Guid("962b30b7-2d60-4e64-a38a-562dbace4209"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f9777e32-0c3e-4d68-beca-6ab0598af00e"), 4, "Room with 4 Beds", new Guid("3bb630ef-7bde-49dc-88db-ba0b5a2e0979"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fa019682-f6e7-4dc3-a3ef-59eb6d1ed147"), 3, "Room with 3 Beds", new Guid("d7f9b43b-b22f-4cf2-816e-88adacf8a858"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("fa72c813-8b8d-4c91-a845-cfc1b04dfab2"), 3, "Room with 3 Beds", new Guid("781bc5e6-a017-4304-9eef-23a082f2b031"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("fb8985a8-f7be-4756-84a6-ed5bc04824e4"), 6, "Room with 6 Beds", new Guid("cac9646d-54ca-49aa-8e3f-a10314bd622f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("fdcd5413-ba7b-4e80-8d1e-14498e6645a6"), 4, "Room with 4 Beds", new Guid("61c14b92-054e-4a91-888e-c37c838300f2"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fe7b575f-7ecf-41da-8e69-7110c21fa990"), 6, "Room with 6 Beds", new Guid("953d189f-e825-4fb6-b785-14577db086c6"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("feac6808-b78d-4631-87a7-12102e06bad2"), 3, "Room with 3 Beds", new Guid("77a568d0-9b89-4fe9-b0f5-283438251a46"), "Room 3 Beds", 1150000f, "3 Beds", "Available" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "FPTDMS",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "FPTDMS",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "FPTDMS",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "FPTDMS",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "FPTDMS",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "FPTDMS",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "FPTDMS",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UserId",
                schema: "FPTDMS",
                table: "Balances",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                schema: "FPTDMS",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                schema: "FPTDMS",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_BookingId_ServiceId",
                schema: "FPTDMS",
                table: "BookingServices",
                columns: new[] { "BookingId", "ServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_ServiceId",
                schema: "FPTDMS",
                table: "BookingServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_DormId",
                schema: "FPTDMS",
                table: "Floors",
                column: "DormId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_FloorId",
                schema: "FPTDMS",
                table: "Houses",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "FPTDMS",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "FPTDMS",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HouseId",
                schema: "FPTDMS",
                table: "Rooms",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppUserId",
                schema: "FPTDMS",
                table: "Services",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RoomId",
                schema: "FPTDMS",
                table: "Services",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Balances",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "BookingServices",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Bookings",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Houses",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Floors",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Dorms",
                schema: "FPTDMS");
        }
    }
}
