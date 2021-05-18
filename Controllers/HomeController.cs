using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Car_delearship.Models;
using Car_delearship.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Car_delearship.Models.ViewModel;
using cloudscribe.Pagination.Models;
using Car_delearship.Data;
using Microsoft.EntityFrameworkCore;
using Car_delearship.Models.VehicleModels;

namespace Car_delearship.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicle _vehicle;
        private readonly IConfiguration _config;
        private IWebHostEnvironment _Environment;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IVehicle repo, IConfiguration config, IWebHostEnvironment Environment, ApplicationDbContext context)
        {
            _logger = logger;
            _vehicle = repo;
            _config = config;
            _Environment = Environment;
            _context = context;
        }

        public async Task<IActionResult> Index(int PageNumber = 1, int PageSize = 3)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;
            ViewBag.Tree = "~/images/Colorlogo.jpg";
            var model = new VehicleViewModel();
            var vehicle = (from d in _context.Vehicles
                           join m in _context.Makes on d.MakeID equals m.MakeID
                           join md in _context.Models on d.ModelID equals md.ModelID
                           join i in _context.Images on d.VehicleID equals i.VehicleId

                           select new Vehicle
                           {
                               VehicleID = d.VehicleID,
                               Style = d.BodyStyle,
                               ModelName = md.ModelName,
                               makeName = m.MakeName,
                               image = i.path,
                               description = d.Description,
                               salesPrice = d.SalePrice,
                               Mileage = d.Mileage,
                               year = d.Year,
                               transmission = d.Transmission,
                               catogory = d.Category,
                               color = d.Color
                           }).Skip(ExcludeRecords).Take(PageSize);

           // var imagesPahts = _vehicle.GetImagePaths(vehicle.)

            var result = new PagedResult<Vehicle>
            {
                Data = await vehicle.AsNoTracking().ToListAsync(),
                TotalItems = await _context.Vehicles.CountAsync(),
                PageNumber = PageNumber,
                PageSize = PageSize

            };




            return View(result);
        }

        public IActionResult VehicleDetails(int id)
        {
            var images = _vehicle.GetImagePaths(id);
            var vehicle = _vehicle.GetVehicle(id);
            var model = new VehicleViewModel()
            {
                ImagesPathes = images,
                VehicleId = vehicle.VehicleId,
                Style = vehicle.Style,
                ModelName = vehicle.ModelName,
                makeName = vehicle.makeName,
                description = vehicle.description,
                salesPrice = vehicle.salesPrice,
                Mileage = vehicle.Mileage,
                year = vehicle.year,
                Transmission = vehicle.Transmission,
                catogory = vehicle.catogory,
                Color = vehicle.Color
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Showrooom(int PageNumber = 1, int PageSize = 2)
        {
            int ExcludeRecords = (PageSize * PageNumber) - PageSize;
            ViewBag.Tree = "~/images/Colorlogo.jpg";
            var model = new VehicleViewModel();
            var vehicle = (from d in _context.Vehicles
                           join m in _context.Makes on d.MakeID equals m.MakeID
                           join md in _context.Models on d.ModelID equals md.ModelID
                           join i in _context.Images on d.VehicleID equals i.VehicleId

                           select new Vehicle
                           {
                               VehicleID = d.VehicleID,
                               Style = d.BodyStyle,
                               ModelName = md.ModelName,
                               makeName = m.MakeName,
                               image = i.path,
                               description = d.Description,
                               salesPrice = d.SalePrice,
                               Mileage = d.Mileage,
                               year = d.Year,
                               transmission = d.Transmission,
                               catogory = d.Category,
                               color = d.Color
                           }).Skip(ExcludeRecords).Take(PageSize);

            // var imagesPahts = _vehicle.GetImagePaths(vehicle.)

            var result = new PagedResult<Vehicle>
            {
                Data = await vehicle.AsNoTracking().ToListAsync(),
                TotalItems = await _context.Vehicles.CountAsync(),
                PageNumber = PageNumber,
                PageSize = PageSize

            };

            return View(result);
        }
    }
}
