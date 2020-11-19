using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models.Rental
{
    public class RentalListItem
    {
        public int RentalId { get; set; }
        public int KitId { get; set; }
        public int MemberId { get; set; }
        [Display(Name = "Date Rented")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Date Returned")]
        public DateTime EndDate { get; set; }
        //public List<int> KitIds { get; set; }
    }
}
