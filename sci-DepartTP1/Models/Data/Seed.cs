using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data
{
    public class Seed
    {
        public Seed() { }

        public static Card[] SeedCards()
        {
            return new Card[] {
                new Card
                {
                    Id = 1,
                    Name = "Chat Dragon",
                    Attack = 3,
                    Health = 3,
                    Cost = 3,
                    ImageUrl = "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg",
                    Rarity = Rarity.Commune,
                }, new Card
                {
                    Id = 2,
                    Name = "Chat Awesome",
                    Attack = 2,
                    Health = 5,
                    Cost = 3,
                    ImageUrl = "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg",
                    Rarity = Rarity.Rare,
                }, new Card
                {
                    Id = 3,
                    Name = "Chatton Laser",
                    Attack = 2,
                    Health = 1,
                    Cost = 1,
                    ImageUrl = "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg",
                    Rarity = Rarity.Commune,
                }, new Card
                {
                    Id = 4,
                    Name = "Chat Spacial",
                    Attack = 8,
                    Health = 4,
                    Cost = 4,
                    ImageUrl = "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg",
                    Rarity = Rarity.Légendaire,
                }, new Card
                {
                    Id = 5,
                    Name = "Chat Guerrier",
                    Attack = 7,
                    Health = 7,
                    Cost = 5,
                    ImageUrl = "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg",
                    Rarity = Rarity.Légendaire,
                }, new Card
                {
                    Id = 6,
                    Name = "Chat Laser",
                    Attack = 4,
                    Health = 2,
                    Cost = 2,
                    ImageUrl = "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720",

                }, new Card
                {
                    Id = 7,
                    Name = "Jedi Chat",
                    Attack = 6,
                    Health = 3,
                    Cost = 4,
                    ImageUrl = "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg",
                    Rarity = Rarity.Épique,
                }, new Card
                {
                    Id = 8,
                    Name = "Blob Chat",
                    Attack = 1,
                    Health = 9,
                    Cost = 2,
                    ImageUrl = "https://i.ytimg.com/vi/2I7pZlUhZak/maxresdefault.jpg",
                    Rarity = Rarity.Épique,
                }, new Card
                {
                    Id = 9,
                    Name = "Jedi Chatton",
                    Attack = 5,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75",

                }, new Card
                {
                    Id = 10,
                    Name = "Chat Furtif",
                    Attack = 6,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg"
                }, new Card
                {
                    Id = 11,
                    Name = "Chat Jesus",
                    Attack = 0,
                    Health = 10,
                    Cost = 1,
                    ImageUrl = "https://cdn.openart.ai/uploads/image_FkweA3pP_1695446033995_512.webp",
                    Rarity = Rarity.Légendaire,
                }
            };
        }
        public static Power[] SeedPowers()
        {
            return new Power[] {
                new Power
                {
                    Id = Power.FIRST_STRIKE_ID,
                    Name = "First Strike",
                    Description = "permet à une carte d’attaquer en « premier » et de ne pas recevoir de dégât si elle tue la carte de l’adversaire. (Fonctionne uniquement à l’attaque, pas à la défense)",
                    IconURL = "fas fa-bolt"
                },
                new Power
                {
                    Id = Power.THORNS_ID,
                    Name = "Thorns",
                    Description = "lorsqu’une carte défend, elle inflige X de dégâts AVANT de recevoir des dégâts. Si l’attaquant est tué par ces dégâts, l’attaque s’arrête et le défenseur ne reçoit pas de dégâts.",
                    IconURL = "fas fa-exclamation"
                },
                new Power
                {
                    Id = Power.HEAL_ID,
                    Name = "Heal",
                    Description = "soigne les cartes alliées de X incluant elle-même AVANT d’attaquer (mais les cartes ne peuvent pas avoir plus de health qu’au départ.)",
                    IconURL = "fas fa-heartbeat"
                },
                new Power
                {
                    Id = Power.LOVE_OF_JESUS_CHRIST,
                    Name = "Love of Jesus Christ",
                    Description = "tant que la carte est sur le terrain son joueur gagne de la vie",
                    IconURL = "fas fa-cross"
                }

            };
        }
        public static CardPower[] SeedCardPowers()
        {
            return new CardPower[] {
                new CardPower
                {
                    Id = 1,
                    CardId = 1,
                    PowerId = Power.FIRST_STRIKE_ID,
                    Value = 1

                },
                new CardPower
                {
                    Id = 2,
                    CardId = 1,
                    PowerId = Power.THORNS_ID,
                    Value = 1

                },
                new CardPower
                {
                    Id = 3,
                    CardId = 2,
                    PowerId = Power.HEAL_ID,
                    Value = 2

                },
                new CardPower
                {
                    Id = 4,
                    CardId = 11,
                    PowerId = Power.LOVE_OF_JESUS_CHRIST,
                    Value = 1
                },
                new CardPower
                {
                    Id = 5,
                    CardId = 3,
                    PowerId = Power.FIRST_STRIKE_ID,
                    Value = 1

                },
                new CardPower
                {
                    Id = 6,
                    CardId = 3,
                    PowerId = Power.THORNS_ID,
                    Value = 1

                },
                new CardPower
                {
                    Id = 7,
                    CardId = 3,
                    PowerId = Power.HEAL_ID,
                    Value = 1

                },
            };
        }

        public static IdentityUser[] SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                // On encrypte le mot de passe
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                LockoutEnabled = true
            };

            return new IdentityUser[] { admin };
        }
        public static IdentityRole[] SeedRoles()
        {
            IdentityRole adminRole = new IdentityRole
            {
                Id = "11111111-1111-1111-1111-111111111112",
                Name = ApplicationDbContext.ADMIN_ROLE,
                NormalizedName = ApplicationDbContext.ADMIN_ROLE.ToUpper()
            };

            return new IdentityRole[] { adminRole };
        }
        public static IdentityUserRole<string>[] SeedUserRoles()
        {
            IdentityUserRole<string> userAdmin = new IdentityUserRole<string>
            {
                RoleId = "11111111-1111-1111-1111-111111111112",
                UserId = "11111111-1111-1111-1111-111111111111"
            };
            return new IdentityUserRole<string>[] { userAdmin };
        }
        public static IdentityUser[] SeedTestUsers()
        {
            return new IdentityUser[] {
                new IdentityUser()
                {
                    Id = "User1Id"
                },
                new IdentityUser
                {
                Id = "User2Id"
                }
            };
        }
        public static Player[] SeedTestPlayers()
        {
            return new Player[] {
                new Player
                {
                    Id = 1,
                    Name = "Test player 1",
                    UserId = "User1Id"

                },
                new Player
                {
                    Id = 2,
                    Name = "Test player 2",
                    UserId = "User2Id"
                }
            };
        }

        //Ajout d'un seed des cartes de départ
        //(3 cartes différentes avec une seul copie et
        //3 autres cartes avec deux copies chaque)
        public static StarterCard[] SeedStarterCards()
        {
            return new StarterCard[]
            {
                new StarterCard
                {
                    Id = 1,
                    CardId = 1,
                },
                new StarterCard
                {
                    Id = 2,
                    CardId = 2,
                },
                new StarterCard
                {
                    Id = 3,
                    CardId = 3,
                },
                new StarterCard
                {
                    Id = 4,
                    CardId = 4,
                },
                new StarterCard
                {
                    Id= 5,
                    CardId= 4,
                },
                new StarterCard
                {
                    Id = 6,
                    CardId= 5,
                },
                new StarterCard
                {
                    Id = 7,
                    CardId= 5,
                },
                new StarterCard
                {
                    Id = 8,
                    CardId= 6,
                },
                new StarterCard
                {
                    Id = 9,
                    CardId= 6,
                }
            };
        }

        //Ajout d'un seed de la configuration du jeu
        //Une quantité de 4 cartes à piger et 3 manas par tour.
        public static GameConfig[] SeedGameConfig()
        {
            return new GameConfig[]
            {
                new GameConfig
                {
                    Id = 1,
                    NbCardsToDraw = 4,
                    NbManaToReceive = 3,
                    NbMaxDeck = 5,
                    NbMaxCard = 8,
                }
            };
        }

        public static Pack[] SeedPacks()
        {
            var basicPack = new Pack
            {
                Id = 1,
                Name = "Basic Pack",
                Price = 200.0,
                ImageURL = "https://th-thumbnailer.cdn-si-edu.com/3hb9uUW7hZHUXxJmBmfFkwkivJI=/fit-in/1600x0/https://tf-cmsv2-smithsonianmag-media.s3.amazonaws.com/filer/fd/e7/fde77fde-700d-4a08-8e19-305a0de60130/5879116857_4ab170f4d5_b.jpg",
                NbCards = 3,
                DefaultRarity = Rarity.Commune
            };

            var normalPack = new Pack
            {
                Id = 2,
                Name = "Normal Pack",
                Price = 500.0,
                ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUe7jv0hsq3INvymTpQvP8F-TprBnerk4HGnyHKY5nFj1kXHEg",
                NbCards = 4,
                DefaultRarity = Rarity.Commune
            };

            var superPack = new Pack
            {
                Id = 3,
                Name = "Super Pack",
                Price = 2000.0,
                ImageURL = "https://i.pinimg.com/474x/f8/39/37/f839377928c94ac922cc39f35fd0a841.jpg",
                NbCards = 5,
                DefaultRarity = Rarity.Rare
            };

            var packs = new Pack[] { basicPack, normalPack, superPack };

            var probabilities = new List<Probability>
            {
                //Basic
                new Probability { Id = 1, Rarity = Rarity.Commune, Value = 70.0, BaseQty = 0, PackId = 1 },
                new Probability { Id = 2, Rarity = Rarity.Rare, Value = 30.0, BaseQty = 0, PackId = 1 },

                //Normal
                new Probability { Id = 3, Rarity = Rarity.Commune, Value = 60.0, BaseQty = 0, PackId = 2 },
                new Probability { Id = 4, Rarity = Rarity.Rare, Value = 30.0, BaseQty = 1, PackId = 2 },
                new Probability { Id = 5, Rarity = Rarity.Épique, Value = 10.0, BaseQty = 0, PackId = 2 },
                new Probability { Id = 5, Rarity = Rarity.Légendaire, Value = 2.0, BaseQty = 0, PackId = 2 },

                //Super
                new Probability { Id = 4, Rarity = Rarity.Rare, Value = 65.0, BaseQty = 0, PackId = 3 },
                new Probability { Id = 5, Rarity = Rarity.Épique, Value = 25.0, BaseQty = 1, PackId = 3 },
                new Probability { Id = 5, Rarity = Rarity.Légendaire, Value = 10.0, BaseQty = 0, PackId = 3 },
            };

            return packs;
        }

    }
}

