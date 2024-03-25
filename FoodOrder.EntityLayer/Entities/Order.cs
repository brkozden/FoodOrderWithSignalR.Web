using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrder.Entity.Entities
{
    public class Order
    {
        public  int OrderId { get; set; }

        public string TableNumber { get; set; }
        public string Description { get; set; }

        public decimal TotalPrice { get; set; }

        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
