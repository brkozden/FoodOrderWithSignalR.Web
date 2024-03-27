namespace FoodOrder.WebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketId { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int RestaurantTableId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string ImageUrl { get; set; }

    }
}
