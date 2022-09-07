using MediatR;
using Order.Domain.Events;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.OrderModels
{
  public  class Order:BaseEntity,IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string  Description{ get; private set; }
        public string UserName { get; private set; }
        public string OrderState { get; private set; }
        public Address Address { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, string userName, string orderState, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Orderdata must be greater than now");

            if(string.IsNullOrEmpty(address.City))
                throw new Exception("City cannot be null or empty.");

            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserName = userName;
            OrderState = orderState ?? throw new ArgumentNullException(nameof(orderState));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));

            AddDomainEvents(new OrderStartedDomainEvent("Oğuzhan","Yıkılmaz",this));
        }

        public void AddOrderItem(int quantity,decimal price,int productId)
        {
            OrderItem orderItem = new(quantity, price, productId);

            OrderItems.Add(orderItem);
        }
    }
}
