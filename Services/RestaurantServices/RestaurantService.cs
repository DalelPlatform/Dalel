using Dalel.Extensions;
using Dalel.Repository;
using Dalel.ViewModels;
using Dalel.ViewModels.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Restaurant;
using System.Security.Claims;
using Utilities;

namespace Dalel.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepo;
        private readonly RestaurantMenuItemRepository _menuItemRepository;
        private readonly RestaurantReservationRepository _restaurantReservationRepository;
        private readonly RestaurantOrderItemRepository _restaurantOrderItemRepository;
        private readonly RestaurantOrderRepository _restaurantOrderRepository;
        private readonly ReviewRestaurantOrderRepository _reviewRestaurantOrderRepository;
        private readonly PaymentRestaurantOrderReopsitory _paymentRestaurantOrderReopsitory;
        private readonly ClientRepository _clientRepository;

        public RestaurantService(
            RestaurantRepository restaurantRepo,
            RestaurantMenuItemRepository menuItemRepository,
            RestaurantReservationRepository restaurantReservationRepository,
            RestaurantOrderItemRepository restaurantOrderItemRepository,
            RestaurantOrderRepository restaurantOrderRepository,
            ReviewRestaurantOrderRepository reviewRestaurantOrderRepository,
            PaymentRestaurantOrderReopsitory paymentRestaurantOrderReopsitory,
            ClientRepository clientRepository
            )
        {
            _restaurantRepo = restaurantRepo;
            _menuItemRepository = menuItemRepository;
            _restaurantReservationRepository = restaurantReservationRepository;
            _restaurantOrderItemRepository = restaurantOrderItemRepository;
            _restaurantOrderRepository = restaurantOrderRepository;
            _reviewRestaurantOrderRepository = reviewRestaurantOrderRepository;
            _paymentRestaurantOrderReopsitory = paymentRestaurantOrderReopsitory;
            _clientRepository = clientRepository;

        }

        #region Restaurant
        public ServiceResult CreateRestaurant([FromForm] AddRestaurantVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _restaurantRepo.Add(model);
                return ServiceResult.SuccessResult("Restaurant added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult EditRestaurant(AddRestaurantVM model, int id)
        {
            try
            {
                var oldrestaurant = _restaurantRepo.GetById(id);
                _restaurantRepo.Update(model.ToEditModel(oldrestaurant));
                return ServiceResult.SuccessResult("Restaurant updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult DeleteRestaurant(int id)
        {
            try
            {
                var restaurant = _restaurantRepo.GetById(id);
                if (restaurant == null)
                    return ServiceResult.FailureResult("Restaurant not found.");

                _restaurantRepo.Delete(restaurant);
                return ServiceResult.SuccessResult("Restaurant deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<List<RestaurantDetailsVM>> GetAll()
        {
            try
            {
                var list = _restaurantRepo.GetList(r => !r.IsDeleted)
                    .Select(r => r.ToDetailsViewModel())
                    .ToList();

                return ServiceResult<List<RestaurantDetailsVM>>.SuccessResult(list, "Restaurants retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<RestaurantDetailsVM>> Search(
            string searchText = "",
            string city = null,
            string region = null,
            string street = null,
            string address = null,
            int NumberOfRooms = 0,
            VerificationStatus? verificationStatus = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var result = _restaurantRepo.SearchRestaurants(
                    searchText, city, region, street, address, NumberOfRooms, verificationStatus,
                    sortBy, descending, pageSize, pageIndex);

                return ServiceResult<PaginationViewModel<RestaurantDetailsVM>>.SuccessResult(result, "Search completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<RestaurantDetailsVM> GetRestaurantById(int id)
        {
            try
            {
                var restaurant = _restaurantRepo.GetById(id);
                if (restaurant == null)
                    return ServiceResult<RestaurantDetailsVM>.FailureResult("Restaurant not found.");
                return ServiceResult<RestaurantDetailsVM>.SuccessResult(restaurant.ToDetailsViewModel(), "Restaurant retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<RestaurantDetailsVM> GetRestaurantByOwnerId(string ownerId)
        {
            try
            {
                var restaurant = _restaurantRepo.GetRestaurantByOwnerId(ownerId);
                if (restaurant == null)
                    return ServiceResult<RestaurantDetailsVM>.FailureResult("Restaurant not found.");
                return ServiceResult<RestaurantDetailsVM>.SuccessResult(restaurant, "Restaurant retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<List<RestaurantDetailsVM>> GetRestaurantsByVerificationStatus(VerificationStatus verificationStatus)
        {
            try
            {
                var restaurants = _restaurantRepo.GetRestaurantsByVerificationStatus(verificationStatus)
                    .ToList(); // Convert IQueryable to List to resolve the type mismatch

                if (restaurants == null || !restaurants.Any())
                    return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("No restaurants found with the specified verification status.");

                return ServiceResult<List<RestaurantDetailsVM>>.SuccessResult(restaurants, "Restaurants retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        #endregion

        #region RestaurantMeal

        public ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>> SearchMeals(
            string search = "",
            float? minPrice = null,
            float? maxPrice = null,
            AvaliabilityStatus? avaliabilityStatus = null,
            FoodCategory? foodCategory = null,
            SizeOfPiece? sizeOfPiece = null,
            double? duration = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var data = _menuItemRepository.SearchMeals(
                    search,
                    minPrice,
                    maxPrice,
                    avaliabilityStatus,
                    foodCategory,
                    sizeOfPiece,
                    duration,
                    sortBy,
                    descending,
                    pageSize,
                    pageIndex);

                return ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>>.SuccessResult(
                    data,
                    "Meals retrieved successfully"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>>.FailureResult(
                    $"Error occurred while retrieving meals: {ex.Message}"
                );
            }
        }
        public ServiceResult CreateMeal(AddRestaurantMenuItemVM meal)
        {
            try
            {
                var restaurant = _restaurantRepo.GetList(r => r.OwnerId == meal.RestaurantOwnerId).FirstOrDefault();
                if (restaurant == null)
                    return ServiceResult.FailureResult("Restaurnt not found");

                meal.RestaurantId = restaurant.Id;
                _menuItemRepository.Add(meal.ToModel());
                return ServiceResult.SuccessResult("Meal added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }
        public ServiceResult EditMeal(AddRestaurantMenuItemVM meal, int id)
        {
            try
            {
                var oldMeal = _menuItemRepository.GetList(m => m.Id == id).FirstOrDefault();
                if (oldMeal == null)
                {
                    return ServiceResult.FailureResult("Meal not found.");
                }
                _menuItemRepository.Update(meal.ToEditModel(oldMeal));

                return ServiceResult.SuccessResult("Meal Updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }
        public ServiceResult DeleteMeal(int mealId)
        {
            try
            {
                var meal = _menuItemRepository.GetList(m => m.Id == mealId).FirstOrDefault();
                if (meal != null)
                {
                    _menuItemRepository.Delete(meal);
                    return ServiceResult.SuccessResult("Meal Deleted successfully.");

                }
                else
                {
                    return ServiceResult.FailureResult("Meal Not Found");

                }
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }
        public ServiceResult<List<RestaurantMenuItemDetailsVM>> GetMealsByRestaurant(int restaurantId)
        {
            try
            {
                var meals = _menuItemRepository.GetMealsByRestaurantId(restaurantId);
                return ServiceResult<List<RestaurantMenuItemDetailsVM>>.SuccessResult(meals, "Meals loaded successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantMenuItemDetailsVM>>.FailureResult($"Failed to load meals: {ex.Message}");
            }
        }

        public ServiceResult<RestaurantMenuItemDetailsVM> GetMealById(int mealId)
        {
            try
            {
                var meal = _menuItemRepository.GetMealById(mealId);
                if (meal == null)
                {
                    return ServiceResult<RestaurantMenuItemDetailsVM>.FailureResult("Meal not found.");
                }

                return ServiceResult<RestaurantMenuItemDetailsVM>.SuccessResult(meal.ToDetailsViewModel(), "Meal retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantMenuItemDetailsVM>.FailureResult($"Error retrieving meal: {ex.Message}");
            }
        }
        #endregion

        #region RestaurantOrderItem
        public ServiceResult AddOrderItem(AddRestaurantOrderItemVM orderVM)
        {
            try
            {
                var orderItem = orderVM.ToModel();
                _restaurantOrderItemRepository.Add(orderItem);

                return ServiceResult.SuccessResult("OrderMeal added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrderItem(int id, AddRestaurantOrderItemVM orderVM)
        {
            try
            {
                var oldMeal = _restaurantOrderItemRepository.GetList(m => m.Id == id).FirstOrDefault();

                if (oldMeal == null)
                {
                    return ServiceResult.FailureResult("Order not found.");
                }
                _restaurantOrderItemRepository.Update(orderVM.ToEditModel(oldMeal));


                return ServiceResult.SuccessResult("Meal Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult DeleteOrderItem(int id) // Delete order by id
        {
            try
            {
                var order = _restaurantOrderItemRepository.GetList(m => m.Id == id).FirstOrDefault();

                if (order == null)
                {
                    return ServiceResult.FailureResult("Meal not found.");
                }


                _restaurantOrderItemRepository.Delete(order);

                return ServiceResult.SuccessResult("Meal Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }


        #endregion

        #region RestaurantOrder

        public ServiceResult CreateOrder(AddRestaurantOrderVM order)
        {
            try
            {
                var NewOrder = order.ToModel();
                _restaurantOrderRepository.Add(NewOrder);

                return ServiceResult.SuccessResult("Order added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrder(int id, AddRestaurantOrderVM orderVM)
        {
            try
            {
                var oldMeal = _restaurantOrderRepository.GetList(m => m.Id == id).FirstOrDefault();

                if (oldMeal == null)
                {
                    return ServiceResult.FailureResult("Order not found.");
                }
                _restaurantOrderRepository.Update(orderVM.ToEditModel(oldMeal));


                return ServiceResult.SuccessResult("Order Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        #endregion

        #region RestaurantReservation

        public ServiceResult<RestaurantReservationDetailsVM> CreateRestaurantReservation([FromForm] AddRestaurantReservationVM vm)
        {
            try
            {
                var reservation = vm.ToModel();
                _restaurantReservationRepository.Add(reservation);
                var restaurant = _restaurantRepo.GetById(reservation.RestaurantId);
                if (restaurant == null)
                    return ServiceResult<RestaurantReservationDetailsVM>.FailureResult("Restaurant not found.");
                var clientId = vm.ClientId;
                var client = _clientRepository.GetList(r => r.UserId == clientId).FirstOrDefault();


                if (client == null)
                    return ServiceResult<RestaurantReservationDetailsVM>.FailureResult("Client not found.");
                var details = reservation.ToDetailsViewModel();
                details.RestaurantName = restaurant.Name;
                details.ClientName = client.User.UserName ?? "Not Provided";
                details.ReervationStatus = "pending";



                return ServiceResult<RestaurantReservationDetailsVM>.SuccessResult(details, "Restaurant Reservation sended.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantReservationDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult EditRestaurantReservation(AddRestaurantReservationVM reserve, int id)
        {
            try
            {
                var oldReservation = _restaurantReservationRepository.GetList(m => m.Id == id).FirstOrDefault();
                if (oldReservation == null)
                {
                    return ServiceResult.FailureResult("Reservation not found.");
                }
                _restaurantReservationRepository.Update(reserve.ToEditModel(oldReservation));

                return ServiceResult.SuccessResult("Reserve Updated successfully , please wait for Response ...");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }



        public ServiceResult DeleteReserve(int reserveId)
        {
            try
            {
                var reserve = _menuItemRepository.GetList(m => m.Id == reserveId).FirstOrDefault();
                if (reserve != null)
                {
                    _menuItemRepository.Delete(reserve);
                    return ServiceResult.SuccessResult("reserve Deleted successfully.");

                }
                else
                {
                    return ServiceResult.FailureResult("reserve Not Found");

                }
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }

  

            #endregion



        
    }
}
