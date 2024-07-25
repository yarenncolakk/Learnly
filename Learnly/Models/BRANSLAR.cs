using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learnly.Models
{
    [Table("BRANSLAR")]
    public class BRANSLAR
    {
        [Key]
        public int brans_id { get; set; }
        public string brans_adi { get; set; }


    }
}