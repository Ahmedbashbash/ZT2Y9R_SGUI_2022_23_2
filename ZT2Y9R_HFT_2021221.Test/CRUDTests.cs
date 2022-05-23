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
        [Test]
        public void TestDeleteCoach()
        {
            Mock<ICoachRepository> mockedCoachRepo = new Mock<ICoachRepository>(MockBehavior.Loose);

            List<Coaches> testCoaches = new List<Coaches>()
            {
                new Coaches() { CoachId = 1, Name = "Jon", age =23, ClubId =1,  CoachSalary=50, CoachHireDate=DateTime.Today  },
                new Coaches() { CoachId = 2, Name = "Lilla",age =18, ClubId =2, CoachSalary=10, CoachHireDate= DateTime.Today  },
                new Coaches() { CoachId = 3, Name = "Halk",age =27, ClubId =3, CoachSalary=23, CoachHireDate=DateTime.Today  },
            };

            mockedCoachRepo.Setup(repo => repo.GetAll()).Returns(testCoaches.AsQueryable());
            mockedCoachRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testCoaches.Where(x => x.ClubId == i).Single());
            mockedCoachRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

            CoachesLogic CoachesLogic = new CoachesLogic(mockedCoachRepo.Object);
            CoachesLogic.deleteCoache(2);
            mockedCoachRepo.Verify(repo => repo.Delete(2));

        }
        [Test]
        public void TestDeleteClub()
        {
            Mock<IClubRepository> mockedClubRepo = new Mock<IClubRepository>(MockBehavior.Loose);

            List<Clubs> testClubs = new List<Clubs> ()
            {
                new Clubs() { ClubId= 1, Name = "Real", NumberOfTrophies=33 },
                new Clubs() { ClubId = 2, Name = "Barca", NumberOfTrophies=20  },
                new Clubs() { ClubId = 3, Name = "PSG", NumberOfTrophies=16  },
            };

            mockedClubRepo.Setup(repo => repo.GetAll()).Returns(testClubs.AsQueryable());
            mockedClubRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testClubs.Where(x => x.ClubId == i).Single());
            mockedClubRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

            ClubsLogic ClubsLogic = new ClubsLogic(mockedClubRepo.Object);
            ClubsLogic.deleteClub(2);
            mockedClubRepo.Verify(repo => repo.Delete(2));

        }
        [Test]
        public void TestDeleteBusinessManager()
        {
            Mock<IBusinessManagerRepository> mockedBusinessManagerRepo = new Mock<IBusinessManagerRepository>(MockBehavior.Loose);

            List<BusinessManagers> testBusinessManagers = new List<BusinessManagers>()
            {
                new BusinessManagers() { BusinessManagerId = 1, name = "Jon", age =23, salary= 15  },
                new BusinessManagers() { BusinessManagerId = 2, name = "Lilla",age =18, salary= 12   },
                new BusinessManagers() { BusinessManagerId = 3, name = "Halk",age =27, salary= 11   },
            };

            mockedBusinessManagerRepo.Setup(repo => repo.GetAll()).Returns(testBusinessManagers.AsQueryable());
            mockedBusinessManagerRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testBusinessManagers.Where(x => x.BusinessManagerId == i).Single());
            mockedBusinessManagerRepo.Setup(repo => repo.Delete(It.IsAny<int>()));

            BusinessManagerLogic BusinessManagersLogic = new BusinessManagerLogic(mockedBusinessManagerRepo.Object);
            BusinessManagersLogic.deleteBusinessManager(2);
            mockedBusinessManagerRepo.Verify(repo => repo.Delete(2));

        }

        [Test]
        public void changeNumberOfTrophies()
        {
            Mock<IClubRepository> mockedClubRepo = new Mock<IClubRepository>(MockBehavior.Loose);

            List<Clubs> testClubs = new List<Clubs>()
            {
                new Clubs() { ClubId= 1, Name = "Real", NumberOfTrophies=33 },
                new Clubs() { ClubId = 2, Name = "Barca", NumberOfTrophies=20  },
            };

            mockedClubRepo.Setup(repo => repo.GetAll()).Returns(testClubs.AsQueryable());
            mockedClubRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testClubs.Where(x => x.ClubId == i).Single());

            ClubsLogic ClubsLogic = new ClubsLogic(mockedClubRepo.Object);
            ClubsLogic.changeNumberOfTrophies(1, 34);
            mockedClubRepo.Verify(repo => repo.changeNumberOfTrophies(1, 34), Times.Once);
        }

        [Test]
        public void changePlayerSalary()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);

            List<Players> testPlayers = new List<Players>()
            {
                new Players() { PlayerId = 1, Name = "Jon", age =23, BusinessManagersId=1, ClubId =1, Position="Attacker", PlayerSalary=50  },
                new Players() { PlayerId = 2, Name = "Lilla",age =18, BusinessManagersId=2, ClubId =2, Position="Defender", PlayerSalary=10  },
            };

            mockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(testPlayers.AsQueryable());
            mockedPlayerRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns((int i) => testPlayers.Where(x => x.BusinessManagersId == i).Single());

            PlayersLogic playersLogic = new PlayersLogic(mockedPlayerRepo.Object);

            playersLogic.changePlayerSalary(2, 15);
            mockedPlayerRepo.Verify(repo => repo.changePlayerSalary(2, 15), Times.Once);

        }

    }
}
