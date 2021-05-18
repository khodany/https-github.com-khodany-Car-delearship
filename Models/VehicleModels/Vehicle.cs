using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Models.VehicleModels
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int StaffID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public int InteriorID { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public bool Featured { get; set; }
        public string Category { get; set; }
        public bool Sold { get; set; } = false;

        [NotMapped]
        public string Style { get; set; }
        [NotMapped]
        public string ModelName { get; set; }
        [NotMapped]
        public string makeName { get; set; }
        [NotMapped]
        public string image { get; set; }
        [NotMapped]
        public string description { get; set; }
        [NotMapped]
        public decimal salesPrice { get; set; }
        [NotMapped]
        public int mileage { get; set; }
        [NotMapped]
        public int year { get; set; }
        [NotMapped]
        public string transmission { get; set; }
        [NotMapped]
        public string catogory { get; set; }
        [NotMapped]
        public string color { get; set; }
        [NotMapped]
        public List<string> Pathses { set; get; }
    }
}
