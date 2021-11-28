using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Data
{
    public class SuperLeagueDbContext : DbContext
    {       

        public SuperLeagueDbContext()
        {
            Database.EnsureCreated();
        }

        public SuperLeagueDbContext(DbContextOptions<SuperLeagueDbContext> options) : base(options)
        {
        }

        public DbSet<Clubs> Clubs { get; set; }

        public DbSet<Players> Players { get; set; }

        public DbSet<Coaches> Coaches { get; set; }

        public DbSet<BusinessManagers> BusinessManagers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Db.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BusinessManagers businessManagers1 = new BusinessManagers() { BusinessManagerId = 1, Name = "Óscar Ribot", age = 42, Salary = 3 };
            BusinessManagers businessManagers2 = new BusinessManagers() { BusinessManagerId = 2, Name = "Kia Joorabchian", age = 43, Salary = 2 };
            BusinessManagers businessManagers3 = new BusinessManagers() { BusinessManagerId = 3, Name = "Jorge Antun", age = 39, Salary = 1 };


            Clubs clubs1 = new Clubs() { ClubId=1, Name="Real Madrid", NumberOfTrophies=66};
            Clubs clubs2 = new Clubs() { ClubId=2, Name="Barcelona", NumberOfTrophies=75};
            Clubs clubs3 = new Clubs() { ClubId=3, Name="Juventus", NumberOfTrophies=70};


            Coaches coaches1 = new Coaches() { CoachId = 1, Name = "Carlo Ancelotti", age= 62, CoachHireDate= new DateTime(2021, 6, 1), ClubId= clubs1.ClubId, CoachSalary = 10 };
            Coaches coaches2 = new Coaches() { CoachId = 2, Name = "Ronald Koeman", age= 58, CoachHireDate= new DateTime(2020, 8, 19), ClubId= clubs2.ClubId, CoachSalary= 10 };
            Coaches coaches3 = new Coaches() { CoachId = 3, Name = "Massimiliano Allegri", age= 54, CoachHireDate= new DateTime(2021, 7, 1), ClubId= clubs3.ClubId, CoachSalary= 7 };
                            
            

            Players players1 = new Players() { PlayerId = 1, Name = "Karim Benzema", age = 33, ClubId = clubs1.ClubId, Position = "Striker", PlayerSalary = 8, BusinessManagersId=businessManagers1.BusinessManagerId };
            Players players2 = new Players() { PlayerId = 2, Name = "Philippe Coutinho", age = 29, ClubId = clubs2.ClubId, Position = "winger", PlayerSalary = 7, BusinessManagersId = businessManagers2.BusinessManagerId };
            Players players3 = new Players() { PlayerId = 3, Name = "Paulo Dybala", age = 33, ClubId = clubs3.ClubId, Position = "forward", PlayerSalary = 5, BusinessManagersId = businessManagers3.BusinessManagerId };



            //modelBuilder.Entity<Players>(entity =>
            //{
            //    entity.HasOne(Players => Players.BusinessManagers)
            //    .WithMany(BusinessManagers=> BusinessManagers.Players)
            //    .HasForeignKey(Players => Players.BusinessManagersId)
            //    .OnDelete(DeleteBehavior.SetNull);
            //});



           

            modelBuilder.Entity<Clubs>().HasData(clubs1, clubs2, clubs3);
            modelBuilder.Entity<Coaches>().HasData(coaches1, coaches2, coaches3);
            modelBuilder.Entity<Players>().HasData(players1, players2, players3);
            modelBuilder.Entity<BusinessManagers>().HasData(businessManagers1, businessManagers2, businessManagers3);

        }


    }
}
