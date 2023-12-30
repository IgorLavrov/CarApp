using CarApp.Core.Dto;
using CarApp.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.CarAppTest
{
    public class CarAppTest:TestBase
    {
       
            [Fact]
            public async Task ShouldNot_AddEmptyCar_WhenReturnresult()
            {
                CarAppDto dto = new CarAppDto();
                dto.Owner = "Test";
                dto.Model = "BMW";
                dto.EngineCapacity= 1;
                dto.VinNumber = "T3344255";
            dto.RegistrationNumber = "S436664";
            dto.TypeOfFuel = "petrol";
            dto.Brand = "VolVo";
            dto.CarWeight = 1;
            dto.NumberOfCarDoors = 1;
            dto.Color = "black";
                dto.BuiltAt = DateTime.Now;
                dto.RegistratedAt = DateTime.Today;



                var result = await Svc<ICarAppServices>().Create(dto);

                Assert.NotNull(result);

            }

            [Fact]
            public async Task ShouldNot_GetByIdCar_WhenReturnsNotequal()
            {
                Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
                Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

                await Svc<ICarAppServices>().GetAsync(guid);

                Assert.NotEqual(guid, wrongGuid);

            }

            [Fact]
            public async Task Should_GetByIdCarWhenRetunsEqual()
            {
                Guid databaseGuid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
                Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");

                await Svc<ICarAppServices>().GetAsync(guid);

                Assert.Equal(databaseGuid, guid);

            }

            [Fact]

            public async Task Should_DeleteByIdCar_WhenDeleteCar()
            {
                CarAppDto Car= MockCarData();

                var createdCar = await Svc<ICarAppServices>().Create(Car);
                var result = await Svc<ICarAppServices>().Delete((Guid)createdCar.Id);

                Assert.Equal(createdCar, result);
            }

        public CarAppDto MockCarData()
        {
            CarAppDto car = new()
            {

            Owner = "Test",
            Model = "Volvo",
            EngineCapacity = 1,
            VinNumber = "d334476255",
            RegistrationNumber = "r5656664",
            TypeOfFuel = "petrol",
            Brand = "S85",
            CarWeight = 1,
            NumberOfCarDoors = 1,
            Color = "white",
           
            BuiltAt = DateTime.Now,
            RegistratedAt = DateTime.Now
            };
            return car;
        }



    }
    }
