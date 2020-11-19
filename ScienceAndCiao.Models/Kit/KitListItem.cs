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
    public class KitListItem
    {

        [Index(IsUnique = true)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Branch { get; set; }
        public DateTimeOffset DateAdded { get; set; }

    }
}
