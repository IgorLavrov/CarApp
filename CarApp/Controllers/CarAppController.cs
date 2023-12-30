using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using CarApp.Data;

using CarApp.Models.CarApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    
    public class CarAppController : Controller
    {
        private readonly CarAppContext _context;
        private readonly ICarAppServices _CarAppServices;
        
        public CarAppController(CarAppContext context,ICarAppServices CarAppServices)
        {
            _context = context;
               _CarAppServices= CarAppServices;
            
        }


        [HttpGet]
        public IActionResult Index1()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.BuiltAt)
                .Select(x => new CarAppIndexViewModel
                {
                    Id = x.Id,
                    Owner = x.Owner,
                    Model = x.Model,
                    VinNumber = x.VinNumber,
                    TypeOfFuel = x.TypeOfFuel,
                    CarWeight = x.CarWeight,
                    RegistrationNumber = x.RegistrationNumber,
                    BuiltAt = x.BuiltAt,
                    RegistratedAt = x.RegistratedAt,
                    Color = x.Color,
                    EngineCapacity = x.EngineCapacity,
                    NumberOfCarDoors = x.NumberOfCarDoors,
                    Brand = x.Brand,
                });

            return View(result);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.BuiltAt)
                .Select(x => new CarAppIndexViewModel
                {
                    Id = x.Id,
                    Owner = x.Owner,
                    Model = x.Model,
                    VinNumber = x.VinNumber,
                    TypeOfFuel = x.TypeOfFuel,
                    CarWeight = x.CarWeight,
                    RegistrationNumber = x.RegistrationNumber,
                    BuiltAt = x.BuiltAt,
                    RegistratedAt = x.RegistratedAt,
                    Color = x.Color,
                    EngineCapacity = x.EngineCapacity,
                    NumberOfCarDoors = x.NumberOfCarDoors,
                    Brand = x.Brand,
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var cars = await _CarAppServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }


            var vm = new CarAppDetailsViewModel();

            vm.Id = cars.Id;
            vm.Owner = cars.Owner;
            vm.Model = cars.Model;
            vm.TypeOfFuel = cars.TypeOfFuel;
            vm.VinNumber = cars.VinNumber;
            vm.TypeOfFuel = cars.TypeOfFuel;
            vm.Color = cars.Color;
            vm.CarWeight = cars.CarWeight;
            vm.Brand = cars.Brand;
            vm.NumberOfCarDoors = cars.NumberOfCarDoors;
            vm.EngineCapacity = cars.EngineCapacity;
            vm.RegistrationNumber = cars.RegistrationNumber;
            vm.BuiltAt = cars.BuiltAt;
            vm.RegistratedAt = cars.RegistratedAt;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarAppCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CarAppCreateUpdateViewModel vm)
        {
            var dto = new CarAppDto()
            {


                Id = vm.Id,
                Owner = vm.Owner,
                Model = vm.Model,
                TypeOfFuel = vm.TypeOfFuel,
                VinNumber = vm.VinNumber,
                Brand = vm.Brand,
                Color = vm.Color,
                RegistrationNumber = vm.RegistrationNumber,
                EngineCapacity = vm.EngineCapacity,
                NumberOfCarDoors = vm.NumberOfCarDoors,
                CarWeight = vm.CarWeight,
                BuiltAt = vm.BuiltAt,
                RegistratedAt = vm.RegistratedAt,

            };

            var result = await _CarAppServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cars = await _CarAppServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            var vm = new CarAppCreateUpdateViewModel();


            vm.Id = cars.Id;
            vm.Owner = cars.Owner;
            vm.Model = cars.Model;
            vm.TypeOfFuel = cars.TypeOfFuel;
            vm.VinNumber = cars.VinNumber;
            vm.Brand = cars.Brand;
            vm.Color = cars.Color;
            vm.RegistrationNumber = cars.RegistrationNumber;
            vm.NumberOfCarDoors = cars.NumberOfCarDoors;
            vm.CarWeight = cars.CarWeight;
            vm.EngineCapacity = cars.EngineCapacity;
            vm.BuiltAt = cars.BuiltAt;
            vm.RegistratedAt = cars.RegistratedAt;


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarAppCreateUpdateViewModel vm)
        {

            var dto = new CarAppDto()
            {
                Id = vm.Id,
                Owner = vm.Owner,
                Model = vm.Model,
                TypeOfFuel = vm.TypeOfFuel,
                VinNumber = vm.VinNumber,
                Brand = vm.Brand,
                Color = vm.Color,
                RegistrationNumber = vm.RegistrationNumber,
                NumberOfCarDoors = vm.NumberOfCarDoors,
                CarWeight = vm.CarWeight,
                EngineCapacity = vm.EngineCapacity,

                BuiltAt = vm.BuiltAt,
                RegistratedAt = vm.RegistratedAt,

            };


            var result = await _CarAppServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _CarAppServices.GetAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            var vm = new CarAppDeleteViewModel();


            vm.Id = cars.Id;
            vm.Owner = cars.Owner;
            vm.Model = cars.Model;
            vm.CarWeight = cars.CarWeight;
            vm.VinNumber = cars.VinNumber;
            vm.Color = cars.Color;
            vm.EngineCapacity = cars.EngineCapacity;
            vm.Brand = cars.Brand;
            vm.NumberOfCarDoors = cars.NumberOfCarDoors;
            vm.RegistrationNumber = cars.RegistrationNumber;
            vm.TypeOfFuel = cars.TypeOfFuel;

            vm.BuiltAt = cars.BuiltAt;
            vm.RegistratedAt = cars.RegistratedAt;

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var CarId = await _CarAppServices.Delete(id);

            if (CarId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
