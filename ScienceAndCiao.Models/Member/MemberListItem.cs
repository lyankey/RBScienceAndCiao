using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models.Member
{
    public class MemberListItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Member Name")]
        public string Member { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
