using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeDemo.CafeMenu;
using CafeDemo.CafeOrder;
using CafeDemo.Enums;
using CafeDemo.People;

namespace CafeDemo
{
    public class Cafe
    {
        public Cafe(List<Employee> employees, params Product[] products)
        {
            Menu = new Menu(products);
            Employees=employees;
        }
        //Menu
        public Menu Menu { get;}

        //Musteri Sirasi

        public Queue <Customer> CustomerLine { get; set; }

        //Calisanlari
        private List<Employee> Employees { get;}

        public Employee? GetAvailableEmployee => Employees.FirstOrDefault(Employee => Employee.Status == Enums.EmployeeStatus.Available);

        public List<Order> PreParedOrders { get; } = new List<Order>();

        //Kasa
        public readonly int RegisterCount = 3;

        public Order ServeOrder(Order receipt)
        {
            var order = PreParedOrders.FirstOrDefault(Order => Order == receipt);
            if (order!=null)
            {
                PreParedOrders.Remove(order);
                return order;
            }
            throw new Exception("Order not prepared yet");
        }

        public bool IsOrderPrepared(Order order)
        {
            return PreParedOrders.Contains(order);
        }


        public async Task<Order> RegisterTakeOrder(Customer customer, params OrderItems[] orderItems)
        {

            var registerer = Employees.First(Employees => Employees.Status == Enums.EmployeeStatus.Available);

            CustomerLine.Dequeue();

            return await registerer.TakeOrder(this, customer, orderItems);


        }

        public bool CanRegisterTakeOrder()
        {
            return Employees.Any(Employee => Employee.Status == Enums.EmployeeStatus.Available) && Employees.Count(Employee => Employee.Status == Enums.EmployeeStatus.TakingOrder) < RegisterCount;
        }


        public void GetInLine(Customer customer)
        {
            CustomerLine.Enqueue(customer);
        }

        public bool IsNext (Customer customer)
        {
            var nextCustomer = CustomerLine.Peek();
            if (nextCustomer != null)
            {
                return nextCustomer == customer;
            }
            else { return false; }
        }



    }
}
