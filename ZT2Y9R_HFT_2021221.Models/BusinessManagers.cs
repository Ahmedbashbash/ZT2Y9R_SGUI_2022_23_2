using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT2Y9R_HFT_2021221.Models
{
    [Table("BusinessManagers")]
    public class BusinessManagers
    {
        public BusinessManagers()
        {
            this.Players = new HashSet<Players>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessManagerId { get; set; }


        public string Name { get; set; }


        public int age { get; set; }

        public int? Salary { get; set; }        

        [NotMapped]
        public virtual ICollection<Players> Players { get; set; }


        public override string ToString()
        {
            return $"{this.BusinessManagerId} | {this.Name}, {this.Players.Count} Clients,  Salary: {this.Salary}m GBP";
        }


    }
}
