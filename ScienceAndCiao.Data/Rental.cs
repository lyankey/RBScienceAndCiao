using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Data
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Member Member { get; set; }

        [Required]
        public byte KitId { get; set; }
        [ForeignKey(nameof(KitId))]
        public virtual Kit Kit { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
