using AutoMapper;

using Orderin.Application.Features.Orders.Commands.CheckoutOrder;
using Orderin.Application.Features.Orders.Commands.UpdateOrder;
using Orderin.Application.Features.Orders.GetOrdersList;

using Ordering.Domain.Entities;

namespace Orderin.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();

        }
    }
}
