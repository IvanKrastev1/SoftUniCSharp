using CarPartsStore.Services.Implementations;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CarPartsStore.Tests
{
    public class PartServiceTest
    {

        [Fact]
        public async Task PartService_ShouldGetCorrectParts()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForPartService();

            var service = new PartService(db);

            //Act
            var parts = await service.All();

            //Assert
            parts.Should().HaveCount(2);
        }


        [Fact]
        public async Task PartService_ShouldDeleteCorrectlyPart()
        {
            //Arrange
            var db = DatabaseInitializer.GetDbForPartService();

            var service = new PartService(db);

            //Act
            await service.Delete(1);

            //Assert
            db.Parts.Should().HaveCount(1);
        }
    }
}
