using Microsoft.Extensions.Logging;

using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                    UserName = "swn",
                    FirstName = "Mehmet",
                    CVV="test",
                    CardName="natioalcard",
                    LastName = "Ozkaya",
                    EmailAddress = "ezozkme@gmail.com",
                    AddressLine = "Bahcelievler",
                    Country = "Turkey",
                    TotalPrice = 350 ,
                    CardNumber="6037-9918-6969-6936",
                    Expiration=DateTime.Now.AddYears(2).ToShortDateString(),
                    LastModifiedBy="swn",
                    LastModifiedDate=DateTime.Now,
                    CreatedBy="swn",
                    CreatedDate=DateTime.Now,
                    State="Active",
                    ZipCode="123",
                    PaymentMethod=1
                }
            };
        }
    }
}
