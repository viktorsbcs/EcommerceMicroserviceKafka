using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId {  get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}
