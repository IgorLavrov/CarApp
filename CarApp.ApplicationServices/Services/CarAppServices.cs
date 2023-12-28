using CarApp.Core.Domain;
using CarApp.Core.Dto;
using CarApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.ApplicationServices.Services
{
    public class CarAppServices
    {
        private readonly CarAppContext _context;

        public CarAppServices(CarAppContext context)
        {
            _context = context;
        }

        public async Task<CarsApp> Create(CarAppDto dto)
        {
            CarsApp cars = new();
            cars.Id = Guid.NewGuid();
            cars.Owner = dto.Owner;
            cars.Model = dto.Model;
            cars.Color = dto.Color;
            cars.Brand = dto.Brand;
            cars.RegistrationNumber = dto.RegistrationNumber;
            cars.NumberOfCarDoors = dto.NumberOfCarDoors;
            cars.CarWeight = dto.CarWeight;
            cars.EngineCapacity = dto.EngineCapacity;
            cars.TypeOfFuel = dto.TypeOfFuel;
            cars.VinNumber = dto.VinNumber;
            cars.BuiltAt = DateTime.Now;
            cars.RegistratedAt = DateTime.Now;

            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();

            return cars;

        }

        public async Task<CarsApp> Update(CarAppDto dto)
        {
            var domain = new CarsApp()
            {
                Id = dto.Id,
                Owner = dto.Owner,
                Model = dto.Model,
                Brand = dto.Brand,
                VinNumber = dto.VinNumber,
                Color = dto.Color,
                EngineCapacity = dto.EngineCapacity,
                TypeOfFuel = dto.TypeOfFuel,
                CarWeight = dto.CarWeight,
                RegistrationNumber = dto.RegistrationNumber,
                NumberOfCarDoors = dto.NumberOfCarDoors,

                BuiltAt = dto.BuiltAt,
                RegistratedAt = DateTime.Now,
            };

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
            }


        public async Task<CarsApp> GetAsync(Guid id)
        {
            var result=await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<CarsApp>Delete(Guid id)
        {
            var result =await _context.Cars
                .FirstOrDefaultAsync (x => x.Id == id);
            _context.Cars.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

    }
}
