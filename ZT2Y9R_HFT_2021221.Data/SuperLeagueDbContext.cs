using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Data
{
    class SuperLeagueDbContext : DbContext
    {       

        protected SuperLeagueDbContext()
        {
        }

        public SuperLeagueDbContext(DbContextOptions<SuperLeagueDbContext> options) : base(options)
        {
        }

        public DbSet<Clubs> Clubs { get; set; }

        public DbSet<Players> Players { get; set; }

        public DbSet<Coaches> Coaches { get; set; }

        public DbSet<BusinessManagers> BusinessManagers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Db.mdf;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Clubs clubs1 = new Clubs() { ClubId=1, Name="Real Madrid", NumberOfTrophies=66};
            Clubs clubs2 = new Clubs() { ClubId=2, Name="Barcelona", NumberOfTrophies=75};
            Clubs clubs3 = new Clubs() { ClubId=3, Name="Juventus", NumberOfTrophies=70};


            Coaches coaches1 = new Coaches() { ClubId = 1, Name = "Carlo Ancelotti", age= 62, CoachHireDate= new DateTime(2021, 6, 1), Club= clubs1, CoachSalary = 10 };
            Coaches coaches2 = new Coaches() { ClubId = 2, Name = "Ronald Koeman", age= 58, CoachHireDate= new DateTime(2020, 8, 19), Club= clubs2, CoachSalary= 10 };
            Coaches coaches3 = new Coaches() { ClubId = 3, Name = "Massimiliano Allegri", age= 54, CoachHireDate= new DateTime(2021, 7, 1), Club= clubs3, CoachSalary= 7 };

            Players players1 = new Players() { PlayerId = 1, Name = "Karim Benzema", age = 33, Club = clubs1, Position= "Striker", PlayerSalary=8 };
            Players players2 = new Players() { PlayerId = 2, Name = "Philippe Coutinho", age = 29, Club = clubs2, Position= "winger", PlayerSalary=7 };
            Players players3 = new Players() { PlayerId = 3, Name = "Paulo Dybala", age = 33, Club = clubs3, Position= "forward", PlayerSalary=5 };
            

            BusinessManagers businessManagers1 = new BusinessManagers() { BusinessManagerId = 1, Name = "Óscar Ribot", age = 42, Salary = 3 };
            BusinessManagers businessManagers2 = new BusinessManagers() { BusinessManagerId = 2, Name = "Kia Joorabchian", age = 43, Salary = 2 };
            BusinessManagers businessManagers3 = new BusinessManagers() { BusinessManagerId = 3, Name = "Jorge Antun", age = 39, Salary = 1 };



            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasOne(Players => Players.BusinessManagers)
                .WithMany(BusinessManagers=> BusinessManagers.Players)
                .HasForeignKey(Players => Players.BusinessManagers)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasOne(Players => Players.Club)
                .WithMany(Clubs => Clubs.Players)
                .HasForeignKey(Players => Players.Club)
                .OnDelete(DeleteBehavior.SetNull);
            });

           

            modelBuilder.Entity<Clubs>().HasData(clubs1, clubs2, clubs3);
            modelBuilder.Entity<Coaches>().HasData(coaches1, coaches2, coaches3);
            modelBuilder.Entity<Players>().HasData(players1, players2, players3);
            modelBuilder.Entity<BusinessManagers>().HasData(businessManagers1, businessManagers2, businessManagers3);

        }


    }
}
