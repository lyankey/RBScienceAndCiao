using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Data
{
    public enum Grade
    {
        Preschool = 1,
        [Description("Lower Elementary (1st-3rd)")]
        LowerElementary,
        [Description("Upper Elementary (4th-5th)")]
        UpperElementary,
        [Description("Middle School")]
        MiddleSchool,
        [Description("High School")]
        HighSchool
    }

    public class KitDetail : Kit
    {

        [Key]
        public int KitDetail_Id { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int LengthMinutes { get; set; }
        [Required]
        public Grade Grade { get; set; }


    }
}
