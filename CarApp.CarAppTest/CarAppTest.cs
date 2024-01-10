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
                Guid guid = Guid.Parse("c8201505-888b-4190-b3c6-cc10e4acd26c");
                Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

                await Svc<ICarAppServices>().GetAsync(guid);

                Assert.NotEqual(guid, wrongGuid);

            }

            [Fact]
            public async Task Should_GetByIdCarWhenRetunsEqual()
            {
                Guid databaseGuid = Guid.Parse("c8201505-888b-4190-b3c6-cc10e4acd26c");
                Guid guid = Guid.Parse("c8201505-888b-4190-b3c6-cc10e4acd26c");

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


        [Fact]
        public async Task Should_updateCar_WhenUpdatedDataversion()
        {
            CarAppDto Car = MockCarData();

            var createdCar= await Svc<ICarAppServices>().Create(Car);

            CarAppDto update = MockUpdateCarData();

            var updatedCar = await Svc<ICarAppServices>().Update(update);

            Assert.DoesNotMatch(createdCar.Owner.ToString(), updatedCar.Owner.ToString());
            Assert.NotEqual(updatedCar.RegistrationNumber, createdCar.RegistrationNumber);

        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarAppDto car = MockCarData();
            await Svc<ICarAppServices>().Create(car);

            CarAppDto NullUpdate = MockNullCar();
            await Svc<ICarAppServices>().Update(NullUpdate);


            var nullId = NullUpdate.Id;
            Assert.True(car.Id == nullId);
            Assert.Equal(car.Id, nullId);


        }

        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {
            var guid = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71");

            CarAppDto car= MockCarData();

            CarAppDto car1 = new CarAppDto()
            {
                Id = Guid.Parse("21e9cd74-b60b-4fd4-a458-5f4ce7333d71"),
                Owner = "TFR",
                Model = "Suzuki",
                EngineCapacity = 2,
                VinNumber = "z376254",
                RegistrationNumber = "s24424",
                TypeOfFuel = "diesel",
                Brand = "SR42",
                CarWeight = 2455    ,
                NumberOfCarDoors = 4,
                Color = "white",

                BuiltAt = DateTime.Now,
                RegistratedAt = DateTime.Now


            };

            await Svc<ICarAppServices>().Update(car);

            Assert.Equal(car1.Id, guid);
            Assert.NotEqual(car.Owner, car1.Owner);
            Assert.NotSame(car.RegistrationNumber, car1.RegistrationNumber);
            Assert.DoesNotMatch(car.Model.ToString(), car1.Model.ToString());

        }




        private CarAppDto MockUpdateCarData()
        {
            CarAppDto CarUpdate = new()
            {
                Owner = "les1",
                Model = "BMW",
                EngineCapacity = 221,
                VinNumber = "d334476254",
                RegistrationNumber = "r566644446",
                TypeOfFuel = "diesel",
                Brand = "V6",
                CarWeight = 144,
                NumberOfCarDoors = 4,
                Color = "black",

                BuiltAt = DateTime.Now,
                RegistratedAt = DateTime.Now

            };
            return CarUpdate;
        }
        private CarAppDto MockNullCar()
        {
            CarAppDto dtonull = new()
            {
                Id = null,
                Owner = "Test2",
                Model = "BMW",
                EngineCapacity = 41,
                VinNumber = "d334476254",
                RegistrationNumber = "r5656664",
                TypeOfFuel = "diesel",
                Brand = "S85",
                CarWeight = 441,
                NumberOfCarDoors = 4,
                Color = "white",

                BuiltAt = DateTime.Now,
                RegistratedAt = DateTime.Now

            };

            return dtonull;
        }


        public CarAppDto MockCarData()
        {
            CarAppDto car = new()
            {

            Owner = "Test",
            Model = "Volvo",
            EngineCapacity = 5,
            VinNumber = "d334476255",
            RegistrationNumber = "r5656664",
            TypeOfFuel = "petrol",
            Brand = "S85",
            CarWeight = 434,
            NumberOfCarDoors = 4,
            Color = "white",
           
            BuiltAt = DateTime.Now,
            RegistratedAt = DateTime.Now
            };
            return car;
        }



    }
    }
