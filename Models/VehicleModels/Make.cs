using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.VehicleModels
{
    public class Make
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }

        public DateTime DateAdded { get; set; }
        public int StaffId { get; set; }
    }
}
