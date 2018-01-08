using CarPartsStore.Services.Implementations;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CarPartsStore.Tests
{
    public class CarServiceTest
    {
        [Fact]
        public async Task CarServiceAll_ShouldReturnCollection()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            var result = await service.All();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task CarServiceAll_ShouldReturnProperCollection()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            var result = await service.All();

            //Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task CarServiceDelete_ShouldWorkProperly()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            await service.Delete(1);

            //Assert
            db.Cars.Should().HaveCount(1);


        }
        [Fact]
        public async Task CarServiceDelete_ShouldReturnIfIdIsInvalid()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            await service.Delete(4);

            //Assert
            db.Cars.Should().HaveCount(2);
        }

        [Fact]
        public async Task CarServiceEdit_ShouldEditCorrectly()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            await service.EditCar(1, "lada1", "spas", "1999", Data.Enums.FuelType.Diesel, "nafteno");

            //Assert
            Assert.Equal("lada1", db.Cars.FirstOrDefault(x => x.Id == 1).Make);
        }

        [Fact]
        public async Task CarServiceEdit_ShouldNotEditCorrectlyIfIdIsWrong()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            await service.EditCar(5, "lada3", "spas", "1999", Data.Enums.FuelType.Diesel, "nafteno");

            //Assert
            Assert.NotEqual("lada3", db.Cars.FirstOrDefault(x => x.Id == 1).Make);
        }



        [Fact]
        public async Task CarServiceGetCar_ShouldReturnCorrectCar()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            var car = await service.CarById(1);

            //Assert
            Assert.Equal("lada", car.Make);
        }

        [Fact]
        public async Task CarServiceGetCar_ShouldReturnNullIfIdIsWrong()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForCarService();
            var service = new CarService(db);

            //Act
            var car = await service.CarById(10);

            //Assert
            Assert.Null(car);
        }     

    }
}
