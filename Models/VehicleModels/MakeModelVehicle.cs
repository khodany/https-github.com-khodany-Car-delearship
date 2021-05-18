using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.VehicleModels
{
    public class MakeModelVehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public int MakeID { get; set; }
    }
}
