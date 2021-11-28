using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT2Y9R_HFT_2021221.Models
{
    [Table("Players")]
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public int? PlayerSalary { get; set; }


        [NotMapped]
        public virtual Clubs Club { get; set; }


        [ForeignKey(nameof(Club))]
        public int ClubId { get; set; }

        
        [NotMapped]
        public virtual BusinessManagers BusinessManagers { get; set; }


        [ForeignKey(nameof(BusinessManagers))]
        public int BusinessManagersId { get; set; }

        

        public override string ToString()
        {
            return $"{this.PlayerId} | {this.Name}, Age: {this.age}, Team: {this.Club.Name}, Postion: {this.Position}, Salary: {this.PlayerSalary}m GBP, Agent: {BusinessManagers.Name}";
        }


    }
}
