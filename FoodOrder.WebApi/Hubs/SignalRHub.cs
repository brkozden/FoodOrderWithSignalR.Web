using FoodOrder.Business.Abstrack;
using Microsoft.AspNetCore.SignalR;

namespace FoodOrder.WebApi.Hubs
{

    public class SignalRHub:Hub
    {
      private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;


        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IRestaurantTableService restaurantTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _restaurantTableService = restaurantTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
           var categoryCount = _categoryService.TCategoryCount();
            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            var productCount = _productService.TProductCount();
            var lastAddedCategoryName = _categoryService.TLastAddedCategoryName();
            var totalOrderCount = _orderService.TTotalOrderCount();
            var activeOrderCount = _orderService.TActiveOrderCount();
            var lastOrderPrice = _orderService.TLastOrderPrice();
            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            var productNameByMinPrice = _productService.TProductNameByMinPrice();
            var productNameByMaxPrice = _productService.TProductNameByMaxPrice();
            var productPriceAvg = _productService.TProductPriceAvg();
            var restaurantTableCount = _restaurantTableService.TRestaurantTableCount();
            var productPriceMin = _productService.TProductPriceMin();
            var productPriceMax = _productService.TProductPriceMax();
            var notificationCount = _notificationService.TNotificationCountByStatusFalse();


            await Clients.All.SendAsync("ReceiveCategoryCount",categoryCount);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
            await Clients.All.SendAsync("ReceiveLastAddedCategoryName", lastAddedCategoryName);
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);
            await Clients.All.SendAsync("ReceiveLastOrderPrice", Math.Round(lastOrderPrice,2) + "₺");
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", Math.Round(totalMoneyCaseAmount,2) + "₺");
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameByMinPrice);
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameByMaxPrice);
            await Clients.All.SendAsync("ReceiveProductPriceAvg", Math.Round(productPriceAvg,2) + "₺");
            await Clients.All.SendAsync("ReceiveProductPriceMin", Math.Round(productPriceMin, 2) + "₺");
            await Clients.All.SendAsync("ReceiveProductPriceMax", Math.Round(productPriceMax, 2) + "₺");
            await Clients.All.SendAsync("ReceiveRestaurantTableCount", restaurantTableCount);
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            await Clients.All.SendAsync("ReceiveNotificationCount", notificationCount);

        }

        public async Task GetBookingList()
        {
            var getBookingList = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", getBookingList);

        }
        public async Task SendNotification()
        {
            var notificationCount = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", notificationCount);
            var notificationListByFalse = _notificationService.TGetNotificationByFalseLast4();
            await Clients.All.SendAsync("ReceiveAllNotificationListByFalse", notificationListByFalse);

        }

    }
}
