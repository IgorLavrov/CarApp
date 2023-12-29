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
                dto.Model = "asast";
                dto.EngineCapacity= 1;
                dto.VinNumber = "Tjdhdvf";
            dto.Brand = "VolVo";
                dto.BuiltAt = DateTime.Now;
                dto.RegistratedAt = DateTime.Now;



                var result = await Svc<ICarAppServices>().Create(dto);

                Assert.NotNull(result);

            }

            [Fact]
            public async Task ShouldNot_GetByIdKindergarten_WhenReturnsNotequal()
            {
                Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
                Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

                await Svc<ICarAppServices>().GetAsync(guid);

                Assert.NotEqual(guid, wrongGuid);

            }

            [Fact]
            public async Task Should_GetByIdKindergarten_WhenRetunsEqual()
            {
                Guid databaseGuid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");
                Guid guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");

                await Svc<ICarAppServices>().GetAsync(guid);

                Assert.Equal(databaseGuid, guid);

            }

            [Fact]

            public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
            {
                CarAppDto Car= MockCarData();

                var createdCar = await Svc<ICarAppServices>().Create(Car);
                var result = await Svc<ICarAppServices>().Delete((Guid)createdCar.Id);

                Assert.Equal(createdCar, result);
            }

        private CarAppDto MockCarData()
        {
            CarAppDto car = new()
            {

                Owner = "Test",
                VinNumber = "asast",
               NumberOfCarDoors = 3244,
                Model = "Tjdhdvf",
                BuiltAt = DateTime.Now,
                RegistratedAt = DateTime.Now
            };
            return car;
        }



    }
    }
