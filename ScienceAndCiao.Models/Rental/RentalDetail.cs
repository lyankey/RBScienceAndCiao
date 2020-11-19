using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models.Rental
{
    public class RentalDetail
    {
        public int Id { get; set; }
        public int KitId { get; set; }
        public  KitDetail Kit { get; set; }
        public int MemberId { get; set; }
        public string  Member { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public List<int> KitIds { get; set; }
    }
}
