using Car_delearship.Models.VehicleModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.ViewModel
{
    public class AddEditVehicleViewModel
    {
        public List<SelectListItem> Makes = new List<SelectListItem>();
        public List<SelectListItem> BodyStyles = new List<SelectListItem>();
        public List<SelectListItem> Transmissions = new List<SelectListItem>();
        public List<SelectListItem> Colors = new List<SelectListItem>();
        public List<SelectListItem> Interiors = new List<SelectListItem>();
        public List<SelectListItem> Types = new List<SelectListItem>();
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int BodyStyleID { get; set; }
        public int TransmissionID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public string Type { get; set; }
        public IFormFile[] UploadedFile { get; set; }
        public bool FeatureVehicle { get; set; } = false;
        public string ViewModelType { get; set; }
        public string transmission { set; get; }
        public string Color { set; get; }
        public string bodystyle { set; get; }

        public List<Vehicle> Vehicles { set; get; }
    }
}
