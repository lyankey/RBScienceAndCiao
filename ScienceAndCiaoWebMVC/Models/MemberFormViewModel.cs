using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceAndCiaoWebMVC.Models
{
    public class MemberFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Member Member { get; set; }
    }
}