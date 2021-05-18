using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models
{
    public class Cars
    {
        [Key]
        public int CarID { get; set; }
        public string CarName { set; get; }
    }
}
