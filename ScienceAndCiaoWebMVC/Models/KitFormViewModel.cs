using ScienceAndCiao.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScienceAndCiaoWebMVC.Models
{
    public class KitFormViewModel
    {
        public IEnumerable<Branch> Branches { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Branch")]
        [Required]
        public byte? BranchId { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Kit" : "New Kit";
            }
        }

        public KitFormViewModel()
        {
            Id = 0;
        }

        public KitFormViewModel(Kit kit)
        {
            Id = kit.Id;
            Name = kit.Name;
            DateAdded = kit.DateAdded;
            BranchId = kit.BranchId;
        }
    }
}