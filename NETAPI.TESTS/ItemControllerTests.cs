using Autofac.Extras.Moq;
using NETAPI.Controllers;
using NETAPI.Entities;
using NETAPI.Repository;
using Xunit;

namespace NETAPI.TESTS;

public class ItemControllerTests
{
    [Fact]
    public void GetItems()
    {
        using (var mock = AutoMock.GetStrict())
        {
            mock.Mock<IItemsRepository>()
                .Setup(x => x.GetItems())
                .Returns(GetSampleItems());

            var controller = mock.Create<ItemsController>();

            var expected = GetSampleItems().Select(x=>x.AsDto());

            var actual = controller.GetItems();

            Assert.NotNull(actual);
            Assert.Equal(expected.Count(), actual.Count());
            Assert.True
                (expected.First().Name.Equals(actual.First().Name)
                &&
                expected.First().Price.Equals(expected.First().Price));
        }
    }

    private IEnumerable<Item> GetSampleItems()
    {
        return new List<Item>
        {
            new Item
            {
                CreatedDate = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                id = Guid.NewGuid(),
                Name = "1 liter Cola Bottle",
                Price = 80
            },
            new Item
            {
                CreatedDate = DateTime.Now.Subtract(TimeSpan.FromDays(5)),
                id = Guid.NewGuid(),
                Name = "250 gramm Cream and Onion Chips",
                Price = 180
            }
        }.AsEnumerable();
    }
}