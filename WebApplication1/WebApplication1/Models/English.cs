using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("English")]
    public class English
    {
        public long Id { get; set; }
        public string word { get; set; }
        
    }
}
