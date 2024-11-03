// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Super_Cartes_Infinies.Data;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111112",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "11111111-1111-1111-1111-111111111111",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "859c0099-31c9-4e34-bf4f-ad9b8a7867ad",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFOzdLKJy91dEOmmoSxEDAgivLXcTlRumRET4yxFgJsJPl1lbQSCkuoRCzyPuYvRnQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "08514fbf-2f65-4e41-8e95-23dda3e4911d",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = "User1Id",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9ffd324f-24b0-4f7f-b9d4-10be7624c7bb",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "868b6dba-3285-4e2d-a7e2-9ccd5a8d3774",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "User2Id",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "df8bf2c1-5a0b-4654-a7f0-8ce7d6e0d8c0",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "57221549-0d2d-4e33-acc9-88b71d30c191",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "11111111-1111-1111-1111-111111111111",
                            RoleId = "11111111-1111-1111-1111-111111111112"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Models.CardPower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("PowerId");

                    b.ToTable("CardPower");
                });

            modelBuilder.Entity("Models.Models.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deck");
                });

            modelBuilder.Entity("Models.Models.GameConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BeginnerMoney")
                        .HasColumnType("float");

                    b.Property<double>("LoserMoney")
                        .HasColumnType("float");

                    b.Property<int>("NbCardsToDraw")
                        .HasColumnType("int");

                    b.Property<int>("NbManaToReceive")
                        .HasColumnType("int");

                    b.Property<int>("NbMaxCard")
                        .HasColumnType("int");

                    b.Property<int>("NbMaxDeck")
                        .HasColumnType("int");

                    b.Property<double>("WinnerMoney")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("GameConfigs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeginnerMoney = 1000.0,
                            LoserMoney = 10.0,
                            NbCardsToDraw = 4,
                            NbManaToReceive = 3,
                            NbMaxCard = 0,
                            NbMaxDeck = 0,
                            WinnerMoney = 50.0
                        });
                });

            modelBuilder.Entity("Models.Models.OwnedCardDeck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<int>("OwnedCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.HasIndex("OwnedCardId");

                    b.ToTable("OwnedCardDeck");
                });

            modelBuilder.Entity("Models.Models.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Power");
                });

            modelBuilder.Entity("Models.Models.StarterCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("StarterCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 1
                        },
                        new
                        {
                            Id = 2,
                            CardId = 2
                        },
                        new
                        {
                            Id = 3,
                            CardId = 3
                        },
                        new
                        {
                            Id = 4,
                            CardId = 4
                        },
                        new
                        {
                            Id = 5,
                            CardId = 4
                        },
                        new
                        {
                            Id = 6,
                            CardId = 5
                        },
                        new
                        {
                            Id = 7,
                            CardId = 5
                        },
                        new
                        {
                            Id = 8,
                            CardId = 6
                        },
                        new
                        {
                            Id = 9,
                            CardId = 6
                        });
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attack = 3,
                            Cost = 3,
                            Health = 3,
                            ImageUrl = "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg",
                            Name = "Chat Dragon",
                            Rarity = 0
                        },
                        new
                        {
                            Id = 2,
                            Attack = 2,
                            Cost = 3,
                            Health = 5,
                            ImageUrl = "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg",
                            Name = "Chat Awesome",
                            Rarity = 1
                        },
                        new
                        {
                            Id = 3,
                            Attack = 2,
                            Cost = 1,
                            Health = 1,
                            ImageUrl = "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg",
                            Name = "Chatton Laser",
                            Rarity = 0
                        },
                        new
                        {
                            Id = 4,
                            Attack = 8,
                            Cost = 4,
                            Health = 4,
                            ImageUrl = "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg",
                            Name = "Chat Spacial",
                            Rarity = 3
                        },
                        new
                        {
                            Id = 5,
                            Attack = 7,
                            Cost = 5,
                            Health = 7,
                            ImageUrl = "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg",
                            Name = "Chat Guerrier",
                            Rarity = 3
                        },
                        new
                        {
                            Id = 6,
                            Attack = 4,
                            Cost = 2,
                            Health = 2,
                            ImageUrl = "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720",
                            Name = "Chat Laser",
                            Rarity = 0
                        },
                        new
                        {
                            Id = 7,
                            Attack = 6,
                            Cost = 4,
                            Health = 3,
                            ImageUrl = "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg",
                            Name = "Jedi Chat",
                            Rarity = 2
                        },
                        new
                        {
                            Id = 8,
                            Attack = 1,
                            Cost = 2,
                            Health = 9,
                            ImageUrl = "https://i.ytimg.com/vi/2I7pZlUhZak/maxresdefault.jpg",
                            Name = "Blob Chat",
                            Rarity = 2
                        },
                        new
                        {
                            Id = 9,
                            Attack = 5,
                            Cost = 2,
                            Health = 1,
                            ImageUrl = "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75",
                            Name = "Jedi Chatton",
                            Rarity = 0
                        },
                        new
                        {
                            Id = 10,
                            Attack = 6,
                            Cost = 2,
                            Health = 1,
                            ImageUrl = "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg",
                            Name = "Chat Furtif",
                            Rarity = 1
                        });
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMatchCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlayerATurn")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerDataAId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerDataBId")
                        .HasColumnType("int");

                    b.Property<string>("UserAId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WinnerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerDataAId");

                    b.HasIndex("PlayerDataBId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Mana")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayersData");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.OwnedCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("PlayerId");

                    b.ToTable("OwnedCards");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId1")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId2")
                        .HasColumnType("int");

                    b.Property<int?>("MatchPlayerDataId3")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("MatchPlayerDataId");

                    b.HasIndex("MatchPlayerDataId1");

                    b.HasIndex("MatchPlayerDataId2");

                    b.HasIndex("MatchPlayerDataId3");

                    b.ToTable("PlayableCard");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Money = 0.0,
                            Name = "Test player 1",
                            UserId = "User1Id"
                        },
                        new
                        {
                            Id = 2,
                            Money = 0.0,
                            Name = "Test player 2",
                            UserId = "User2Id"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Models.CardPower", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany("CardPowers")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Models.Power", "Power")
                        .WithMany("CardPowers")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Power");
                });

            modelBuilder.Entity("Models.Models.OwnedCardDeck", b =>
                {
                    b.HasOne("Models.Models.Deck", "Deck")
                        .WithMany("OwnedCardDecks")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.OwnedCard", "OwnedCard")
                        .WithMany("OwnedCardDecks")
                        .HasForeignKey("OwnedCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");

                    b.Navigation("OwnedCard");
                });

            modelBuilder.Entity("Models.Models.StarterCard", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Match", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataA")
                        .WithMany()
                        .HasForeignKey("PlayerDataAId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", "PlayerDataB")
                        .WithMany()
                        .HasForeignKey("PlayerDataBId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PlayerDataA");

                    b.Navigation("PlayerDataB");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.OwnedCard", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.Player", "Player")
                        .WithMany("OwnedCards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.PlayableCard", b =>
                {
                    b.HasOne("Super_Cartes_Infinies.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("BattleField")
                        .HasForeignKey("MatchPlayerDataId");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("CardsPile")
                        .HasForeignKey("MatchPlayerDataId1");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Graveyard")
                        .HasForeignKey("MatchPlayerDataId2");

                    b.HasOne("Super_Cartes_Infinies.Models.MatchPlayerData", null)
                        .WithMany("Hand")
                        .HasForeignKey("MatchPlayerDataId3");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Models.Deck", b =>
                {
                    b.Navigation("OwnedCardDecks");
                });

            modelBuilder.Entity("Models.Models.Power", b =>
                {
                    b.Navigation("CardPowers");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Card", b =>
                {
                    b.Navigation("CardPowers");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.MatchPlayerData", b =>
                {
                    b.Navigation("BattleField");

                    b.Navigation("CardsPile");

                    b.Navigation("Graveyard");

                    b.Navigation("Hand");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.OwnedCard", b =>
                {
                    b.Navigation("OwnedCardDecks");
                });

            modelBuilder.Entity("Super_Cartes_Infinies.Models.Player", b =>
                {
                    b.Navigation("OwnedCards");
                });
#pragma warning restore 612, 618
        }
    }
}
