using System.ComponentModel.DataAnnotations;

namespace API.Database
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
