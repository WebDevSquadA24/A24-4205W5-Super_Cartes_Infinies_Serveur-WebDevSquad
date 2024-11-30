using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Models.VM;
using Models.Models;

namespace WebApi.Services.Tests
{
    [TestClass()]
    public class EloBackGroundServiceTests
    {
        DbContextOptions<ApplicationDbContext> options;
        protected Player _player_1000, _player_1004, _player_1500, _player_1200, _player_1504, _player_1204;
        protected PlayerInfo _playerInfo_1000, _playerInfo_1004, _playerInfo_1500, _playerInfo_1200, _playerInfo_1504, _playerInfo_1204;

        public EloBackGroundServiceTests() 
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
            // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
            .UseInMemoryDatabase(databaseName: "EloBackGroundServiceTests")
            .UseLazyLoadingProxies(true) // Active le lazy loading
            .Options;
        }

        [TestInitialize]
        public void Init()
        {
            // TODO avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(options);
            // TODO on ajoute des données de tests
            Player[] players = new Player[]
            {
                _player_1000 = new Player
                {
                    Id = 1,
                    Name = "Player1000",
                    UserId = "Player1000",
                    Money =1000,
                    ELO = 1000,
                },
                _player_1004 =new Player
                {
                    Id = 2,
                    Name = "Player1004",
                    UserId = "Player1004",
                    Money =1000,
                    ELO = 1004,
                },
                _player_1500 = new Player
                {
                    Id = 3,
                    Name = "Player1500",
                    UserId = "Player1500",
                    Money =1000,
                    ELO = 1500,
                },
                _player_1200 = new Player
                {
                    Id = 4,
                    Name = "Player1200",
                    UserId = "Player1200",
                    Money =1000,
                    ELO = 1200,
                },
                _player_1504 = new Player
                {
                    Id = 5,
                    Name = "Player1504",
                    UserId = "Player1504",
                    Money =1000,
                    ELO = 1504,
                },
                _player_1204 = new Player
                {
                    Id = 6,
                    Name = "Player1204",
                    UserId = "Player1204",
                    Money =1000,
                    ELO = 1204,
                },
            };


            PlayerInfo[] playerInfos = new PlayerInfo[]
            {
                _playerInfo_1000 = new PlayerInfo()
                {
                    Id=1,
                    UserId = _player_1000.UserId,
                    ELO = _player_1000.ELO,
                    attente =0,
                    ConnectionId = _player_1000.UserId,
                },
                _playerInfo_1004 = new PlayerInfo()
                {
                    Id=2,
                    UserId = _player_1004.UserId,
                    ELO = _player_1004.ELO,
                    attente =0,
                    ConnectionId = _player_1004.UserId,
                },
                _playerInfo_1500 = new PlayerInfo()
                {
                    Id=3,
                    UserId = _player_1500.UserId,
                    ELO = _player_1500.ELO,
                    attente =0,
                    ConnectionId = _player_1500.UserId,
                },
                _playerInfo_1200 = new PlayerInfo()
                {
                    Id=4,
                    UserId = _player_1200.UserId,
                    ELO = _player_1200.ELO,
                    attente =0,
                    ConnectionId = _player_1200.UserId,
                },
                _playerInfo_1504 = new PlayerInfo()
                {
                    Id=5,
                    UserId = _player_1504.UserId,
                    ELO = _player_1504.ELO,
                    attente =0,
                    ConnectionId = _player_1504.UserId,
                },
                _playerInfo_1204 = new PlayerInfo()
                {
                    Id=6,
                    UserId = _player_1204.UserId,
                    ELO = _player_1204.ELO,
                    attente =0,
                    ConnectionId = _player_1204.UserId,
                },

            };
            db.AddRange(players);
            db.AddRange(playerInfos);

            db.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Players.RemoveRange(db.Players);
            db.PlayerInfo.RemoveRange(db.PlayerInfo);
            db.SaveChanges();
        }

        [TestMethod()]
        public void GeneratePairsAsyncTest()
        {
            Assert.Fail();
        }
    }
}