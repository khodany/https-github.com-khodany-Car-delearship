using Car_delearship.Models.VehicleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.ViewModel
{
    public class VehicleViewModel
    {
        public int VehicleId { set; get; }
        public Vehicle Vehicle { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public Interior Interior { get; set; }
        public List<VehicleViewModel> Vehicles { get; set; }
        public Image Image { set; get; }

        public string Style { get; set; }
        public string ModelName { get; set; }
        public string makeName { get; set; }
        public string image { set; get; }
        public string description { set; get; }
        public decimal salesPrice { set; get; }
        public int year { get; set; }
        public string catogory { get; set; }
        public string Featured { set; get; }
        public string Transmission { set; get; }
        public string Color { set; get; }
        public int Mileage { get; set; }
        public int Totalitems { set; get; }
        public int PageNumber { set; get; }
        public int PageSize { set; get; }

        public List<string> ImagesPathes { set; get; }

        //public PurchaseModel PurchaseModel { get; set; }
    }
}
