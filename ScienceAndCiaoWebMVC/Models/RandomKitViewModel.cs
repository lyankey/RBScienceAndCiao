using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScienceAndCiaoWebMVC.Models
{
    public class RandomKitViewModel
    {
        public Kit Kit { get; set; }
        public List<Member> Members { get; set; }
    }
}