namespace FoodOrder.Dto.BasketDto
{
    public class CreateBasketDto
    {

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int RestaurantTableId { get; set; }


    }
}
