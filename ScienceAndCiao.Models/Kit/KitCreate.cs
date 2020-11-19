using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndCiao.Models.Kit
{
    public class KitCreate
    {
        [Required]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int LengthMinutes { get; set; }
        [Required]
        public Grade Grade { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

