using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass()]
    public class PackServiceTests
    {
        [TestMethod()]
        public async Task OpenPackTest()
        {
            PackService packSerice = new PackService(null);

            Pack pack = new Pack()
            {
                DefaultRarity = Models.Rarity.Rare,
                NbCards = 3
               
            };

            pack.Probabilities = new List<Probability>();


            var cartes = await packSerice.OpenPack(pack);

            Assert.AreEqual(pack.NbCards, cartes);
        }
    }
}