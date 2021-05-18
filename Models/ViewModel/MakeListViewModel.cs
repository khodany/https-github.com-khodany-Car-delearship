using Car_delearship.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.ViewModel
{
    public class MakeListViewModel
    {
        public Make NewMake { get; set; }
        public List<MakeViewModel> ViewModels = new List<MakeViewModel>();
    }
}
