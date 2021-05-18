using Car_delearship.Models;
using Car_delearship.Models.VehicleModels;
using Car_delearship.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_delearship.Repository
{
    public interface IVehicle
    {
        Task<List<SelectListItem>> GenerateMakeList();
        Task<List<SelectListItem>>GenerateTypeList();
        Task<List<SelectListItem>> GenerateBodyStyleList();
        Task<List<SelectListItem>> GenerateTransmissionTypeList();
        Task<List<SelectListItem>> GenerateColorList();
        Task<List<SelectListItem>> GenerateInteriorList();
        Task<int> AddVehicle(AddEditVehicleViewModel model);
        Task<List<MakeViewModel>> GenerateMakeVMList();
        Task<bool> AddMake(Make make);
        Task<bool> AddModel(Model model);
        Task<List<ModelViewModel>> GenerateModelVMList();
        Task<bool> AddImages(Image image);
        VehicleViewModel GetVehicle(int id);
        int GetMakeID(string Make);
        List<Model> GetAllModelByMake(int id);

        List<string> GetImagePaths(int vehicleID);
        List<Vehicle> getAllVehicle();
    }
}
