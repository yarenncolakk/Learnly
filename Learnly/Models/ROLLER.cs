using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("ROLLER")]
    public class ROLLER
    {
        [Key]
        public int rol_id { get; set; }
        public string rol_adi { get; set; }
    }
}