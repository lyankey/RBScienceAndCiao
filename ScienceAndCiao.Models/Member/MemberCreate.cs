using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScienceAndCiao.Data;
using ScienceAndCiao.Models.MembershipType;

namespace ScienceAndCiao.Models.Member
{
    public class MemberCreate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsSubscribedToEmails { get; set; }
        public MembershipTypeCreate MembershipTypeCreate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth DD Jan YYYY")]
        public DateTime? Birthdate { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }

    }
}
