using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbCardsToDraw = table.Column<int>(type: "int", nullable: false),
                    NbManaToReceive = table.Column<int>(type: "int", nullable: false),
                    NbMaxDeck = table.Column<int>(type: "int", nullable: false),
                    NbMaxCard = table.Column<int>(type: "int", nullable: false),
                    BeginnerMoney = table.Column<double>(type: "float", nullable: false),
                    WinnerMoney = table.Column<double>(type: "float", nullable: false),
                    LoserMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbCards = table.Column<int>(type: "int", nullable: false),
                    DefaultRarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ELO = table.Column<int>(type: "int", nullable: false),
                    attente = table.Column<int>(type: "int", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    ELO = table.Column<int>(type: "int", nullable: false),
                    NbVictories = table.Column<int>(type: "int", nullable: false),
                    NbDefeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarterCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarterCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarterCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Probabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    BaseQty = table.Column<int>(type: "int", nullable: false),
                    PackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Probabilities_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PairOfPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerInfo1Id = table.Column<int>(type: "int", nullable: false),
                    PlayerInfo2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairOfPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo1Id",
                        column: x => x.PlayerInfo1Id,
                        principalTable: "PlayerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PairOfPlayers_PlayerInfo_PlayerInfo2Id",
                        column: x => x.PlayerInfo2Id,
                        principalTable: "PlayerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CardPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPowers_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    NbVictories = table.Column<int>(type: "int", nullable: false),
                    NbDefeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deck_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    IndexBattleField = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayersData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayersData_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnedCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnedCards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPlayerATurn = table.Column<bool>(type: "bit", nullable: false),
                    IsMatchCompleted = table.Column<bool>(type: "bit", nullable: false),
                    WinnerUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerDataAId = table.Column<int>(type: "int", nullable: false),
                    PlayerDataBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataAId",
                        column: x => x.PlayerDataAId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_MatchPlayersData_PlayerDataBId",
                        column: x => x.PlayerDataBId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayableCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    MatchPlayerDataId = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId1 = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId2 = table.Column<int>(type: "int", nullable: true),
                    MatchPlayerDataId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId",
                        column: x => x.MatchPlayerDataId,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId1",
                        column: x => x.MatchPlayerDataId1,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId2",
                        column: x => x.MatchPlayerDataId2,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayableCards_MatchPlayersData_MatchPlayerDataId3",
                        column: x => x.MatchPlayerDataId3,
                        principalTable: "MatchPlayersData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeckOwnedCard",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "int", nullable: false),
                    OwnedCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOwnedCard", x => new { x.DeckId, x.OwnedCardId });
                    table.ForeignKey(
                        name: "FK_DeckOwnedCard_Deck_OwnedCardId",
                        column: x => x.OwnedCardId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DeckOwnedCard_OwnedCards_DeckId",
                        column: x => x.DeckId,
                        principalTable: "OwnedCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayableCardStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayableCardId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCardStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_PlayableCards_PlayableCardId",
                        column: x => x.PlayableCardId,
                        principalTable: "PlayableCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "2ec47538-1b79-4958-abea-dc2c9e08c86e", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEOxQ7hp+qkaOkJ0+GTPpZYDvI/Y9j4tXRz0Zs86dCmmxuXoGWmsYAlE7WyUc33yE4Q==", null, false, "0275e0bd-046f-4f18-a9ba-c40a2a43f94b", false, "admin@admin.com" },
                    { "User1Id", 0, "fff323ad-8a47-487b-9c5e-a8fa2b669518", null, false, false, null, null, null, null, null, false, "4e2e9ca8-f71f-4d41-b1da-111d375f8885", false, null },
                    { "User2Id", 0, "0776fcfe-af52-4fa1-813c-bf02b4207ce3", null, false, false, null, null, null, null, null, false, "23dbcd18-4f4a-4d30-a14e-9d8efa58255a", false, null }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "Name", "Rarity" },
                values: new object[,]
                {
                    { 1, 3, 3, 3, "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg", "Chat Dragon", 0 },
                    { 2, 2, 3, 5, "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg", "Chat Awesome", 1 },
                    { 3, 2, 1, 1, "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg", "Chatton Laser", 0 },
                    { 4, 8, 4, 4, "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg", "Chat Spacial", 3 },
                    { 5, 7, 5, 7, "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg", "Chat Guerrier", 3 },
                    { 6, 4, 2, 2, "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720", "Chat Laser", 0 },
                    { 7, 6, 4, 3, "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg", "Jedi Chat", 2 },
                    { 8, 1, 2, 9, "https://i.ytimg.com/vi/2I7pZlUhZak/maxresdefault.jpg", "Blob Chat", 2 },
                    { 9, 5, 2, 1, "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75", "Jedi Chatton", 0 },
                    { 10, 6, 2, 1, "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg", "Chat Furtif", 0 },
                    { 11, 0, 1, 10, "https://cdn.openart.ai/uploads/image_FkweA3pP_1695446033995_512.webp", "Chat Jesus", 3 }
                });

            migrationBuilder.InsertData(
                table: "GameConfigs",
                columns: new[] { "Id", "BeginnerMoney", "LoserMoney", "NbCardsToDraw", "NbManaToReceive", "NbMaxCard", "NbMaxDeck", "WinnerMoney" },
                values: new object[] { 1, 1000.0, 50.0, 4, 3, 8, 5, 100.0 });

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "DefaultRarity", "ImageURL", "Name", "NbCards", "Price" },
                values: new object[,]
                {
                    { 1, 0, "https://th-thumbnailer.cdn-si-edu.com/3hb9uUW7hZHUXxJmBmfFkwkivJI=/fit-in/1600x0/https://tf-cmsv2-smithsonianmag-media.s3.amazonaws.com/filer/fd/e7/fde77fde-700d-4a08-8e19-305a0de60130/5879116857_4ab170f4d5_b.jpg", "Basic Pack", 3, 200.0 },
                    { 2, 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUe7jv0hsq3INvymTpQvP8F-TprBnerk4HGnyHKY5nFj1kXHEg", "Normal Pack", 4, 500.0 },
                    { 3, 1, "https://i.pinimg.com/474x/f8/39/37/f839377928c94ac922cc39f35fd0a841.jpg", "Super Pack", 5, 2000.0 }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Description", "IconURL", "Name" },
                values: new object[,]
                {
                    { 1, "permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire. (Fonctionne uniquement à l’attaque, pas à la défense)", "fas fa-bolt", "First Strike" },
                    { 2, "lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.", "fas fa-exclamation", "Thorns" },
                    { 3, "soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)", "fas fa-heartbeat", "Heal" },
                    { 4, "tant que la carte est sur le terrain son joueur gagne de la vie", "fas fa-cross", "Love of Jesus Christ" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "PowerId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 3, 2 },
                    { 4, 11, 4, 1 },
                    { 5, 3, 1, 1 },
                    { 6, 3, 2, 1 },
                    { 7, 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ELO", "Money", "Name", "NbDefeats", "NbVictories", "UserId" },
                values: new object[,]
                {
                    { 1, 1000, 0.0, "Test player 1", 0, 0, "User1Id" },
                    { 2, 1000, 0.0, "Test player 2", 0, 0, "User2Id" }
                });

            migrationBuilder.InsertData(
                table: "Probabilities",
                columns: new[] { "Id", "BaseQty", "PackId", "Rarity", "Value" },
                values: new object[,]
                {
                    { 1, 0, 1, 0, 0.69999999999999996 },
                    { 2, 0, 1, 1, 0.29999999999999999 },
                    { 3, 0, 2, 0, 0.59999999999999998 },
                    { 4, 1, 2, 1, 0.29999999999999999 },
                    { 5, 0, 2, 2, 0.10000000000000001 },
                    { 6, 0, 2, 3, 0.20000000000000001 },
                    { 7, 0, 3, 1, 0.65000000000000002 },
                    { 8, 1, 3, 2, 0.25 },
                    { 9, 0, 3, 3, 0.10000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "StarterCards",
                columns: new[] { "Id", "CardId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 5 },
                    { 8, 6 },
                    { 9, 6 }
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
                name: "IX_CardPowers_CardId",
                table: "CardPowers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_PowerId",
                table: "CardPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deck_PlayerId",
                table: "Deck",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckOwnedCard_OwnedCardId",
                table: "DeckOwnedCard",
                column: "OwnedCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataAId",
                table: "Matches",
                column: "PlayerDataAId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerDataBId",
                table: "Matches",
                column: "PlayerDataBId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayersData_PlayerId",
                table: "MatchPlayersData",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_CardId",
                table: "OwnedCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedCards_PlayerId",
                table: "OwnedCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PairOfPlayers_PlayerInfo1Id",
                table: "PairOfPlayers",
                column: "PlayerInfo1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PairOfPlayers_PlayerInfo2Id",
                table: "PairOfPlayers",
                column: "PlayerInfo2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCards_CardId",
                table: "PlayableCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCards_MatchPlayerDataId",
                table: "PlayableCards",
                column: "MatchPlayerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCards_MatchPlayerDataId1",
                table: "PlayableCards",
                column: "MatchPlayerDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCards_MatchPlayerDataId2",
                table: "PlayableCards",
                column: "MatchPlayerDataId2");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCards_MatchPlayerDataId3",
                table: "PlayableCards",
                column: "MatchPlayerDataId3");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_PlayableCardId",
                table: "PlayableCardStatus",
                column: "PlayableCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_StatusId",
                table: "PlayableCardStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Probabilities_PackId",
                table: "Probabilities",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_StarterCards_CardId",
                table: "StarterCards",
                column: "CardId");
        }

        /// <inheritdoc />
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
                name: "CardPowers");

            migrationBuilder.DropTable(
                name: "DeckOwnedCard");

            migrationBuilder.DropTable(
                name: "GameConfigs");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PairOfPlayers");

            migrationBuilder.DropTable(
                name: "PlayableCardStatus");

            migrationBuilder.DropTable(
                name: "Probabilities");

            migrationBuilder.DropTable(
                name: "StarterCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "OwnedCards");

            migrationBuilder.DropTable(
                name: "PlayerInfo");

            migrationBuilder.DropTable(
                name: "PlayableCards");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "MatchPlayersData");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
