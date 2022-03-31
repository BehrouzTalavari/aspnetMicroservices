using Ordering.Domain.Entities;

namespace Orderin.Application.Contracts.Persistance
{
    public interface IOrderRepository : IAsyncRepository<Order>
	{
		Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
	}
}
