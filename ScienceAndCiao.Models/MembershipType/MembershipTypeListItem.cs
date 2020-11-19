using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models.MembershipType
{
    class MembershipTypeListItem
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
