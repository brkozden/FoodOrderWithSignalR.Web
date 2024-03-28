namespace FoodOrder.WebUI.Dtos.RestaurantTableDtos
{
    public class UpdateRestaurantTableDto
    {
        public int RestaurantTableId { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; }
    }
}
