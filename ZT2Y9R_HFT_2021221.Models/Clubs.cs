using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT2Y9R_HFT_2021221.Models
{
    [Table("Clubs")]
    public class Clubs
    {
        public Clubs()
        {
            this.Players = new HashSet<Players>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }


        [Required]
        public string Name { get; set; }


        public int NumberOfTrophies { get; set; }




        public virtual ICollection<Coaches> Coaches { get; }



        public virtual ICollection<Players> Players { get; }


        public override string ToString()
        {
            return $"{this.ClubId} | {this.Name}, has {this.NumberOfTrophies} trophies, and has {this.Players.Count} players, and they have {Coaches.Count} Coach.";
        }

    }
}
