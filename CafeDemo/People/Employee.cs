using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using CafeDemo.CafeMenu;
using CafeDemo.CafeOrder;
using CafeDemo.Enums;
using CafeDemo.People;

namespace CafeDemo
{
    public class Employee : Person
    {
        public EmployeeStatus Status { get; private set; } = EmployeeStatus.Available;

        public Employee(string name) : base(name)
        {

        }

        public async Task<Order> TakeOrder(Cafe cafe, Customer customer, params OrderItems[] orderItems)
        {
            Status = EmployeeStatus.TakingOrder;
            var order = new Order(customer, orderItems);
            await Task.Delay(5000);
            var preparer = cafe.GetAvailableEmployee ?? this; //müsait biri varsa ona gönder yoksa ben hazırlayacağım.
            Status = EmployeeStatus.Available;

            preparer.PrepareOrder(cafe, order);

            return order;
        }

        public async Task PrepareOrder (Cafe cafe, Order order)
        {
            Status = EmployeeStatus.PrepraringOrder;
            await Task.Delay(order.TotalPrepTime);
            cafe.PreParedOrders.Add(order);
            Status = EmployeeStatus.Available;
        }

    }
}
