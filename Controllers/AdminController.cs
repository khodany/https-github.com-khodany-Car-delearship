using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Car_delearship.Data;
using Car_delearship.Models;
using Car_delearship.Models.VehicleModels;
using Car_delearship.Models.ViewModel;
using Car_delearship.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Car_delearship.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
      

        private readonly IVehicle _vehicle;
        private readonly IConfiguration _config;
        private IWebHostEnvironment _Environment;
        public AdminController(IVehicle repo, IConfiguration config, IWebHostEnvironment Environment)
        {
            _vehicle = repo;
            _config = config;
            _Environment = Environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Makes()
        {
            List<MakeViewModel> model = await _vehicle.GenerateMakeVMList();
            MakeListViewModel viewModel = new MakeListViewModel();
            viewModel.ViewModels = model;
            viewModel.NewMake = new Make();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Makes(MakeListViewModel model)
        {
            if (string.IsNullOrEmpty(model.NewMake.MakeName))
            {
                ModelState.AddModelError("", "Make must have a valid make name.");
                model.ViewModels = await _vehicle.GenerateMakeVMList();
                return View(model);
            }
            Make make = new Make();
            make.MakeName = model.NewMake.MakeName;
            make.DateAdded = DateTime.Today;
            //  make.StaffId = Manager.CurrentUser.StaffID;
            await _vehicle.AddMake(make);
          
            model.NewMake = new Make();
            model.ViewModels = await _vehicle.GenerateMakeVMList();

            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> AddVehicleAsync()
        {
            AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel
            {
                Makes = await _vehicle.GenerateMakeList(),
                BodyStyles = await _vehicle.GenerateBodyStyleList(),
                Transmissions = await _vehicle.GenerateTransmissionTypeList(),
                Colors = await _vehicle.GenerateColorList(),
                Interiors = await _vehicle.GenerateInteriorList(),
                Types = await _vehicle.GenerateTypeList()

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddVehicleAsync(AddEditVehicleViewModel model, List<IFormFile> attachment)
        {
            SetAddEditVehicleValidations(model, out bool valid);

            model.ModelID = Convert.ToInt32(Request.Form["modelID"].ToString().Substring(Request.Form["modelID"].ToString().IndexOf(',') + 1));


            //if (!valid)
            //{
            //    AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel
            //    {
            //        Makes = await _vehicle.GenerateMakeList(),
            //        BodyStyles = await _vehicle.GenerateBodyStyleList(),
            //        Transmissions = await _vehicle.GenerateTransmissionTypeList(),
            //        Colors = await _vehicle.GenerateColorList(),
            //        Interiors = await _vehicle.GenerateInteriorList()

            //    };



            //    return View(viewModel);
            //}
            var noDupsList = attachment.GroupBy(x => x).Where(g => g.Count() ==1).Select(y => y.Key).OrderByDescending(x => x.FileName).ToList();









            var res =  await _vehicle.AddVehicle(model);
            UploadedFile(noDupsList, res);

            return View();

        }

        [HttpGet]
        public async Task<ActionResult> Models()
        {
            List<ModelViewModel> model = await _vehicle.GenerateModelVMList();
            ModelListViewModel viewModel = new ModelListViewModel();
            viewModel.NewModel = new Model();
            viewModel.ViewModels = model;
            viewModel.MakesList = await _vehicle.GenerateMakeList();
            viewModel.BodyStylesList = await _vehicle.GenerateBodyStyleList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Models(ModelListViewModel model)
        {
            if (string.IsNullOrEmpty(model.NewModel.ModelName))
            {
                ModelState.AddModelError("", "Model must have a valid model name.");
                model.ViewModels = await _vehicle.GenerateModelVMList();
                model.MakesList = await _vehicle.GenerateMakeList();
                model.BodyStylesList = await _vehicle.GenerateBodyStyleList();
                return View(model);
            }
            Model newModel = new Model();
            newModel.MakeID = model.SelectedMakeID;
            newModel.BodyStyleID = model.SelectedBodyStyleID;
            newModel.ModelName = model.NewModel.ModelName;
          //  newModel.StaffId = Manager.CurrentUser.StaffID;
            newModel.DateAdded = DateTime.Today;
            await _vehicle.AddModel(newModel);
            model.NewModel = new Model();
            model.MakesList = await _vehicle.GenerateMakeList();
            model.ViewModels = await _vehicle.GenerateModelVMList();
            model.BodyStylesList = await _vehicle.GenerateBodyStyleList();
            return View(model);
        }

        private void SetAddEditVehicleValidations(AddEditVehicleViewModel model, out bool valid)
        {
            const int newMileageMax = 1000;
            const int minimumYear = 2000;
            valid = true;

            if (!string.IsNullOrEmpty(model.Type) && model.Mileage >= 0)
            {
                if (model.Type.ToLower().Equals("new") && model.Mileage > newMileageMax)
                {
                    ModelState.AddModelError("", "New vehicles cannot have a mileage over " + newMileageMax + ".");
                    valid = false;
                }
                if (model.Type.ToLower().Equals("used") && model.Mileage <= newMileageMax)
                {
                    ModelState.AddModelError("", "Used vehicles must have a mileage greater than" + newMileageMax + ".");
                    valid = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(model.Type))
                {
                    ModelState.AddModelError("", "Vehicle must have a type (new/used)");
                }

                if (model.Mileage < 0)
                {
                    ModelState.AddModelError("", "Vehicle must have a mileage of 0 or higher.");
                }
            }
            if (string.IsNullOrEmpty(model.Vin))
            {
                ModelState.AddModelError("", "Vehicle must have a valid VIN #.");
                valid = false;
            }
            if (model.MSRP <= 0)
            {
                ModelState.AddModelError("", "Vehicle MSRP must be a positive number greater than 0.");
                valid = false;
            }
            if (model.SalePrice <= 0 || model.SalePrice > model.MSRP)
            {
                if (model.SalePrice <= 0)
                    ModelState.AddModelError("", "Vehicle sale price must be a positive number greater than 0.");
                else
                    ModelState.AddModelError("", "Vehicle sale price cannot be greater than MSRP.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError("", "Vehicle must have a description.");
                valid = false;
            }

            int latestYear = (DateTime.Today.Year + 1);
            if (model.Year < minimumYear || model.Year > latestYear)
            {
                ModelState.AddModelError("", "Vehicle year must be between " + minimumYear + " and " + latestYear + ".");
                valid = false;
            }
            //if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            //{
            //    if (!string.IsNullOrEmpty(model.UploadedFile.FileName))
            //    {
            //        string path = Path.Combine(Server.MapPath("~/Content/images"),
            //            Path.GetFileName(model.UploadedFile.FileName));

            //        model.UploadedFile.SaveAs(path);
            //        model.PicturePath = "/Content/images/" + model.UploadedFile.FileName;
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Uploaded image had an invalid file name.");
            //        valid = false;
            //    }
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(model.PicturePath))
            //    {
            //        ModelState.AddModelError("", "Vehicle must have an image.");
            //        valid = false;
            //    }
            //}

        }

        private void UploadedFile(List<IFormFile> model, int vehicleID)
        {
            string uniqueFileName = null;
            string filePath = string.Empty;
            string tempFile  = "";

            if (model != null)
            {

                foreach(var images in model)
                {
                    if (images.FileName == tempFile)
                        continue;

             
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + images.FileName;
              
                     filePath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Vehicle")).Root + $@"\{uniqueFileName}";



                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        images.CopyTo(fileStream);
                    }

                    var image = new Image
                    {
                        VehicleId = vehicleID,
                        path = filePath
                    };

                    _vehicle.AddImages(image); //Add Path

                    tempFile = images.FileName;

                }

            }
          


     
        }

        public ActionResult ModelCheck(string selectedMake) //HCare-956
        {
            var makeId =   _vehicle.GetMakeID(selectedMake);
     
            List<Model> model =  _vehicle.GetAllModelByMake(makeId);

            return Ok(model);

          
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            AddEditVehicleViewModel model = new AddEditVehicleViewModel();
            model.Vehicles = _vehicle.getAllVehicle();

            return View(model);
        }
    }
}
