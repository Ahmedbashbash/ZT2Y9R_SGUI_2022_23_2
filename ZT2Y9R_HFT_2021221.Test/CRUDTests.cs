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
        [Test]
        public void TestDeletePlayer()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);

            List<Players> testPlayers = new List<Players>()
            {
                new Players() { PlayerId = 1, Name = "Jon", age =23, BusinessManagersId=1, ClubId =1, Position="Attacker", PlayerSalary=50  },
                new Players() { PlayerId = 2, Name = "Lilla",age =18, BusinessManagersId=2, ClubId =2, Position="Defender", PlayerSalary=10  },
                new Players() { PlayerId = 3, Name = "Halk",age =27, BusinessManagersId=3, ClubId =3, Position="GoalKeeper", PlayerSalary=23  },
            };

            mockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(testPlayers.AsQueryable());
            mockedPlayerRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testPlayers.Where(x => x.BusinessManagersId == i).Single());
            mockedPlayerRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

            PlayersLogic playersLogic = new PlayersLogic(mockedPlayerRepo.Object);
            playersLogic.deletePlayer(2);
            mockedPlayerRepo.Verify(repo => repo.Delete(2));

        }
    }
}
