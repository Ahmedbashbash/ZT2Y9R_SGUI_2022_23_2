using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT2Y9R_HFT_2021221.Models
{
    [Table("Coaches")]
    public class Coaches
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }


        public string Name { get; set; }

        public int age { get; set; }

        public DateTime? CoachHireDate { get; set; }

        public int? CoachSalary { get; set; }

        

        [ForeignKey(nameof(Clubs))]
        public int? ClubId { get; set; }

        [NotMapped]
        public virtual Clubs Club { get; set; }

        public override string ToString()
        {
            return $"{this.CoachId} | {this.Name}, {this.age} years old, Salary: {this.CoachSalary} M GBP, Club: {this.Club.Name}, Hire Date: {this.CoachHireDate}";
        }
    }
}
