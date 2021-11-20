using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Logic;
using ZT2Y9R_HFT_2021221.Models;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Test
{
    [TestFixture]
    class CRUDTests
    {
        [Test]
        public void TestAddPlayer()
        {
            Mock<IPlayerRepository> mockedPlayerRepository = new Mock<IPlayerRepository>(MockBehavior.Loose);
            PlayersLogic playersLogic = new PlayersLogic(mockedPlayerRepository.Object);
            mockedPlayerRepository.Setup(repo => repo.Add(It.IsAny<Players>()));
            playersLogic.InsertNewPlayer("Ahmed", 22, "attacker", 50);
            mockedPlayerRepository.Verify(repo => repo.Add(It.IsAny<Players>()), Times.Once);
        }
        [Test]
        public void TestAddCoach()
        {
            Mock<ICoachRepository> mockedCoachRepository = new Mock<ICoachRepository>(MockBehavior.Loose);
            CoachesLogic coachesLogic = new CoachesLogic(mockedCoachRepository.Object);
            mockedCoachRepository.Setup(repo => repo.Add(It.IsAny<Coaches>()));
            coachesLogic.InsertNewCoach("Mahmoud", 22, 20 , DateTime.Now );
            mockedCoachRepository.Verify(repo => repo.Add(It.IsAny<Coaches>()), Times.Once);
        }
        [Test]
        public void TestAddClub()
        {
            Mock<IClubRepository> mockedClubRepository = new Mock<IClubRepository>(MockBehavior.Loose);
            ClubsLogic clubLogic = new ClubsLogic(mockedClubRepository.Object);
            mockedClubRepository.Setup(repo => repo.Add(It.IsAny<Clubs>()));
            clubLogic.InsertNewClub("Real Madrid", 50);
            mockedClubRepository.Verify(repo => repo.Add(It.IsAny<Clubs>()), Times.Once);
        }
        [Test]
        public void TestAddBusinessManager()
        {
            Mock<IBusinessManagerRepository> mockedBusinessManagerRepository = new Mock<IBusinessManagerRepository>(MockBehavior.Loose);
            BusinessManagerLogic businessManagerLogic = new BusinessManagerLogic(mockedBusinessManagerRepository.Object);
            mockedBusinessManagerRepository.Setup(repo => repo.Add(It.IsAny<BusinessManagers>()));
            businessManagerLogic.InsertNewBusinessManager("Ibrahim", 26, 10);
            mockedBusinessManagerRepository.Verify(repo => repo.Add(It.IsAny<BusinessManagers>()), Times.Once);
        }
    }
}
