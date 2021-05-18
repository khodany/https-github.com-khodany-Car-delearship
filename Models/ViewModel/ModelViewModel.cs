using Car_delearship.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.ViewModel
{
    public class ModelViewModel
    {
        public string Make { get; set; }
        public string BodyStyle { get; set; }
        public Model Model { get; set; }
        public string StaffMemberEmail { get; set; }
    }
}
