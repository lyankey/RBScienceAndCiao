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
        public int KitId { get; set; }
        [ForeignKey(nameof(KitId))]
        public virtual Kit Kit { get; set; }

        [Required]
        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public List<int> KitIds { get; set; }

    }
}
