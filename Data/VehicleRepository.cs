using Car_delearship.Models;
using Car_delearship.Models.VehicleModels;
using Car_delearship.Models.ViewModel;
using Car_delearship.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Data
{
    public class VehicleRepository : IVehicle
    {
        private readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SelectListItem>> GenerateMakeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var makes = _context.Makes.ToList();

            foreach (Make m in makes)
            {
                items.Add(new SelectListItem()
                {
                    Text = m.MakeName,
                    Value = m.MakeID + ""
                });
            }

            return items;
        }

        public async Task<List<SelectListItem>> GenerateTypeList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "New",
                    Value = "New"
                },
                new SelectListItem()
                {
                    Text = "Used",
                    Value = "Used"
                }
            };
        }

        public async Task<List<SelectListItem>> GenerateBodyStyleList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<BodyStyle> bodyStyles = _context.BodyStyles.ToList();
            foreach (BodyStyle s in bodyStyles)
            {
                items.Add(new SelectListItem()
                {
                    Text = s.Style,
                    Value = s.BodyStyleID + ""
                });
            }

            return items;
        }
        public async Task<List<SelectListItem>> GenerateTransmissionTypeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Transmission> transmissionTypes = _context.Transmissions.ToList();
            foreach (Transmission s in transmissionTypes)
            {
                items.Add(new SelectListItem()
                {
                    Text = s.TransmissionName,
                    Value = s.TransmissionID + ""
                });
            }

            return items;
        }

        public async Task<List<SelectListItem>> GenerateColorList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Color> colors = _context.Colors.ToList();
            foreach (Color c in colors)
            {
                items.Add(new SelectListItem()
                {
                    Text = c.ColorName,
                    Value = c.ColorID + ""
                });
            }

            return items;
        }

        public async Task<List<SelectListItem>> GenerateInteriorList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Interior> interiors = _context.Interiors.ToList();
            foreach (Interior i in interiors)
            {
                items.Add(new SelectListItem()
                {
                    Text = i.InteriorName,
                    Value = i.InteriorID + ""
                });
            }

            return items;
        }

        public async Task<int> AddVehicle(AddEditVehicleViewModel viewModel)
        {
            Vehicle vehicle = new Vehicle();
            //vehicle.StaffID = Manager.CurrentUser.StaffID;
            vehicle.MakeID = viewModel.MakeID;
            vehicle.ModelID = viewModel.ModelID;
            vehicle.InteriorID = viewModel.InteriorID;
           // vehicle.BodyStyle = Manager.BodyStyleRepository.Get(viewModel.BodyStyleID).Style;
            vehicle.Category = viewModel.Type;
            vehicle.Description = viewModel.Description;
            vehicle.SalePrice = viewModel.SalePrice;
            vehicle.MSRP = viewModel.MSRP;
            vehicle.Mileage = viewModel.Mileage;
            vehicle.Year = viewModel.Year;
            vehicle.VIN = viewModel.Vin;
            vehicle.Featured = viewModel.FeatureVehicle;
            vehicle.Transmission = viewModel.transmission;
            vehicle.BodyStyle = "Sedan";
            vehicle.Color = "White";
            
            vehicle.PicturePath = viewModel.PicturePath;
            // vehicle.Transmission =  Manager.TransmissionTypeRepository.Get(viewModel.TransmissionID).TransmissionName;
           //  vehicle.Color = Manager.ColorRepository.Get(viewModel.ColorID).ColorName;

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return vehicle.VehicleID;
        }

        public async Task<List<MakeViewModel>> GenerateMakeVMList()
        {
            List<MakeViewModel> model = new List<MakeViewModel>();
            List<Make> makes = _context.Makes.ToList();
            foreach (Make make in makes)
            {
                model.Add(new MakeViewModel()
                {
                    Make = make,
                    //StaffMemberEmail = StaffRepository.GetById(make.StaffId).Email
                });
            }

            return model;
        }

        public async Task<bool> AddMake(Make make)
        {
            _context.Makes.Add(make);
            var res = _context.SaveChanges();
            return true;
        }
        public async Task<bool> AddModel(Model model)
        {
            _context.Models.Add(model);
            var res = _context.SaveChanges();
            return true;
        }

        public async Task<List<ModelViewModel>> GenerateModelVMList()
        {
            List<ModelViewModel> viewModels = new List<ModelViewModel>();
            List<Model> models = _context.Models.ToList();
            foreach (Model model in models)
            {
                viewModels.Add(new ModelViewModel()
                {
                    Model = model,
                    Make =  _context.Makes.Where(x=>x.MakeID== model.MakeID).Select(x=>x.MakeName).SingleOrDefault(),   
                    BodyStyle = _context.BodyStyles.Where(x=>x.BodyStyleID==model.BodyStyleID).Select(x=>x.Style).SingleOrDefault(),
                 //   StaffMemberEmail = StaffRepository.GetById(model.StaffId).Email
                });;
            }

            return viewModels;
        }

        public async Task<bool> AddImages(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();

            return true;
        }

        public VehicleViewModel GetVehicle(int id )
        {

            var results = (from d in _context.Vehicles
                           join m in _context.Makes on d.MakeID equals m.MakeID
                           join md in _context.Models on d.ModelID equals md.ModelID
                           join i in _context.Images on d.VehicleID equals i.VehicleId
             
                           where d.VehicleID == id

                           select new VehicleViewModel
                           {
                               Style = d.BodyStyle,
                               ModelName = md.ModelName,
                               makeName = m.MakeName,
                               image = i.path,
                               description = d.Description,
                               salesPrice = d.SalePrice,
                               Mileage = d.Mileage,
                               year = d.Year,
                               Transmission = d.Transmission,
                               catogory = d.Category,
                               Color = d.Color
                           }).FirstOrDefault();

            return results;

        }

        public  int GetMakeID(string Make)
        {
            return _context.Makes.Where(x => x.MakeName == Make).Select(x => x.MakeID).FirstOrDefault();
        }

        public  List<Model> GetAllModelByMake(int id)
        {
            return _context.Models.Where(x => x.MakeID == id).ToList();
        }

        public List<string> GetImagePaths(int vehicleID)
        {
            return _context.Images.Where(x => x.VehicleId == vehicleID).Select(x => x.path).ToList();
        }

        public List<Vehicle> getAllVehicle()
        {
            return _context.Vehicles.ToList();
        }



    }
}
