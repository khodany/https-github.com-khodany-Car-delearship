using Car_delearship.Models.VehicleModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.ViewModel
{
    public class ModelListViewModel
    {
        public Model NewModel { get; set; }
        public int SelectedMakeID { get; set; }
        public int SelectedBodyStyleID { get; set; }
        public List<SelectListItem> MakesList = new List<SelectListItem>();
        public List<SelectListItem> BodyStylesList = new List<SelectListItem>();
        public List<ModelViewModel> ViewModels { get; set; }
    }
}
