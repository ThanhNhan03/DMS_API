using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DMS_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "FPTDMS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "FPTDMS",
                        principalTable: "Rooms",
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
                    { new Guid("1fb571fb-110d-438a-9ba8-9a2df842af6b"), 0, null, "52b9806f-78c5-4dff-a2da-fcd10f0be918", null, null, "client@fpt.vn", false, "User", "Female", "Normal", false, null, "CLIENT@FPT.VN", "CLIENT", "AQAAAAIAAYagAAAAEDrYx5T/jCmWOe4TSbbeQ9GV0SS/oPCTMifzVeyNMhzlAe3VEnitg7ELESjiBuP1Rg==", null, false, null, null, false, "client" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, null, "5ccad86f-7f8c-4da4-b72b-803e92bbf99b", null, null, "admin@fpt.vn", false, "Admin", "Male", "Admin", false, null, "ADMIN@FPT.VN", "ADMIN", "AQAAAAIAAYagAAAAEOAC1J/HVpJC3Ui7VFPZxxMSktH80m/IoiTQ+/uuLadTBNO6g7Ua+hjgkV3kpgR9kA==", null, false, null, null, false, "admin" }
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
                    { new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "Description for Floor 1 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 1" },
                    { new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "Description for Floor 3 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 3" },
                    { new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "Description for Floor 1 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 1" },
                    { new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "Description for Floor 2 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 2" },
                    { new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "Description for Floor 3 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 3" },
                    { new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "Description for Floor 2 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 2" },
                    { new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "Description for Floor 4 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 4" },
                    { new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "Description for Floor 4 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 4" },
                    { new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "Description for Floor 5 in Dorm A", new Guid("beb78b77-f52c-4193-a53a-3b3aa7a14fd9"), "Floor 5" },
                    { new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "Description for Floor 5 in Dorm B", new Guid("d636bf9d-5979-4b6b-8803-3709d18de12c"), "Floor 5" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Houses",
                columns: new[] { "Id", "Capacity", "Description", "FloorId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("0555fb07-9582-40e3-b3a9-291fc17b4eeb"), 3, "Description for House 6 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 46", "Available" },
                    { new Guid("198710b6-41a9-438a-8a28-fbc38c67bf47"), 3, "Description for House 2 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 52", "Available" },
                    { new Guid("1d5324f0-2238-4a6a-9019-cb69b69ba843"), 3, "Description for House 3 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 13", "Available" },
                    { new Guid("27de2652-a981-4ec7-8db2-15fe84536f64"), 3, "Description for House 1 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 11", "Available" },
                    { new Guid("2b03f1a9-5c4d-423f-8433-d031496b6458"), 3, "Description for House 4 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 34", "Available" },
                    { new Guid("3c3f3714-c264-476c-a712-d405fc7c4a11"), 3, "Description for House 4 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 54", "Available" },
                    { new Guid("430a7090-d6c8-4570-a33b-45896ac53da4"), 3, "Description for House 1 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 21", "Available" },
                    { new Guid("453a7157-0d7d-4ceb-ae52-76c5bc8a3bac"), 3, "Description for House 2 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 12", "Available" },
                    { new Guid("4c91a5be-51a6-486b-bb3e-d1f79015424c"), 3, "Description for House 5 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 25", "Available" },
                    { new Guid("53239092-e034-4859-b281-c2f23115021a"), 3, "Description for House 1 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 31", "Available" },
                    { new Guid("56c305c4-59dc-430b-ac0d-c2d7c6b45b23"), 3, "Description for House 4 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 24", "Available" },
                    { new Guid("591a81d6-9627-4b09-880b-335bd2501ecb"), 3, "Description for House 6 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 56", "Available" },
                    { new Guid("59dca600-c3d9-4b8f-87d9-9cafbae497a6"), 3, "Description for House 6 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 56", "Available" },
                    { new Guid("5a5f3626-be55-49de-8f90-e9ec23f7a467"), 3, "Description for House 4 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 44", "Available" },
                    { new Guid("5b5be5fc-c621-4a20-ad5d-74b27cb9035e"), 3, "Description for House 3 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 23", "Available" },
                    { new Guid("5b9a20fe-e525-4663-a067-244809490dc8"), 3, "Description for House 5 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 15", "Available" },
                    { new Guid("5d7d4cdb-6f35-4e8b-ad05-3738b9befcfc"), 3, "Description for House 2 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 22", "Available" },
                    { new Guid("638bccca-4ab7-42fb-bcc6-bb10631cb331"), 3, "Description for House 4 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 14", "Available" },
                    { new Guid("665a783c-2ea3-457d-960d-0312eafade7f"), 3, "Description for House 6 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 16", "Available" },
                    { new Guid("6ebf0a17-1628-45a2-b3ab-0a7edef67374"), 3, "Description for House 6 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 16", "Available" },
                    { new Guid("7509785d-5ca1-4024-9ffe-e40a19afca86"), 3, "Description for House 2 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 22", "Available" },
                    { new Guid("7ad06c7e-2714-4fbb-ba9d-b82ec03b5433"), 3, "Description for House 3 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 33", "Available" },
                    { new Guid("7b2eabc8-55b6-4916-b690-d4c6ec47b581"), 3, "Description for House 3 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 33", "Available" },
                    { new Guid("7d5daff3-1fcf-44b8-9e49-62474b3883c1"), 3, "Description for House 4 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 24", "Available" },
                    { new Guid("804837eb-42a0-4ef7-91bb-cbbc96e5a51a"), 3, "Description for House 4 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 14", "Available" },
                    { new Guid("810c1d32-9f22-442b-bcc7-632fc55162d4"), 3, "Description for House 5 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 35", "Available" },
                    { new Guid("825b2b75-48ce-4b2e-b34d-7f19e18843a5"), 3, "Description for House 2 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 42", "Available" },
                    { new Guid("8273b5a4-1dd7-4d55-a0b3-302bd86945f4"), 3, "Description for House 1 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 51", "Available" },
                    { new Guid("82c443e5-4865-459b-a432-ecfbb52ebaa6"), 3, "Description for House 6 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 46", "Available" },
                    { new Guid("832a62a4-cfac-49e7-a90f-b13452162786"), 3, "Description for House 6 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 36", "Available" },
                    { new Guid("87f52851-1fd2-4dff-a8c4-fa2b7295ea34"), 3, "Description for House 6 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 26", "Available" },
                    { new Guid("89508c3c-34bc-4064-8be0-ffc35a6d1eab"), 3, "Description for House 1 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 41", "Available" },
                    { new Guid("9da85308-1db0-4eaa-b9a3-c573beaaa7b0"), 3, "Description for House 5 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 15", "Available" },
                    { new Guid("9f7ec0b7-7248-4251-ad80-70f888b778f3"), 3, "Description for House 1 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 31", "Available" },
                    { new Guid("a0bd9bad-1cf2-4607-8f87-c81f0ae373d6"), 3, "Description for House 2 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 52", "Available" },
                    { new Guid("a15653cb-0178-4216-acdd-da301b7b5aed"), 3, "Description for House 5 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 45", "Available" },
                    { new Guid("a9bb3ea8-16b0-47b3-869b-02933edc6d98"), 3, "Description for House 5 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 55", "Available" },
                    { new Guid("a9f7b178-36b5-488d-9b18-ddf29d5fa0e5"), 3, "Description for House 2 in Floor 3", new Guid("7ff27ccf-7cd7-4fb4-b003-d576fb237e3e"), "P.Floor 32", "Available" },
                    { new Guid("b52f85d1-3c43-45f3-82ae-2860945c0ded"), 3, "Description for House 1 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 21", "Available" },
                    { new Guid("b6cdca7d-85a6-49c8-924e-c980d03fa891"), 3, "Description for House 5 in Floor 2", new Guid("be959aa7-c76d-4223-ac46-d887072e1fc8"), "P.Floor 25", "Available" },
                    { new Guid("b7d115fa-c3fb-4571-9b2a-a592d2e328eb"), 3, "Description for House 3 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 53", "Available" },
                    { new Guid("bab7b547-5d3f-47bd-bffe-d6baa88c3b4e"), 3, "Description for House 4 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 54", "Available" },
                    { new Guid("bf136e14-9c32-4a4d-b333-3916256e0283"), 3, "Description for House 4 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 34", "Available" },
                    { new Guid("c0be9f90-7a3e-4cb1-a4e7-b1dfb0fc8875"), 3, "Description for House 5 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 35", "Available" },
                    { new Guid("c94fa4d3-9ee9-43db-8a98-c7d8f177b064"), 3, "Description for House 1 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 51", "Available" },
                    { new Guid("cb0ee05a-edca-4d8b-810b-4875875c4bb1"), 3, "Description for House 5 in Floor 5", new Guid("e950c18f-7914-4c93-86e2-4a9f88787f01"), "P.Floor 55", "Available" },
                    { new Guid("cee9b7b3-f5a0-4b56-bb10-19328428d6ca"), 3, "Description for House 3 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 43", "Available" },
                    { new Guid("d0ac63a0-6b35-4960-b992-1de522206145"), 3, "Description for House 5 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 45", "Available" },
                    { new Guid("d1692130-9008-4d10-b072-610fd36e1770"), 3, "Description for House 6 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 26", "Available" },
                    { new Guid("d524fb95-af10-45be-8906-fd5c76ccaf58"), 3, "Description for House 3 in Floor 5", new Guid("ea6e9209-c08c-42a5-84d5-3b0a0cf2d124"), "P.Floor 53", "Available" },
                    { new Guid("d694d957-4106-4c5d-b8f9-9dcc1eb0d763"), 3, "Description for House 3 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 13", "Available" },
                    { new Guid("d6c61789-b67c-4338-94ed-afd92c44242d"), 3, "Description for House 4 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 44", "Available" },
                    { new Guid("db3fd4c8-b915-43fd-a42a-63192e1b5749"), 3, "Description for House 3 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 43", "Available" },
                    { new Guid("e46da01e-fb6b-4ea0-8cc5-089491ea194e"), 3, "Description for House 2 in Floor 4", new Guid("ddefe8ba-724c-411d-963d-5748ae0763c2"), "P.Floor 42", "Available" },
                    { new Guid("e5190eb8-9655-45aa-a105-0e46864f12fd"), 3, "Description for House 1 in Floor 4", new Guid("c79d1cbd-4fbe-4aae-af00-1b03775baad5"), "P.Floor 41", "Available" },
                    { new Guid("e7731592-a506-4c41-901b-ba058a4b7c16"), 3, "Description for House 1 in Floor 1", new Guid("139ef141-e1e2-4858-b31f-b0eb95ebd942"), "P.Floor 11", "Available" },
                    { new Guid("e95c8496-09c4-4728-ac15-576ca4c8f1f4"), 3, "Description for House 6 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 36", "Available" },
                    { new Guid("efde5fc1-2dfb-408a-8536-9ca16b75fa69"), 3, "Description for House 2 in Floor 1", new Guid("2f462626-1dd2-4b97-b9e9-39ca79081a41"), "P.Floor 12", "Available" },
                    { new Guid("fa360a7d-4d09-46f0-8def-fd224284c26f"), 3, "Description for House 2 in Floor 3", new Guid("24d3c588-d25c-490f-b71a-b4a2c15b1c12"), "P.Floor 32", "Available" },
                    { new Guid("fbbfb16c-47de-48f4-9c1b-c8a2ed0d65c5"), 3, "Description for House 3 in Floor 2", new Guid("6c01a911-cef6-4f73-b3b3-6b5837202937"), "P.Floor 23", "Available" }
                });

            migrationBuilder.InsertData(
                schema: "FPTDMS",
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HouseId", "Name", "Price", "RoomType", "Status" },
                values: new object[,]
                {
                    { new Guid("01bc853c-765c-4d52-a27f-cd39e3ca84d1"), 3, "Room with 3 Beds", new Guid("810c1d32-9f22-442b-bcc7-632fc55162d4"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("02ef71c3-b16b-4630-9982-c7aa83089ff5"), 3, "Room with 3 Beds", new Guid("1d5324f0-2238-4a6a-9019-cb69b69ba843"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("0351d807-0380-4e1a-9213-51844a752811"), 4, "Room with 4 Beds", new Guid("453a7157-0d7d-4ceb-ae52-76c5bc8a3bac"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("038c82d6-3fa4-4723-82e1-def3b18a6df8"), 3, "Room with 3 Beds", new Guid("430a7090-d6c8-4570-a33b-45896ac53da4"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("03f3aa61-30a6-4524-a988-fab67df486aa"), 3, "Room with 3 Beds", new Guid("9f7ec0b7-7248-4251-ad80-70f888b778f3"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("04bc8566-7f5d-4bb3-8545-cd2d1707b227"), 3, "Room with 3 Beds", new Guid("c94fa4d3-9ee9-43db-8a98-c7d8f177b064"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("061de43e-830d-4bc2-9549-52ede5ac87c7"), 4, "Room with 4 Beds", new Guid("87f52851-1fd2-4dff-a8c4-fa2b7295ea34"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("06233dfa-50fd-4e46-8eb5-020b076602c6"), 4, "Room with 4 Beds", new Guid("e5190eb8-9655-45aa-a105-0e46864f12fd"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0b65b57a-def7-46d6-af35-e98805d263ca"), 4, "Room with 4 Beds", new Guid("53239092-e034-4859-b281-c2f23115021a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0b679f10-e859-4bbd-a068-a70db35abada"), 6, "Room with 6 Beds", new Guid("e46da01e-fb6b-4ea0-8cc5-089491ea194e"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0d8367e7-9ab3-4137-b3bf-a78cdbe8bccf"), 6, "Room with 6 Beds", new Guid("9f7ec0b7-7248-4251-ad80-70f888b778f3"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0d951b87-aa32-45c3-9830-15cfdacd8076"), 4, "Room with 4 Beds", new Guid("b6cdca7d-85a6-49c8-924e-c980d03fa891"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0e63f235-527d-429f-bdec-d9fe9ef6f71c"), 4, "Room with 4 Beds", new Guid("5b9a20fe-e525-4663-a067-244809490dc8"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("0f0a0a74-4f55-401c-9a2e-b68d4b21a067"), 6, "Room with 6 Beds", new Guid("bf136e14-9c32-4a4d-b333-3916256e0283"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("0f346684-3991-489e-8f82-734429577e56"), 6, "Room with 6 Beds", new Guid("5d7d4cdb-6f35-4e8b-ad05-3738b9befcfc"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("108a0c35-d6f0-4479-bec3-813defbfa37b"), 3, "Room with 3 Beds", new Guid("5b5be5fc-c621-4a20-ad5d-74b27cb9035e"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("126cb2e6-2516-4661-8e66-40cd68c58ef1"), 6, "Room with 6 Beds", new Guid("efde5fc1-2dfb-408a-8536-9ca16b75fa69"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("12ae9fd1-7892-49f1-a563-8f17e244c03d"), 6, "Room with 6 Beds", new Guid("c0be9f90-7a3e-4cb1-a4e7-b1dfb0fc8875"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("156f9f9c-5a12-4085-82ea-950b7ce2029d"), 6, "Room with 6 Beds", new Guid("453a7157-0d7d-4ceb-ae52-76c5bc8a3bac"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("157dd21d-4e24-4d3b-9b76-c0a62f832706"), 6, "Room with 6 Beds", new Guid("e7731592-a506-4c41-901b-ba058a4b7c16"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("1764526b-9ac5-44d0-b23a-7270c262689f"), 3, "Room with 3 Beds", new Guid("198710b6-41a9-438a-8a28-fbc38c67bf47"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("177ee888-6da2-4b9b-b081-1e03fd7ceb20"), 3, "Room with 3 Beds", new Guid("453a7157-0d7d-4ceb-ae52-76c5bc8a3bac"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("18a561cf-5213-4d16-9529-a1cc9b798217"), 4, "Room with 4 Beds", new Guid("bab7b547-5d3f-47bd-bffe-d6baa88c3b4e"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("1d1a7c4a-bd3c-4385-815a-3db1dfe147ad"), 4, "Room with 4 Beds", new Guid("2b03f1a9-5c4d-423f-8433-d031496b6458"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("1d40d4a2-2272-469c-b570-2de8d68e0982"), 3, "Room with 3 Beds", new Guid("a15653cb-0178-4216-acdd-da301b7b5aed"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("2125d137-6f09-4c6e-9b40-eefc19f681cf"), 6, "Room with 6 Beds", new Guid("5b5be5fc-c621-4a20-ad5d-74b27cb9035e"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("21593de9-5f97-4149-83f0-bda18dfc12b0"), 6, "Room with 6 Beds", new Guid("a9f7b178-36b5-488d-9b18-ddf29d5fa0e5"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("222c1b83-2444-4400-8883-79d5653d80d8"), 6, "Room with 6 Beds", new Guid("bab7b547-5d3f-47bd-bffe-d6baa88c3b4e"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2644cc6b-5d4a-4870-88bf-66d4eb9924d8"), 6, "Room with 6 Beds", new Guid("fbbfb16c-47de-48f4-9c1b-c8a2ed0d65c5"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("266f14aa-c1df-419f-a8f6-32663509a50d"), 4, "Room with 4 Beds", new Guid("a0bd9bad-1cf2-4607-8f87-c81f0ae373d6"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("28c09b5d-806b-48c3-a1c1-bc5f7f6def4e"), 3, "Room with 3 Beds", new Guid("a0bd9bad-1cf2-4607-8f87-c81f0ae373d6"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("29859081-3ab5-4910-aab9-38e1563c73a6"), 6, "Room with 6 Beds", new Guid("5a5f3626-be55-49de-8f90-e9ec23f7a467"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2c55dab9-c5cb-4067-b57f-3188aaf75062"), 6, "Room with 6 Beds", new Guid("832a62a4-cfac-49e7-a90f-b13452162786"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("2fc35a3e-4e16-4886-873c-28dc45b4b166"), 4, "Room with 4 Beds", new Guid("7d5daff3-1fcf-44b8-9e49-62474b3883c1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("309a7e2a-14f2-4fbe-be6b-38b828c6e60f"), 4, "Room with 4 Beds", new Guid("b7d115fa-c3fb-4571-9b2a-a592d2e328eb"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("314c2362-9cba-4128-913d-416bd965cdb3"), 4, "Room with 4 Beds", new Guid("d0ac63a0-6b35-4960-b992-1de522206145"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("32106b5d-6910-418d-a363-ceeb32a4f856"), 6, "Room with 6 Beds", new Guid("b52f85d1-3c43-45f3-82ae-2860945c0ded"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("32536473-8eef-4d4f-9184-4a9635991d1a"), 4, "Room with 4 Beds", new Guid("7ad06c7e-2714-4fbb-ba9d-b82ec03b5433"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("332e0d40-fb42-4368-8909-07e949c7f6ed"), 4, "Room with 4 Beds", new Guid("a9bb3ea8-16b0-47b3-869b-02933edc6d98"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("3761c29f-e126-4491-9472-ac2461b3a4b9"), 3, "Room with 3 Beds", new Guid("665a783c-2ea3-457d-960d-0312eafade7f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("3a1579fd-dab6-4bdd-86c5-9e0277915d32"), 3, "Room with 3 Beds", new Guid("87f52851-1fd2-4dff-a8c4-fa2b7295ea34"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("41064d83-f7ba-45ff-ae7a-76172245774f"), 3, "Room with 3 Beds", new Guid("b52f85d1-3c43-45f3-82ae-2860945c0ded"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4111145c-ef0f-4b2b-aac3-9a35df4ae2b0"), 4, "Room with 4 Beds", new Guid("89508c3c-34bc-4064-8be0-ffc35a6d1eab"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4368ec29-ab0c-4d17-bf2f-090d0d093624"), 3, "Room with 3 Beds", new Guid("e7731592-a506-4c41-901b-ba058a4b7c16"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("438bd399-3571-4fc9-8f74-d03250b6f5ca"), 3, "Room with 3 Beds", new Guid("9da85308-1db0-4eaa-b9a3-c573beaaa7b0"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("45f44284-d15c-47c2-afdc-9f872b8ca3e6"), 4, "Room with 4 Beds", new Guid("1d5324f0-2238-4a6a-9019-cb69b69ba843"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4639472c-3ccc-47a6-996a-a5b8f7bead03"), 4, "Room with 4 Beds", new Guid("8273b5a4-1dd7-4d55-a0b3-302bd86945f4"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("475bec6a-819d-40a6-8408-ce4906e2d0b8"), 3, "Room with 3 Beds", new Guid("82c443e5-4865-459b-a432-ecfbb52ebaa6"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("486be41a-35ec-4114-947c-0eded36b1101"), 4, "Room with 4 Beds", new Guid("810c1d32-9f22-442b-bcc7-632fc55162d4"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4a6c49bc-0926-4e72-8a60-5f22104829fb"), 4, "Room with 4 Beds", new Guid("e95c8496-09c4-4728-ac15-576ca4c8f1f4"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("4b33b117-5a13-41e9-900a-b17ffc892dbd"), 3, "Room with 3 Beds", new Guid("5d7d4cdb-6f35-4e8b-ad05-3738b9befcfc"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("4b408d1d-9d71-4169-abc1-8d617d2f79bf"), 6, "Room with 6 Beds", new Guid("810c1d32-9f22-442b-bcc7-632fc55162d4"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4b5145c4-ab07-4773-a8e5-aed5a6e24568"), 6, "Room with 6 Beds", new Guid("d524fb95-af10-45be-8906-fd5c76ccaf58"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4dda7584-0257-472a-9ee2-845c211dd0ce"), 6, "Room with 6 Beds", new Guid("e5190eb8-9655-45aa-a105-0e46864f12fd"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("4f70d28d-6e5e-4c48-9271-7aaaa799e0d3"), 3, "Room with 3 Beds", new Guid("7d5daff3-1fcf-44b8-9e49-62474b3883c1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("51d6b43e-00e3-456a-a10a-1c90e816546c"), 3, "Room with 3 Beds", new Guid("d0ac63a0-6b35-4960-b992-1de522206145"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("52917d7c-93bb-4a0e-a1aa-500862cfb9fd"), 4, "Room with 4 Beds", new Guid("198710b6-41a9-438a-8a28-fbc38c67bf47"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("54fde33a-35b1-400a-bf12-a7389c065f0f"), 6, "Room with 6 Beds", new Guid("4c91a5be-51a6-486b-bb3e-d1f79015424c"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("55b304d5-2215-4341-8003-4b121b602d34"), 4, "Room with 4 Beds", new Guid("27de2652-a981-4ec7-8db2-15fe84536f64"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("55f67779-9b7c-4342-939a-b1d9a3752bde"), 4, "Room with 4 Beds", new Guid("d694d957-4106-4c5d-b8f9-9dcc1eb0d763"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("565af63d-cf5a-45bf-a384-3e908ef37e11"), 4, "Room with 4 Beds", new Guid("fa360a7d-4d09-46f0-8def-fd224284c26f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("584208cb-25ec-4c73-b79d-a3938378da5e"), 4, "Room with 4 Beds", new Guid("0555fb07-9582-40e3-b3a9-291fc17b4eeb"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("5a3520ca-e4a0-49c1-b094-fc72cbc8648c"), 6, "Room with 6 Beds", new Guid("6ebf0a17-1628-45a2-b3ab-0a7edef67374"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("5c7fd45e-cba1-4b6b-999f-3313ff0e08c7"), 4, "Room with 4 Beds", new Guid("638bccca-4ab7-42fb-bcc6-bb10631cb331"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("5da54012-9692-40d3-a87e-5ce3fa5c41fa"), 4, "Room with 4 Beds", new Guid("804837eb-42a0-4ef7-91bb-cbbc96e5a51a"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("5e45d6da-fdab-4a5c-87ad-76dd03374de3"), 3, "Room with 3 Beds", new Guid("e5190eb8-9655-45aa-a105-0e46864f12fd"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("5eef59e7-f672-4237-9117-6f6e0011c841"), 6, "Room with 6 Beds", new Guid("638bccca-4ab7-42fb-bcc6-bb10631cb331"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("5ffa1688-cfad-459f-85e3-c809ac6804d9"), 4, "Room with 4 Beds", new Guid("e7731592-a506-4c41-901b-ba058a4b7c16"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("607bb26f-c61f-4c89-9c8b-92c59876bcfb"), 3, "Room with 3 Beds", new Guid("b6cdca7d-85a6-49c8-924e-c980d03fa891"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("61a133c3-ff32-4870-acff-cff55d6ea41e"), 3, "Room with 3 Beds", new Guid("b7d115fa-c3fb-4571-9b2a-a592d2e328eb"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("61ba5f81-f0c7-4077-b498-77b13b186051"), 6, "Room with 6 Beds", new Guid("7b2eabc8-55b6-4916-b690-d4c6ec47b581"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("62ff1626-a043-465b-83e0-b8673a47eaa2"), 6, "Room with 6 Beds", new Guid("825b2b75-48ce-4b2e-b34d-7f19e18843a5"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6621ef7d-cd91-4944-a81c-8aee7f963aef"), 4, "Room with 4 Beds", new Guid("825b2b75-48ce-4b2e-b34d-7f19e18843a5"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("694e86d3-7a94-4848-86e3-7b3bf0a2dd9a"), 4, "Room with 4 Beds", new Guid("9da85308-1db0-4eaa-b9a3-c573beaaa7b0"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("6a21e3ce-55ed-466b-9312-0bb0824cfd66"), 3, "Room with 3 Beds", new Guid("cb0ee05a-edca-4d8b-810b-4875875c4bb1"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("6adcaba4-5f55-417b-9249-c978a750464a"), 6, "Room with 6 Beds", new Guid("a9bb3ea8-16b0-47b3-869b-02933edc6d98"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("6b16a65d-b366-434e-82ca-152d169ec1d2"), 4, "Room with 4 Beds", new Guid("c94fa4d3-9ee9-43db-8a98-c7d8f177b064"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("6d746d02-b190-43db-a3d0-9a1055907433"), 4, "Room with 4 Beds", new Guid("6ebf0a17-1628-45a2-b3ab-0a7edef67374"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("70e6e67f-57c5-4424-942f-6b80f40703e5"), 4, "Room with 4 Beds", new Guid("5d7d4cdb-6f35-4e8b-ad05-3738b9befcfc"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("710c821b-8234-4c3e-a686-d00be56eb9d0"), 6, "Room with 6 Beds", new Guid("7509785d-5ca1-4024-9ffe-e40a19afca86"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7154cc19-babd-46e8-8755-799ef186cd0d"), 6, "Room with 6 Beds", new Guid("cee9b7b3-f5a0-4b56-bb10-19328428d6ca"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("74191740-6158-4df2-8484-8cf5282ac536"), 6, "Room with 6 Beds", new Guid("c94fa4d3-9ee9-43db-8a98-c7d8f177b064"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("779a1cb5-642f-4665-a99c-f4d5edfdb5ff"), 6, "Room with 6 Beds", new Guid("3c3f3714-c264-476c-a712-d405fc7c4a11"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("7e43b8e0-c0fc-4f83-aaca-d771bae37e2e"), 6, "Room with 6 Beds", new Guid("d6c61789-b67c-4338-94ed-afd92c44242d"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("80a2dff4-da11-4dbd-9ecc-413b92b282ba"), 4, "Room with 4 Beds", new Guid("fbbfb16c-47de-48f4-9c1b-c8a2ed0d65c5"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("83ccc579-243f-4053-b67f-07d2140e5873"), 3, "Room with 3 Beds", new Guid("c0be9f90-7a3e-4cb1-a4e7-b1dfb0fc8875"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("854d769c-646e-4d56-bf0d-6642d96b6f1d"), 6, "Room with 6 Beds", new Guid("db3fd4c8-b915-43fd-a42a-63192e1b5749"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("8ac74a5d-af3f-46b5-85a8-995a440d4861"), 3, "Room with 3 Beds", new Guid("db3fd4c8-b915-43fd-a42a-63192e1b5749"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("8b1c8de2-278d-425b-a0c0-77a780f8403e"), 6, "Room with 6 Beds", new Guid("665a783c-2ea3-457d-960d-0312eafade7f"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("8ea51449-0052-44d7-9042-1210c0e41711"), 4, "Room with 4 Beds", new Guid("cee9b7b3-f5a0-4b56-bb10-19328428d6ca"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9181f321-5f23-4339-8d87-c50ba4d4ae45"), 3, "Room with 3 Beds", new Guid("d524fb95-af10-45be-8906-fd5c76ccaf58"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("91cd98d4-d5a8-4612-ad17-c3ca58893832"), 6, "Room with 6 Beds", new Guid("d694d957-4106-4c5d-b8f9-9dcc1eb0d763"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("91dd10b9-bcec-4d49-9034-fd3ab3ce2ca4"), 3, "Room with 3 Beds", new Guid("2b03f1a9-5c4d-423f-8433-d031496b6458"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("9296129e-ed48-488a-a176-436bfac9c532"), 4, "Room with 4 Beds", new Guid("d6c61789-b67c-4338-94ed-afd92c44242d"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("95a055d4-386f-4421-b27f-6c1eac4e71df"), 3, "Room with 3 Beds", new Guid("7b2eabc8-55b6-4916-b690-d4c6ec47b581"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("96293df9-2503-4b91-8ba1-2f84e9161274"), 3, "Room with 3 Beds", new Guid("d1692130-9008-4d10-b072-610fd36e1770"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("96d9a567-52be-467f-8441-abf5b11d84b4"), 3, "Room with 3 Beds", new Guid("4c91a5be-51a6-486b-bb3e-d1f79015424c"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("9b7b6918-3ab9-4925-91e7-5d2e313b68f4"), 6, "Room with 6 Beds", new Guid("a0bd9bad-1cf2-4607-8f87-c81f0ae373d6"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("9cab96a0-9c50-45c5-985e-f7ba58349419"), 6, "Room with 6 Beds", new Guid("198710b6-41a9-438a-8a28-fbc38c67bf47"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("9d124ffe-5ace-40ad-a95a-873536f8961b"), 6, "Room with 6 Beds", new Guid("591a81d6-9627-4b09-880b-335bd2501ecb"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("9e0f21c5-a720-4079-a963-ad0c5289482e"), 4, "Room with 4 Beds", new Guid("665a783c-2ea3-457d-960d-0312eafade7f"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9e22ed78-3e4f-4b55-94af-3023861632cd"), 4, "Room with 4 Beds", new Guid("5b5be5fc-c621-4a20-ad5d-74b27cb9035e"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9e895fd9-2691-42aa-a8be-e9c82870beb6"), 4, "Room with 4 Beds", new Guid("591a81d6-9627-4b09-880b-335bd2501ecb"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9fac778b-6a77-4760-a549-f707caee980d"), 4, "Room with 4 Beds", new Guid("9f7ec0b7-7248-4251-ad80-70f888b778f3"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("9fe2cbd0-2ba7-4139-bad0-310acff0350b"), 6, "Room with 6 Beds", new Guid("53239092-e034-4859-b281-c2f23115021a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a13b982e-d176-45a1-8097-7030316eabd3"), 3, "Room with 3 Beds", new Guid("bf136e14-9c32-4a4d-b333-3916256e0283"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a1aca540-104e-4fc0-a861-242f3a7a0779"), 3, "Room with 3 Beds", new Guid("5b9a20fe-e525-4663-a067-244809490dc8"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a33f89d5-1b8a-40eb-8eee-bd6c444b8960"), 3, "Room with 3 Beds", new Guid("53239092-e034-4859-b281-c2f23115021a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("a3a0255f-d5b7-4fff-86b4-556567685888"), 6, "Room with 6 Beds", new Guid("b7d115fa-c3fb-4571-9b2a-a592d2e328eb"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a4e9c420-19a8-4f08-852c-06bb1461d069"), 4, "Room with 4 Beds", new Guid("e46da01e-fb6b-4ea0-8cc5-089491ea194e"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("a4ec46d2-88d3-4a86-ad24-09707be657dc"), 6, "Room with 6 Beds", new Guid("d1692130-9008-4d10-b072-610fd36e1770"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("a9e3ee3b-a701-4a4e-881c-9af84d4022cc"), 3, "Room with 3 Beds", new Guid("27de2652-a981-4ec7-8db2-15fe84536f64"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ab108ede-f904-4930-be73-dd93db080927"), 3, "Room with 3 Beds", new Guid("7ad06c7e-2714-4fbb-ba9d-b82ec03b5433"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ad1ffea8-632a-4167-8d9b-625b41f4ee38"), 6, "Room with 6 Beds", new Guid("7ad06c7e-2714-4fbb-ba9d-b82ec03b5433"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ad62b382-673f-47dd-8a8c-f70542b0bb18"), 6, "Room with 6 Beds", new Guid("8273b5a4-1dd7-4d55-a0b3-302bd86945f4"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("aed0d30c-9dcd-47a8-81f9-a1b7753c567c"), 4, "Room with 4 Beds", new Guid("a15653cb-0178-4216-acdd-da301b7b5aed"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("aed2f615-4112-4069-8a9b-0f7e678d5926"), 4, "Room with 4 Beds", new Guid("59dca600-c3d9-4b8f-87d9-9cafbae497a6"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("af6aed7b-fcde-452c-a28a-b8d98e7316b4"), 6, "Room with 6 Beds", new Guid("89508c3c-34bc-4064-8be0-ffc35a6d1eab"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b0405d3c-de47-4eba-a4f9-ea4b2ec24006"), 3, "Room with 3 Beds", new Guid("56c305c4-59dc-430b-ac0d-c2d7c6b45b23"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b1cbc880-a5e4-438f-83cf-ba87ce8a0900"), 6, "Room with 6 Beds", new Guid("1d5324f0-2238-4a6a-9019-cb69b69ba843"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b22f5395-75d9-46d8-9f9f-2bff4c09afb6"), 4, "Room with 4 Beds", new Guid("db3fd4c8-b915-43fd-a42a-63192e1b5749"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b2f7f958-6fbd-4d10-89d5-6c2b5e74dfd1"), 6, "Room with 6 Beds", new Guid("82c443e5-4865-459b-a432-ecfbb52ebaa6"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b395d6fa-3c2d-406a-81d0-7438c52f4414"), 6, "Room with 6 Beds", new Guid("87f52851-1fd2-4dff-a8c4-fa2b7295ea34"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("b5524af7-ca5a-451d-9e91-370bc595c0fe"), 3, "Room with 3 Beds", new Guid("bab7b547-5d3f-47bd-bffe-d6baa88c3b4e"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("b885c347-be0a-4a97-ac5c-fb992234c020"), 4, "Room with 4 Beds", new Guid("efde5fc1-2dfb-408a-8536-9ca16b75fa69"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("b8d07807-f794-4f65-b44b-01c1ada1d006"), 6, "Room with 6 Beds", new Guid("e95c8496-09c4-4728-ac15-576ca4c8f1f4"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("bb761a89-6f31-42fc-bea2-66e0fc2257b8"), 3, "Room with 3 Beds", new Guid("638bccca-4ab7-42fb-bcc6-bb10631cb331"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("bb905cc6-50b5-4862-9ffc-53b49396172e"), 4, "Room with 4 Beds", new Guid("d1692130-9008-4d10-b072-610fd36e1770"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("bbb701cd-628e-4071-95da-39f11a0e816c"), 6, "Room with 6 Beds", new Guid("430a7090-d6c8-4570-a33b-45896ac53da4"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("bcc8fbc9-a8ae-4ba8-8eb9-e41515cde1cb"), 3, "Room with 3 Beds", new Guid("cee9b7b3-f5a0-4b56-bb10-19328428d6ca"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("bfbccfab-fd4f-4f4a-a99a-2711038e8a2c"), 3, "Room with 3 Beds", new Guid("e46da01e-fb6b-4ea0-8cc5-089491ea194e"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c159c6a2-5480-48a1-92ff-f52d6fc84023"), 4, "Room with 4 Beds", new Guid("a9f7b178-36b5-488d-9b18-ddf29d5fa0e5"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("c1fc3540-5adf-4427-bd48-23523410c895"), 3, "Room with 3 Beds", new Guid("5a5f3626-be55-49de-8f90-e9ec23f7a467"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("c7a15312-2a8f-45af-b3d9-649fa982ab33"), 6, "Room with 6 Beds", new Guid("d0ac63a0-6b35-4960-b992-1de522206145"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("c91c684d-1226-455d-adf1-e3adc551318f"), 6, "Room with 6 Beds", new Guid("5b9a20fe-e525-4663-a067-244809490dc8"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ca49ff60-5002-48f6-82e5-221bc72089ac"), 6, "Room with 6 Beds", new Guid("b6cdca7d-85a6-49c8-924e-c980d03fa891"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("cb11c285-e7f0-4221-a039-eb01e79fcb5f"), 4, "Room with 4 Beds", new Guid("c0be9f90-7a3e-4cb1-a4e7-b1dfb0fc8875"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("cb6dd464-a311-408b-8196-7529d63374ae"), 4, "Room with 4 Beds", new Guid("cb0ee05a-edca-4d8b-810b-4875875c4bb1"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ccc2451e-b2d8-447b-bc35-d80f016f5bc8"), 3, "Room with 3 Beds", new Guid("591a81d6-9627-4b09-880b-335bd2501ecb"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("cce6d6fd-4f9d-4d67-b9c0-c5e6be740cdf"), 3, "Room with 3 Beds", new Guid("825b2b75-48ce-4b2e-b34d-7f19e18843a5"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("cd003961-fe9c-4cef-a16a-bd675e6dbaf4"), 6, "Room with 6 Beds", new Guid("27de2652-a981-4ec7-8db2-15fe84536f64"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d1ff1bc2-009c-4d59-be93-b9b1670ded66"), 3, "Room with 3 Beds", new Guid("d694d957-4106-4c5d-b8f9-9dcc1eb0d763"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("d5d1da58-1e89-4850-b075-4f11e4470b21"), 6, "Room with 6 Beds", new Guid("804837eb-42a0-4ef7-91bb-cbbc96e5a51a"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d6754f3e-2fef-4fa9-a8b9-8e84dc42d7c0"), 6, "Room with 6 Beds", new Guid("7d5daff3-1fcf-44b8-9e49-62474b3883c1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("d943370b-f2c5-4d59-98da-4e09999fb943"), 6, "Room with 6 Beds", new Guid("56c305c4-59dc-430b-ac0d-c2d7c6b45b23"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("da723e19-4c9e-4426-bbff-0ade21596ea9"), 6, "Room with 6 Beds", new Guid("0555fb07-9582-40e3-b3a9-291fc17b4eeb"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("daa9f6bf-2485-4e7a-aeeb-9a79889be3a0"), 6, "Room with 6 Beds", new Guid("cb0ee05a-edca-4d8b-810b-4875875c4bb1"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("dc001a9d-2869-41e5-b151-3d94064d3058"), 3, "Room with 3 Beds", new Guid("a9bb3ea8-16b0-47b3-869b-02933edc6d98"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("dcf38bef-2332-4731-828e-637141020319"), 3, "Room with 3 Beds", new Guid("fa360a7d-4d09-46f0-8def-fd224284c26f"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("decace02-b5cf-49c8-a693-a92abbaa3295"), 4, "Room with 4 Beds", new Guid("3c3f3714-c264-476c-a712-d405fc7c4a11"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("dfd78a41-e936-4900-bd28-8895fc0409cb"), 4, "Room with 4 Beds", new Guid("4c91a5be-51a6-486b-bb3e-d1f79015424c"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e00079ff-6666-4130-a909-05ff8616a87e"), 3, "Room with 3 Beds", new Guid("832a62a4-cfac-49e7-a90f-b13452162786"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e139b3ed-b05b-4847-8b0d-d49410b556ec"), 3, "Room with 3 Beds", new Guid("6ebf0a17-1628-45a2-b3ab-0a7edef67374"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e14692b3-f43e-48b0-b93c-36d0ff7ef0bc"), 3, "Room with 3 Beds", new Guid("e95c8496-09c4-4728-ac15-576ca4c8f1f4"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e1900c75-b6bd-4f08-a381-0bb110695eda"), 4, "Room with 4 Beds", new Guid("7509785d-5ca1-4024-9ffe-e40a19afca86"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e2a435a4-528b-49dc-aaaf-0d5d1ced168a"), 4, "Room with 4 Beds", new Guid("d524fb95-af10-45be-8906-fd5c76ccaf58"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("e32936c8-2577-43d8-acaa-7ca8e00a81cf"), 6, "Room with 6 Beds", new Guid("59dca600-c3d9-4b8f-87d9-9cafbae497a6"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("e5d06b79-0d42-45f6-8895-eb2301b53f66"), 3, "Room with 3 Beds", new Guid("0555fb07-9582-40e3-b3a9-291fc17b4eeb"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("e7ef1a21-c51f-47c0-ba38-7232058dbdf6"), 3, "Room with 3 Beds", new Guid("89508c3c-34bc-4064-8be0-ffc35a6d1eab"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ebc9a593-0e5f-4598-9a3d-0b7c24747529"), 6, "Room with 6 Beds", new Guid("2b03f1a9-5c4d-423f-8433-d031496b6458"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("ec6bab5b-7761-4065-9792-7c0ebdcd03b6"), 4, "Room with 4 Beds", new Guid("b52f85d1-3c43-45f3-82ae-2860945c0ded"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ecf0be20-0bfb-4179-b01c-5cd4140e290d"), 4, "Room with 4 Beds", new Guid("430a7090-d6c8-4570-a33b-45896ac53da4"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("ed4183d6-4041-486b-9361-404dee52bb38"), 4, "Room with 4 Beds", new Guid("832a62a4-cfac-49e7-a90f-b13452162786"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("eeca4bba-811c-4c7b-9efa-c18d758c92ed"), 3, "Room with 3 Beds", new Guid("59dca600-c3d9-4b8f-87d9-9cafbae497a6"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("efae05de-f893-41b1-b8a4-91fbe4a3d663"), 3, "Room with 3 Beds", new Guid("8273b5a4-1dd7-4d55-a0b3-302bd86945f4"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("efcd87f4-316c-4582-83c8-0762238a2187"), 3, "Room with 3 Beds", new Guid("7509785d-5ca1-4024-9ffe-e40a19afca86"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f226b370-6b3e-407b-8275-f5cf4a3e7319"), 4, "Room with 4 Beds", new Guid("bf136e14-9c32-4a4d-b333-3916256e0283"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f29e67ce-3fbd-449d-8332-40041a4ed8c7"), 3, "Room with 3 Beds", new Guid("fbbfb16c-47de-48f4-9c1b-c8a2ed0d65c5"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f2c23ce6-1253-46dd-bd6b-9270e7ebc4c0"), 3, "Room with 3 Beds", new Guid("efde5fc1-2dfb-408a-8536-9ca16b75fa69"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f345a45b-05b3-4786-8729-89267c7ef0e6"), 4, "Room with 4 Beds", new Guid("7b2eabc8-55b6-4916-b690-d4c6ec47b581"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f3bc052d-ef78-4000-9567-4b5c035ea654"), 3, "Room with 3 Beds", new Guid("804837eb-42a0-4ef7-91bb-cbbc96e5a51a"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f61d527c-1577-49c7-9fa4-c99fdb942244"), 4, "Room with 4 Beds", new Guid("5a5f3626-be55-49de-8f90-e9ec23f7a467"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("f92c006a-149f-43de-b7ea-013a6782a105"), 3, "Room with 3 Beds", new Guid("d6c61789-b67c-4338-94ed-afd92c44242d"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("f9ecf749-bb24-478f-9e83-30dd0394f3c5"), 4, "Room with 4 Beds", new Guid("82c443e5-4865-459b-a432-ecfbb52ebaa6"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fb08d06d-24df-4e6a-a33c-7fd64f65f9b2"), 6, "Room with 6 Beds", new Guid("a15653cb-0178-4216-acdd-da301b7b5aed"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("fc80a4c3-c11f-44bf-8b1f-69857ece059b"), 4, "Room with 4 Beds", new Guid("56c305c4-59dc-430b-ac0d-c2d7c6b45b23"), "Room 4 Beds", 1050000f, "4 Beds", "Available" },
                    { new Guid("fe6c6213-a859-4875-8b27-295d7bfae138"), 6, "Room with 6 Beds", new Guid("9da85308-1db0-4eaa-b9a3-c573beaaa7b0"), "Room 6 Beds", 850000f, "6 Beds", "Available" },
                    { new Guid("feca82fa-54e5-4eb8-ac1b-04828770f0d4"), 3, "Room with 3 Beds", new Guid("3c3f3714-c264-476c-a712-d405fc7c4a11"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ff0e1a96-0b4d-44d3-8f46-c6426de4d1b8"), 3, "Room with 3 Beds", new Guid("a9f7b178-36b5-488d-9b18-ddf29d5fa0e5"), "Room 3 Beds", 1150000f, "3 Beds", "Available" },
                    { new Guid("ff7cfcd1-7cc7-42d9-9b31-1d3915c383da"), 6, "Room with 6 Beds", new Guid("fa360a7d-4d09-46f0-8def-fd224284c26f"), "Room 6 Beds", 850000f, "6 Beds", "Available" }
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
                name: "IX_Services_RoomId",
                schema: "FPTDMS",
                table: "Services",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                schema: "FPTDMS",
                table: "Services",
                column: "UserId");
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
                name: "Bookings",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "FPTDMS");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
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
