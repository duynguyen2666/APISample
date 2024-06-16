using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Database
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
