using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NationalId = table.Column<string>(type: "NVARCHAR(14)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR(500)", nullable: false, defaultValue: "empty"),
                    Address = table.Column<string>(type: "NVARCHAR(500)", nullable: false, defaultValue: "empty"),
                    City = table.Column<string>(type: "NVARCHAR(500)", nullable: false, defaultValue: "empty"),
                    ProfileImg = table.Column<string>(type: "NVARCHAR(500)", nullable: false, defaultValue: "empty"),
                    ModificationBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                name: "CategoryServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Client_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "True"),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefs",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodSafetyCertification = table.Column<string>(type: "NVARCHAR(max)", nullable: false, defaultValue: "empty"),
                    BankDetails = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    WorkingHours = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefs", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_HomeChefs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelOwners",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelOwners", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_HotelOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyOwners",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOwners", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PropertyOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOwners",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOwners", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_RestaurantOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TravelAgencyOwners",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgencyOwners", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TravelAgencyOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartProfisionalAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Licence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Certificate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false),
                    CategoryServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceProviders_CategoryServices_CategoryServicesId",
                        column: x => x.CategoryServicesId,
                        principalTable: "CategoryServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DropoffLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuggestedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PassengersNo = table.Column<int>(type: "int", nullable: false),
                    StartedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingVehicles_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeChefId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DishName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(max)", nullable: true),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    AvailabilityStatus = table.Column<bool>(type: "bit", nullable: false),
                    DietaryTags = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    FoodCategory = table.Column<int>(type: "int", nullable: false),
                    PieceSize = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeChefMeals_HomeChefs_HomeChefId",
                        column: x => x.HomeChefId,
                        principalTable: "HomeChefs",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HomeChefId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeChefOrders_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HomeChefOrders_HomeChefs_HomeChefId",
                        column: x => x.HomeChefId,
                        principalTable: "HomeChefs",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelationOptions = table.Column<bool>(type: "bit", nullable: false),
                    CancelationCharges = table.Column<float>(type: "real", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_HotelOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "HotelOwners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    BuildingNo = table.Column<int>(type: "int", nullable: false),
                    FloorNo = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CancelationOptions = table.Column<bool>(type: "bit", nullable: false),
                    IsForRent = table.Column<bool>(type: "bit", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false),
                    CancelationCharges = table.Column<float>(type: "real", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "PropertyOwners",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", nullable: false, defaultValue: "empty"),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    BuildingNo = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    City = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    Region = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    Street = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(50)", nullable: false, defaultValue: "empty"),
                    CancelationOptions = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CancelationCharges = table.Column<float>(type: "real", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_RestaurantOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "RestaurantOwners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AgencyCustomerInquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    AgencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyCustomerInquiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyCustomerInquiries_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_AgencyCustomerInquiries_TravelAgencyOwners_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "TravelAgencyOwners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TravelAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    BuildingNo = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME2(7)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelAgencies_TravelAgencyOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "TravelAgencyOwners",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderProjects_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorKDay = table.Column<int>(type: "int", nullable: false),
                    AvailableFrom = table.Column<TimeOnly>(type: "time", nullable: false),
                    AvailableTo = table.Column<TimeOnly>(type: "time", nullable: false),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderSchedules_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceQuaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    QuestionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceQuaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceQuaries_CategoryServices_CategoryServicesId",
                        column: x => x.CategoryServicesId,
                        principalTable: "CategoryServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceQuaries_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ServiceQuaries_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CarProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProposalStatus = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SuggestedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarProposals_BookingVehicles_BookingVehicleId",
                        column: x => x.BookingVehicleId,
                        principalTable: "BookingVehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarProposals_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    BookingVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentVehicles_BookingVehicles_BookingVehicleId",
                        column: x => x.BookingVehicleId,
                        principalTable: "BookingVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewVehicles_BookingVehicles_BookingVehicleId",
                        column: x => x.BookingVehicleId,
                        principalTable: "BookingVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPayments_ServiceRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderPropsals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SuggestedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderPropsals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPropsals_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ServiceProviderPropsals_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderReviews_ServiceRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleImages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefMealImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    HomeChefMealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefMealImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeChefMealImages_HomeChefMeals_HomeChefMealsId",
                        column: x => x.HomeChefMealsId,
                        principalTable: "HomeChefMeals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformLogistics = table.Column<string>(type: "NVARCHAR(100)", nullable: false, defaultValue: "empty"),
                    SelfDelivery = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HomeChefOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeChefDeliveries_HomeChefOrders_HomeChefOrderId",
                        column: x => x.HomeChefOrderId,
                        principalTable: "HomeChefOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeChefOrderMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupPrice = table.Column<decimal>(type: "MONEY", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    HomeChefOrdersId = table.Column<int>(type: "int", nullable: false),
                    HomeChefMealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeChefOrderMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeChefOrderMeals_HomeChefMeals_HomeChefMealsId",
                        column: x => x.HomeChefMealsId,
                        principalTable: "HomeChefMeals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeChefOrderMeals_HomeChefOrders_HomeChefOrdersId",
                        column: x => x.HomeChefOrdersId,
                        principalTable: "HomeChefOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentHomeChefOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeApplied = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeChefOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHomeChefOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentHomeChefOrders_HomeChefOrders_HomeChefOrderId",
                        column: x => x.HomeChefOrderId,
                        principalTable: "HomeChefOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewHomeChefOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeChefOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewHomeChefOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewHomeChefOrders_HomeChefOrders_HomeChefOrderId",
                        column: x => x.HomeChefOrderId,
                        principalTable: "HomeChefOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelPolicies_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelPolicies_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelServices_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HotelServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingProperties_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_BookingProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "NVARCHAR(max)", nullable: false, defaultValue: "empty"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantImages_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", nullable: false, defaultValue: "empty"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
                    DietaryTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodCategory = table.Column<int>(type: "int", nullable: false),
                    PieceSize = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantMenuItems_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantOrders_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_RestaurantOrders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    TableNumber = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    ReervationStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantReservations_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_RestaurantReservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsPolicies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    VerificationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyPackages_TravelAgencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercentage = table.Column<float>(type: "real", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyPromotions_TravelAgencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgencyVerificationDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyVerificationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyVerificationDocuments_TravelAgencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypeImages_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeApplied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentProperties_BookingProperties_BookingPropertyId",
                        column: x => x.BookingPropertyId,
                        principalTable: "BookingProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewProperties_BookingProperties_BookingPropertyId",
                        column: x => x.BookingPropertyId,
                        principalTable: "BookingProperties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantMenuItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    RestaurantMenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMenuItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantMenuItemImages_RestaurantMenuItems_RestaurantMenuItemId",
                        column: x => x.RestaurantMenuItemId,
                        principalTable: "RestaurantMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRestaurantOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeApplied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRestaurantOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRestaurantOrders_RestaurantOrders_RestaurantOrderId",
                        column: x => x.RestaurantOrderId,
                        principalTable: "RestaurantOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    RestaurantOrderId = table.Column<int>(type: "int", nullable: false),
                    RestaurantMenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantOrderItems_RestaurantMenuItems_RestaurantMenuItemId",
                        column: x => x.RestaurantMenuItemId,
                        principalTable: "RestaurantMenuItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantOrderItems_RestaurantOrders_RestaurantOrderId",
                        column: x => x.RestaurantOrderId,
                        principalTable: "RestaurantOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewRestaurantOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRestaurantOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewRestaurantOrders_RestaurantOrders_RestaurantOrderId",
                        column: x => x.RestaurantOrderId,
                        principalTable: "RestaurantOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageSchadules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlotsAvailable = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSchadules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageSchadules_AgencyPackages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "AgencyPackages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    AgencyPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageSteps_AgencyPackages_AgencyPackageId",
                        column: x => x.AgencyPackageId,
                        principalTable: "AgencyPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Checkin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingHotelRooms_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_BookingHotelRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservedPeople = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    PackageSchaduleId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageBookings_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PackageBookings_PackageSchadules_PackageSchaduleId",
                        column: x => x.PackageSchaduleId,
                        principalTable: "PackageSchadules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingGuestsInRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIDImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingHotelRoomId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingGuestsInRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingGuestsInRooms_BookingHotelRooms_BookingHotelRoomId",
                        column: x => x.BookingHotelRoomId,
                        principalTable: "BookingHotelRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentHotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeApplied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingHotelRoomId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentHotelRooms_BookingHotelRooms_BookingHotelRoomId",
                        column: x => x.BookingHotelRoomId,
                        principalTable: "BookingHotelRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewHotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingHotelRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewHotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewHotelRooms_BookingHotelRooms_BookingHotelRoomId",
                        column: x => x.BookingHotelRoomId,
                        principalTable: "BookingHotelRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageBookingPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionDeducted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeApplied = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBookingPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageBookingPayments_PackageBookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "PackageBookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PackageBookingReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBookingReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageBookingReviews_PackageBookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "PackageBookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencyCustomerInquiries_AgencyId",
                table: "AgencyCustomerInquiries",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyCustomerInquiries_ClientId",
                table: "AgencyCustomerInquiries",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyPackages_AgencyId",
                table: "AgencyPackages",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyPromotions_AgencyId",
                table: "AgencyPromotions",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyVerificationDocuments_AgencyId",
                table: "AgencyVerificationDocuments",
                column: "AgencyId");

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
                name: "IX_AspNetUsers_NationalId",
                table: "AspNetUsers",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingGuestsInRooms_BookingHotelRoomId",
                table: "BookingGuestsInRooms",
                column: "BookingHotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotelRooms_ClientId",
                table: "BookingHotelRooms",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotelRooms_RoomId",
                table: "BookingHotelRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingProperties_ClientId",
                table: "BookingProperties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingProperties_PropertyId",
                table: "BookingProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingVehicles_ClientId",
                table: "BookingVehicles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProposals_BookingVehicleId",
                table: "CarProposals",
                column: "BookingVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProposals_DriverId",
                table: "CarProposals",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefDeliveries_HomeChefOrderId",
                table: "HomeChefDeliveries",
                column: "HomeChefOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefMealImages_HomeChefMealsId",
                table: "HomeChefMealImages",
                column: "HomeChefMealsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefMeals_HomeChefId",
                table: "HomeChefMeals",
                column: "HomeChefId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefOrderMeals_HomeChefMealsId",
                table: "HomeChefOrderMeals",
                column: "HomeChefMealsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefOrderMeals_HomeChefOrdersId",
                table: "HomeChefOrderMeals",
                column: "HomeChefOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefOrders_ClientId",
                table: "HomeChefOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeChefOrders_HomeChefId",
                table: "HomeChefOrders",
                column: "HomeChefId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPolicies_HotelId",
                table: "HotelPolicies",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelPolicies_PolicyId",
                table: "HotelPolicies",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_OwnerId",
                table: "Hotels",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_HotelId",
                table: "HotelServices",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_ServicesId",
                table: "HotelServices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookingPayments_BookingId",
                table: "PackageBookingPayments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookingReviews_BookingId",
                table: "PackageBookingReviews",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_ClientId",
                table: "PackageBookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_PackageSchaduleId",
                table: "PackageBookings",
                column: "PackageSchaduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSchadules_PackageId",
                table: "PackageSchadules",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageSteps_AgencyPackageId",
                table: "PackageSteps",
                column: "AgencyPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHomeChefOrders_HomeChefOrderId",
                table: "PaymentHomeChefOrders",
                column: "HomeChefOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHotelRooms_BookingHotelRoomId",
                table: "PaymentHotelRooms",
                column: "BookingHotelRoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentProperties_BookingPropertyId",
                table: "PaymentProperties",
                column: "BookingPropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRestaurantOrders_RestaurantOrderId",
                table: "PaymentRestaurantOrders",
                column: "RestaurantOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentVehicles_BookingVehicleId",
                table: "PaymentVehicles",
                column: "BookingVehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImages_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantMenuItemImages_RestaurantMenuItemId",
                table: "RestaurantMenuItemImages",
                column: "RestaurantMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantMenuItems_RestaurantId",
                table: "RestaurantMenuItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderItems_RestaurantMenuItemId",
                table: "RestaurantOrderItems",
                column: "RestaurantMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrderItems_RestaurantOrderId",
                table: "RestaurantOrderItems",
                column: "RestaurantOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_ClientId",
                table: "RestaurantOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantOrders_RestaurantId",
                table: "RestaurantOrders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReservations_ClientId",
                table: "RestaurantReservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReservations_RestaurantId",
                table: "RestaurantReservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHomeChefOrders_HomeChefOrderId",
                table: "ReviewHomeChefOrders",
                column: "HomeChefOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHotelRooms_BookingHotelRoomId",
                table: "ReviewHotelRooms",
                column: "BookingHotelRoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProperties_BookingPropertyId",
                table: "ReviewProperties",
                column: "BookingPropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewRestaurantOrders_RestaurantOrderId",
                table: "ReviewRestaurantOrders",
                column: "RestaurantOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewVehicles_BookingVehicleId",
                table: "ReviewVehicles",
                column: "BookingVehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeImages_RoomTypeId",
                table: "RoomTypeImages",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPayments_RequestId",
                table: "ServiceProviderPayments",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderProjects_ServiceProviderId",
                table: "ServiceProviderProjects",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPropsals_ServiceProviderId",
                table: "ServiceProviderPropsals",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPropsals_ServiceRequestId",
                table: "ServiceProviderPropsals",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderReviews_RequestId",
                table: "ServiceProviderReviews",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_CategoryServicesId",
                table: "ServiceProviders",
                column: "CategoryServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderSchedules_ServiceProviderId",
                table: "ServiceProviderSchedules",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuaries_CategoryServicesId",
                table: "ServiceQuaries",
                column: "CategoryServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuaries_ClientId",
                table: "ServiceQuaries",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuaries_ServiceProviderId",
                table: "ServiceQuaries",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ClientId",
                table: "ServiceRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgencies_OwnerId",
                table: "TravelAgencies",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleId",
                table: "VehicleImages",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyCustomerInquiries");

            migrationBuilder.DropTable(
                name: "AgencyPromotions");

            migrationBuilder.DropTable(
                name: "AgencyVerificationDocuments");

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
                name: "BookingGuestsInRooms");

            migrationBuilder.DropTable(
                name: "CarProposals");

            migrationBuilder.DropTable(
                name: "HomeChefDeliveries");

            migrationBuilder.DropTable(
                name: "HomeChefMealImages");

            migrationBuilder.DropTable(
                name: "HomeChefOrderMeals");

            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "HotelPolicies");

            migrationBuilder.DropTable(
                name: "HotelServices");

            migrationBuilder.DropTable(
                name: "PackageBookingPayments");

            migrationBuilder.DropTable(
                name: "PackageBookingReviews");

            migrationBuilder.DropTable(
                name: "PackageSteps");

            migrationBuilder.DropTable(
                name: "PaymentHomeChefOrders");

            migrationBuilder.DropTable(
                name: "PaymentHotelRooms");

            migrationBuilder.DropTable(
                name: "PaymentProperties");

            migrationBuilder.DropTable(
                name: "PaymentRestaurantOrders");

            migrationBuilder.DropTable(
                name: "PaymentVehicles");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "RestaurantImages");

            migrationBuilder.DropTable(
                name: "RestaurantMenuItemImages");

            migrationBuilder.DropTable(
                name: "RestaurantOrderItems");

            migrationBuilder.DropTable(
                name: "RestaurantReservations");

            migrationBuilder.DropTable(
                name: "ReviewHomeChefOrders");

            migrationBuilder.DropTable(
                name: "ReviewHotelRooms");

            migrationBuilder.DropTable(
                name: "ReviewProperties");

            migrationBuilder.DropTable(
                name: "ReviewRestaurantOrders");

            migrationBuilder.DropTable(
                name: "ReviewVehicles");

            migrationBuilder.DropTable(
                name: "RoomTypeImages");

            migrationBuilder.DropTable(
                name: "ServiceProviderPayments");

            migrationBuilder.DropTable(
                name: "ServiceProviderProjects");

            migrationBuilder.DropTable(
                name: "ServiceProviderPropsals");

            migrationBuilder.DropTable(
                name: "ServiceProviderReviews");

            migrationBuilder.DropTable(
                name: "ServiceProviderSchedules");

            migrationBuilder.DropTable(
                name: "ServiceQuaries");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HomeChefMeals");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "PackageBookings");

            migrationBuilder.DropTable(
                name: "RestaurantMenuItems");

            migrationBuilder.DropTable(
                name: "HomeChefOrders");

            migrationBuilder.DropTable(
                name: "BookingHotelRooms");

            migrationBuilder.DropTable(
                name: "BookingProperties");

            migrationBuilder.DropTable(
                name: "RestaurantOrders");

            migrationBuilder.DropTable(
                name: "BookingVehicles");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "PackageSchadules");

            migrationBuilder.DropTable(
                name: "HomeChefs");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CategoryServices");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AgencyPackages");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "PropertyOwners");

            migrationBuilder.DropTable(
                name: "RestaurantOwners");

            migrationBuilder.DropTable(
                name: "TravelAgencies");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "TravelAgencyOwners");

            migrationBuilder.DropTable(
                name: "HotelOwners");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
