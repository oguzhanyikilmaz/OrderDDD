using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository _buyerRepository;

        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(notification.Order.UserName))
            {
                var buyer = new Buyer(notification.BuyerUserName);
                //_buyerRepository.Add(buyer);// buyer oluştur ve id yi dön ya da username
                // Order set et               
            }
            return Task.CompletedTask;
        }
    }
}
