using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TSTB.DAL.Migrations
{
    public partial class MembershipRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ImageBig = table.Column<string>(nullable: false),
                    ImageSmall = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
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
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    DateBirthday = table.Column<DateTime>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    EntreprenuerType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BannerPosition = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    code = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    rate_usd = table.Column<double>(nullable: false),
                    multiplier = table.Column<int>(nullable: false),
                    rate_tmt = table.Column<double>(nullable: false),
                    checksum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    SendedToEntrepreneur = table.Column<bool>(nullable: false),
                    SendedToOrganization = table.Column<bool>(nullable: false),
                    SendedToSubscribers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false),
                    Logo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Culture = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    FlagImage = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Culture);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Patent_Ustaw = table.Column<string>(nullable: false),
                    RegistrUdost_EGRPO = table.Column<string>(nullable: false),
                    Passport = table.Column<string>(nullable: false),
                    CommandOrder = table.Column<string>(nullable: true),
                    IncomeReport = table.Column<string>(nullable: true),
                    Declaration_Certificate = table.Column<string>(nullable: false),
                    EnqueryFrom = table.Column<string>(nullable: false),
                    PrivateForm = table.Column<string>(nullable: false),
                    SchoolCertificate = table.Column<string>(nullable: false),
                    MembershipType = table.Column<int>(nullable: false),
                    MembershipRequestStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Link = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NativeProductions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NativeProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsPaper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPaper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CompleteDate = table.Column<DateTime>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(nullable: true),
                    Person = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sayings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false),
                    Logo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    EntreprenuerType = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    EntryAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingHouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Person = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ip = table.Column<string>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logo = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyCode = table.Column<int>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    PageView = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    BankOrderId = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    StatusPayment = table.Column<int>(nullable: true),
                    DatePayment = table.Column<DateTime>(nullable: true),
                    PaymentCreatedDate = table.Column<DateTime>(nullable: false),
                    DeclarationId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BannerTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    BannerId = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerTranslates_Banners_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCharity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharityId = table.Column<int>(nullable: false),
                    ApplicationtUserId = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<int>(nullable: false),
                    BankPaymentId = table.Column<string>(nullable: true),
                    PaymentNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCharity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentCharity_AspNetUsers_ApplicationtUserId",
                        column: x => x.ApplicationtUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentCharity_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallBacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Facks = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    StartWeekDate = table.Column<int>(nullable: false),
                    EndWeekDate = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallBacks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitiesTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitiesTranslates_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxCode = table.Column<string>(nullable: false),
                    NameOrganization = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: false),
                    AddressOrganization = table.Column<string>(nullable: false),
                    PhoneOrganization = table.Column<string>(nullable: false),
                    MembershipDate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: false),
                    PassportSN = table.Column<string>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    PlaceRegistration = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsTranslates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustryTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IndustryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustryTranslates_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuTranslates_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPublish = table.Column<bool>(nullable: false),
                    MenuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NativeProductionTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    NativeProductionId = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NativeProductionTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NativeProductionTranslates_NativeProductions_NativeProducti~",
                        column: x => x.NativeProductionId,
                        principalTable: "NativeProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsCategoryID = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    DatePublished = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_NewsCategoryID",
                        column: x => x.NewsCategoryID,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategoryTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategoryTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCategoryTranslates_NewsCategories_NewsCategoryId",
                        column: x => x.NewsCategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPaperData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsPaperId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    DataOfPublish = table.Column<DateTime>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPaperData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPaperData_NewsPaper_NewsPaperId",
                        column: x => x.NewsPaperId,
                        principalTable: "NewsPaper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsPapersTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsPaperId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPapersTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPapersTranslates_NewsPaper_NewsPaperId",
                        column: x => x.NewsPaperId,
                        principalTable: "NewsPaper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradingActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OnlineTradingCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradingActivityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineTradingActivityTypes_OnlineTradingCategories_OnlineTr~",
                        column: x => x.OnlineTradingCategoryId,
                        principalTable: "OnlineTradingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradingCategoryTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    OnlineTradingCategoryId = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradingCategoryTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineTradingCategoryTranslates_OnlineTradingCategories_Onl~",
                        column: x => x.OnlineTradingCategoryId,
                        principalTable: "OnlineTradingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnersDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnerId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnersDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnersDatas_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerTranslates_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTranslates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativesTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepresentativeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativesTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentativesTranslates_Representatives_RepresentativeId",
                        column: x => x.RepresentativeId,
                        principalTable: "Representatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SayingsTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SayingsId = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    AuthorPosition = table.Column<string>(nullable: false),
                    SayingsText = table.Column<string>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SayingsTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SayingsTranslates_Sayings_SayingsId",
                        column: x => x.SayingsId,
                        principalTable: "Sayings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTranslates_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradingHousesTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TradingHouseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingHousesTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingHousesTranslates_TradingHouses_TradingHouseId",
                        column: x => x.TradingHouseId,
                        principalTable: "TradingHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WidgetTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Footer = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    WidgetID = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetTranslates_Widgets_WidgetID",
                        column: x => x.WidgetID,
                        principalTable: "Widgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreateDeclaration = table.Column<DateTime>(nullable: false),
                    StatusDeclaration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    YearDeclaration = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    PaymentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declarations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Declarations_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagesTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PagesId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagesTranslates_Pages_PagesId",
                        column: x => x.PagesId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsTranslates_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPaperFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsPaperDataId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPaperFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPaperFiles_NewsPaperData_NewsPaperDataId",
                        column: x => x.NewsPaperDataId,
                        principalTable: "NewsPaperData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradingActivityTypeTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    OnlineTradingActivityTypeId = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradingActivityTypeTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineTradingActivityTypeTranslates_OnlineTradingActivityTy~",
                        column: x => x.OnlineTradingActivityTypeId,
                        principalTable: "OnlineTradingActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    OnlineTradingActivityTypeId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsPublish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineTradings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineTradings_OnlineTradingActivityTypes_OnlineTradingActi~",
                        column: x => x.OnlineTradingActivityTypeId,
                        principalTable: "OnlineTradingActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartnersDataTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnersDataId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnersDataTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnersDataTranslates_PartnersDatas_PartnersDataId",
                        column: x => x.PartnersDataId,
                        principalTable: "PartnersDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypeTranslates_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    DeclarationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationImages_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalTable: "Declarations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineTradingTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    OnlineTradingId = table.Column<int>(nullable: false),
                    LanguageCulture = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineTradingTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineTradingTranslates_OnlineTradings_OnlineTradingId",
                        column: x => x.OnlineTradingId,
                        principalTable: "OnlineTradings",
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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerTranslates_BannerId",
                table: "BannerTranslates",
                column: "BannerId");

            migrationBuilder.CreateIndex(
                name: "IX_CallBacks_CityId",
                table: "CallBacks",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesTranslates_CityId",
                table: "CitiesTranslates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationImages_DeclarationId",
                table: "DeclarationImages",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_ApplicationUserId",
                table: "Declarations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_PaymentId",
                table: "Declarations",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsTranslates_DepartmentId",
                table: "DepartmentsTranslates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryTranslates_IndustryId",
                table: "IndustryTranslates",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuTranslates_MenuId",
                table: "MenuTranslates",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_NativeProductionTranslates_NativeProductionId",
                table: "NativeProductionTranslates",
                column: "NativeProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryID",
                table: "News",
                column: "NewsCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryTranslates_NewsCategoryId",
                table: "NewsCategoryTranslates",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPaperData_NewsPaperId",
                table: "NewsPaperData",
                column: "NewsPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPaperFiles_NewsPaperDataId",
                table: "NewsPaperFiles",
                column: "NewsPaperDataId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPapersTranslates_NewsPaperId",
                table: "NewsPapersTranslates",
                column: "NewsPaperId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTranslates_NewsId",
                table: "NewsTranslates",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradingActivityTypes_OnlineTradingCategoryId",
                table: "OnlineTradingActivityTypes",
                column: "OnlineTradingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradingActivityTypeTranslates_OnlineTradingActivityTy~",
                table: "OnlineTradingActivityTypeTranslates",
                column: "OnlineTradingActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradingCategoryTranslates_OnlineTradingCategoryId",
                table: "OnlineTradingCategoryTranslates",
                column: "OnlineTradingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradings_CityId",
                table: "OnlineTradings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradings_OnlineTradingActivityTypeId",
                table: "OnlineTradings",
                column: "OnlineTradingActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineTradingTranslates_OnlineTradingId",
                table: "OnlineTradingTranslates",
                column: "OnlineTradingId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ApplicationUserId",
                table: "Organizations",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CityId",
                table: "Organizations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_MenuId",
                table: "Pages",
                column: "MenuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagesTranslates_PagesId",
                table: "PagesTranslates",
                column: "PagesId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnersDatas_PartnerId",
                table: "PartnersDatas",
                column: "PartnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartnersDataTranslates_PartnersDataId",
                table: "PartnersDataTranslates",
                column: "PartnersDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerTranslates_PartnerId",
                table: "PartnerTranslates",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCharity_ApplicationtUserId",
                table: "PaymentCharity",
                column: "ApplicationtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCharity_CharityId",
                table: "PaymentCharity",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ApplicationUserId",
                table: "Payments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTranslates_ProjectId",
                table: "ProjectTranslates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativesTranslates_RepresentativeId",
                table: "RepresentativesTranslates",
                column: "RepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_SayingsTranslates_SayingsId",
                table: "SayingsTranslates",
                column: "SayingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTranslates_ServiceId",
                table: "ServiceTranslates",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ServiceId",
                table: "ServiceTypes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeTranslates_ServiceTypeId",
                table: "ServiceTypeTranslates",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingHousesTranslates_TradingHouseId",
                table: "TradingHousesTranslates",
                column: "TradingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTranslates_WidgetID",
                table: "WidgetTranslates",
                column: "WidgetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

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
                name: "BannerTranslates");

            migrationBuilder.DropTable(
                name: "CallBacks");

            migrationBuilder.DropTable(
                name: "CitiesTranslates");

            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "DeclarationImages");

            migrationBuilder.DropTable(
                name: "DepartmentsTranslates");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "IndustryTranslates");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MembershipRequests");

            migrationBuilder.DropTable(
                name: "MenuTranslates");

            migrationBuilder.DropTable(
                name: "NativeProductionTranslates");

            migrationBuilder.DropTable(
                name: "NewsCategoryTranslates");

            migrationBuilder.DropTable(
                name: "NewsPaperFiles");

            migrationBuilder.DropTable(
                name: "NewsPapersTranslates");

            migrationBuilder.DropTable(
                name: "NewsTranslates");

            migrationBuilder.DropTable(
                name: "OnlineTradingActivityTypeTranslates");

            migrationBuilder.DropTable(
                name: "OnlineTradingCategoryTranslates");

            migrationBuilder.DropTable(
                name: "OnlineTradingTranslates");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PagesTranslates");

            migrationBuilder.DropTable(
                name: "PartnersDataTranslates");

            migrationBuilder.DropTable(
                name: "PartnerTranslates");

            migrationBuilder.DropTable(
                name: "PaymentCharity");

            migrationBuilder.DropTable(
                name: "ProjectTranslates");

            migrationBuilder.DropTable(
                name: "RepresentativesTranslates");

            migrationBuilder.DropTable(
                name: "SayingsTranslates");

            migrationBuilder.DropTable(
                name: "ServiceTranslates");

            migrationBuilder.DropTable(
                name: "ServiceTypeTranslates");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "TradingHousesTranslates");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "WidgetTranslates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "NativeProductions");

            migrationBuilder.DropTable(
                name: "NewsPaperData");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OnlineTradings");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PartnersDatas");

            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "Sayings");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "TradingHouses");

            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "NewsPaper");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "OnlineTradingActivityTypes");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OnlineTradingCategories");
        }
    }
}
