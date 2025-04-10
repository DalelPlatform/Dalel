using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeChef.HomeChefDelivery;
using Dalel.ViewModels.HomeChef.HomeChefMeal;
using Dalel.ViewModels.HomeChef.HomeChefOrderMeal;
using Dalel.ViewModels.HomeChef.ReviewHomeChefOrder;
using Models.Enums;
using Models.HomeChef;
using Models.WeddingPlaces;
using Utilities;

namespace Dalel.Services.HomeChefServices
{
    public class HomeChefService
    {
        private readonly HomeChefDeliveryRepository _HomeChefDeliveryRepository;
        //private readonly HomeChefMealImageRepository _HomeChefMealImageRepository;
        private readonly HomeChefMealRepository _HomeChefMealRepository;
        private readonly HomeChefOrderMealRepository _HomeChefOrderMealRepository;
        private readonly HomeChefOrderRepository _HomeChefOrderRepository;
        private readonly PaymentHomeChefOrderRepasitory _PaymentHomeChefOrderRepasitory;
        private readonly ReviewHomeChefOrderRepository _ReviewHomeChefOrderRepository;



        public HomeChefService(
            HomeChefDeliveryRepository homeChefDeliveryRepository,
            //HomeChefMealImageRepository homeChefMealImageRepository,
            HomeChefMealRepository homeChefMealRepository,
            HomeChefOrderMealRepository homeChefOrderMealRepository,
            HomeChefOrderRepository homeChefOrderRepository,
            PaymentHomeChefOrderRepasitory paymentHomeChefOrderRepasitory,
            ReviewHomeChefOrderRepository reviewHomeChefOrderRepository)
        {
            _HomeChefDeliveryRepository = homeChefDeliveryRepository;
            //_HomeChefMealImageRepository = homeChefMealImageRepository;
            _HomeChefMealRepository = homeChefMealRepository;
            _HomeChefOrderMealRepository = homeChefOrderMealRepository;
            _HomeChefOrderRepository = homeChefOrderRepository;
            _PaymentHomeChefOrderRepasitory = paymentHomeChefOrderRepasitory;
            _ReviewHomeChefOrderRepository = reviewHomeChefOrderRepository;
        }





        #region Deliveries

        public ServiceResult AddOrder(AddHomeChefDeliveryVM vm)
        {
            try
            {
                var delivery = vm.ToModel();
                _HomeChefDeliveryRepository.Add(delivery);

                return ServiceResult.SuccessResult("Delivery added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrder(AddHomeChefDeliveryVM vm)
        {
            try
            {
                var delivery = vm.ToModel();
                _HomeChefDeliveryRepository.Update(delivery);

                return ServiceResult.SuccessResult("Delivery Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeleteOrder(AddHomeChefDeliveryVM vm)
        {
            try
            {
                var delivery = vm.ToModel();
                _HomeChefDeliveryRepository.Delete(delivery);

                return ServiceResult.SuccessResult("Delivery Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }

        ///////////////////////////Method 1 /////////////////////////

        public ServiceResult<HomeChefDeliveryDetailsVM> GetDeliveryById(int id)
        {
            try
            {
                var delivery = _HomeChefDeliveryRepository.GetDeliveryById(id);

                if (delivery == null)
                {
                    return ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult("Delivery not found.");
                }

                return new ServiceResult<HomeChefDeliveryDetailsVM>
                {
                    Success = true,
                    Message = "Data Requested Successfully!",
                    StatusCode = 200,
                    Data = delivery
                };
            }
            catch (Exception ex)
            {
                return ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult($"Error: {ex.Message}");
            }
        }

        ///////////////////////////Method 2 /////////////////////////

        public List<ServiceResult<HomeChefDeliveryDetailsVM>> GetAllDeliveries()
        {
            try
            {
                List<HomeChefDeliveryDetailsVM> list = _HomeChefDeliveryRepository.GetAllDeliveries();

                if (list == null || !list.Any())
                {
                    return new List<ServiceResult<HomeChefDeliveryDetailsVM>>
                    {
                        ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult("Sorry, no deliveries found.")
                    };
                }

                return list.Select(d =>
                    ServiceResult<HomeChefDeliveryDetailsVM>.SuccessResult(d, "Delivery fetched successfully.")
                ).ToList();
            }
            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefDeliveryDetailsVM>>
        {
            ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult($"Error: {ex.Message}")
        };
            }
        }



        //////////////////////Method 3 ////////////////////


        public List<ServiceResult<HomeChefDeliveryDetailsVM>> GetDeliveriesByDate(DateTime date)
        {
            try
            {
                List<HomeChefDeliveryDetailsVM> deliveries = _HomeChefDeliveryRepository.GetDeliveriesByDate(date);
                if (deliveries == null || deliveries.Any())
                {
                    return new List<ServiceResult<HomeChefDeliveryDetailsVM>>
                    {
                        ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult("Sorry, no deliveries found.")
                    };
                }

                return deliveries.Select(d =>

                ServiceResult<HomeChefDeliveryDetailsVM>.SuccessResult(d, "Delivery fetched successfully.")
                ).ToList();


            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefDeliveryDetailsVM>>
                {
                    ServiceResult<HomeChefDeliveryDetailsVM>.FailureResult($"Error: {ex.Message}")
                };
            }
        }


        #endregion



        #region Meal


        public ServiceResult AddMeal(AddHomeChefMealVM vm)
        {
            try
            {
                var meal = vm.ToModel();
                _HomeChefMealRepository.Add(meal);

                return ServiceResult.SuccessResult("Meal added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateMeal (AddHomeChefMealVM vm)
        {
            try
            {
                var meal = vm.ToModel();
                _HomeChefMealRepository.Update(meal);

                return ServiceResult.SuccessResult("Meal Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeleteMeal (AddHomeChefMealVM vm)
        {
            try
            {
                var meal = vm.ToModel();
                _HomeChefMealRepository.Delete(meal);

                return ServiceResult.SuccessResult("Meal Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }


        ///////////////////////Method 1 ////////////////////////


        public ServiceResult<HomeChefMealDetailsVM> GetMealById(int id)
        {
            try
            {
                var meal = _HomeChefMealRepository.GetMealById(id);
                if (meal == null)
                {
                    return ServiceResult<HomeChefMealDetailsVM>.FailureResult("not Meal found");
                }
                return new ServiceResult<HomeChefMealDetailsVM>
                {
                    Success = true,
                    Message = "Request Send Successfully! .",
                    StatusCode = 200,
                    Data = meal
                };
            }

            catch (Exception ex)
            {
                return ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}");
            }
        }

        ///////////////////////Method 2 ////////////////////////


        public List<ServiceResult<HomeChefMealDetailsVM>> GetAllMeals()
        {
            try
            {


                List<HomeChefMealDetailsVM> meals = _HomeChefMealRepository.GetAllMeals();
                if (meals == null || meals.Any())
                {
                    return new List<ServiceResult<HomeChefMealDetailsVM>>
                        {
                            ServiceResult<HomeChefMealDetailsVM>.FailureResult("Sorry, no Meals found.")
                        };
                }


                return meals.Select(m =>
                ServiceResult<HomeChefMealDetailsVM>.SuccessResult(m, "Meals fetched successfully.")
                ).ToList();

            }


            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefMealDetailsVM>>
              {
                  ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
        }


        ///////////////////////Method 3////////////////////////

        


        public List<ServiceResult<HomeChefMealDetailsVM>> GetMealsByChefId (string chefId)
        {
            try
            {


                List<HomeChefMealDetailsVM> meals = _HomeChefMealRepository.GetMealsByChefId(chefId);
                if (meals == null || meals.Any())
                {
                    return new List<ServiceResult<HomeChefMealDetailsVM>>
                        {
                            ServiceResult<HomeChefMealDetailsVM>.FailureResult("Sorry, no Meal found.")
                        };
                }


                return meals.Select(m =>
                ServiceResult<HomeChefMealDetailsVM>.SuccessResult(m, "Meals fetched successfully.")
                ).ToList();

            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefMealDetailsVM>>
              {
                  ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
        }



        ///////////////////////Method 4////////////////////////


        public List<ServiceResult<HomeChefMealDetailsVM>> GetMealsByCategory(FoodCategory category)
        {
            try
            {


                List<HomeChefMealDetailsVM> meals = _HomeChefMealRepository.GetMealsByCategory(category);
                if (meals == null || meals.Any())
                {
                    return new List<ServiceResult<HomeChefMealDetailsVM>>
                        {
                            ServiceResult<HomeChefMealDetailsVM>.FailureResult("Sorry, no Meal found.")
                        };
                }


                return meals.Select(m =>
                ServiceResult<HomeChefMealDetailsVM>.SuccessResult(m, "Meals fetched successfully.")
                ).ToList();

            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefMealDetailsVM>>
              {
                  ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
        }



        ///////////////////////Method 5////////////////////////


        public List<ServiceResult<HomeChefMealDetailsVM>> GetAvailableMeals(bool status)
        {
            try
            {


                List<HomeChefMealDetailsVM> meals = _HomeChefMealRepository.GetAvailableMeals(status);
                if (meals == null || meals.Any())
                {
                    return new List<ServiceResult<HomeChefMealDetailsVM>>
                        {
                            ServiceResult<HomeChefMealDetailsVM>.FailureResult("Sorry, no Meals found.")
                        };
                }


                return meals.Select(m =>
                ServiceResult<HomeChefMealDetailsVM>.SuccessResult(m, "Meals fetched successfully.")
                ).ToList();

            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefMealDetailsVM>>
              {
                  ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
        }



        ///////////////////////Method 6////////////////////////


        public List<ServiceResult<HomeChefMealDetailsVM>> SearchMeals(string keyword)
        {
            try
            {


                List<HomeChefMealDetailsVM> meals = _HomeChefMealRepository.SearchMeals(keyword);
                if (meals == null || meals.Any())
                {
                    return new List<ServiceResult<HomeChefMealDetailsVM>>
                        {
                            ServiceResult<HomeChefMealDetailsVM>.FailureResult("Sorry, no Meals found.")
                        };
                }


                return meals.Select(m =>
                ServiceResult<HomeChefMealDetailsVM>.SuccessResult(m, "Meals fetched successfully.")
                ).ToList();

            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefMealDetailsVM>>
              {
                  ServiceResult<HomeChefMealDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
        }



        #endregion



        #region Order


        public ServiceResult AddOrder(AddHomeChefOrderVM vm)
        {
            try
            {
                var order = vm.ToModel();
                _HomeChefOrderRepository.Add(order);

                return ServiceResult.SuccessResult("Order added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrder(AddHomeChefOrderVM vm)
        {
            try
            {
                var order = vm.ToModel();
                _HomeChefOrderRepository.Update(order);

                return ServiceResult.SuccessResult("Order Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeleteOrder(AddHomeChefOrderVM vm)
        {
            try
            {
                var Order = vm.ToModel();
                _HomeChefOrderRepository.Delete(Order);

                return ServiceResult.SuccessResult("Order Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }

        ///////////////////////Method 1 ////////////////////////

        public ServiceResult<HomeChefOrderDetailsVM> GetOrderById(int id)
        {
            try
            {
                var order = _HomeChefOrderRepository.GetOrderById(id);
                if (order == null)
                {
                    return ServiceResult<HomeChefOrderDetailsVM>.FailureResult("Sorry, No Order found !. ");
                }

                return new ServiceResult<HomeChefOrderDetailsVM>
                {
                    Success = true,
                    Message = "Request Send Successfully! .",
                    StatusCode = 200,
                    Data = order
                };
            }

            catch (Exception ex)
            {
                return ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}");
            }
        }


        ///////////////////////Method 2 ////////////////////////
        public List<ServiceResult<HomeChefOrderDetailsVM>> GetAllOrders()
        {
            try
            {
                List<HomeChefOrderDetailsVM> orders = _HomeChefOrderRepository.GetAllOrders();

                if (orders == null || orders.Any())
                {
                    return new List<ServiceResult<HomeChefOrderDetailsVM>>
                    {
                        ServiceResult<HomeChefOrderDetailsVM>.FailureResult("No Orders Found !")
                    };
                }

                return orders.Select(o =>
                ServiceResult<HomeChefOrderDetailsVM>.SuccessResult(o, "Orders fetched successfully.")
                ).ToList();
            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefOrderDetailsVM>>
              {
                  ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }
            

        }


        ///////////////////////Method 3 ////////////////////////

        public List<ServiceResult<HomeChefOrderDetailsVM>> GetOrdersByChefId(string id)
        {
            try
            {
                List<HomeChefOrderDetailsVM> orders = _HomeChefOrderRepository.GetOrdersByChefId(id);

                if (orders == null || orders.Any())
                {
                    return new List<ServiceResult<HomeChefOrderDetailsVM>>
                    {
                        ServiceResult<HomeChefOrderDetailsVM>.FailureResult("No Orders Found !")
                    };
                }

                return orders.Select(o =>
                ServiceResult<HomeChefOrderDetailsVM>.SuccessResult(o, "Orders fetched successfully.")
                ).ToList();
            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefOrderDetailsVM>>
              {
                  ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }

        }


        ///////////////////////Method 4 ////////////////////////
        public List<ServiceResult<HomeChefOrderDetailsVM>> GetOrdersByCustomerId(string id)
        {
            try
            {
                List<HomeChefOrderDetailsVM> orders = _HomeChefOrderRepository.GetOrdersByCustomerId(id);

                if (orders == null || orders.Any())
                {
                    return new List<ServiceResult<HomeChefOrderDetailsVM>>
                    {
                        ServiceResult<HomeChefOrderDetailsVM>.FailureResult("No Orders Found !")
                    };
                }

                return orders.Select(o =>
                ServiceResult<HomeChefOrderDetailsVM>.SuccessResult(o, "Orders fetched successfully.")
                ).ToList();
            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefOrderDetailsVM>>
              {
                  ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }

        }

        ///////////////////////Method 5 ////////////////////////

        public List<ServiceResult<HomeChefOrderDetailsVM>> GetOrdersByStatus(OrderStatus status)
        {
            try
            {
                List<HomeChefOrderDetailsVM> orders = _HomeChefOrderRepository.GetOrdersByStatus(status);

                if (orders == null || orders.Any())
                {
                    return new List<ServiceResult<HomeChefOrderDetailsVM>>
                    {
                        ServiceResult<HomeChefOrderDetailsVM>.FailureResult("No Orders Found !")
                    };
                }

                return orders.Select(o =>
                ServiceResult<HomeChefOrderDetailsVM>.SuccessResult(o, "Orders fetched successfully.")
                ).ToList();
            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefOrderDetailsVM>>
              {
                  ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}")
              };
            }

        }


        ///////////////////////Method 6 ////////////////////////
        public List<ServiceResult<HomeChefOrderDetailsVM>> GetOrdersByDate(DateTime date)
        {
            try
            {
                List<HomeChefOrderDetailsVM> orders = _HomeChefOrderRepository.GetOrdersByDate(date);

                if (orders == null || orders.Any())
                {
                    return new List<ServiceResult<HomeChefOrderDetailsVM>>
              {
                  ServiceResult<HomeChefOrderDetailsVM>.FailureResult("No Orders Found !")
              };
                }

                return orders.Select(o =>
                ServiceResult<HomeChefOrderDetailsVM>.SuccessResult(o, "Orders fetched successfully.")
                ).ToList();
            }

            catch (Exception ex)
            {
                return new List<ServiceResult<HomeChefOrderDetailsVM>>
        {
            ServiceResult<HomeChefOrderDetailsVM>.FailureResult($"Error : {ex.Message}")
        };
            }

        }








        #endregion


        #region HomeChefOrderMeal
        public ServiceResult AddOrderMeal(AddHomeChefOrderMealVM vm)
        {
            try
            {
                var orderMeal = vm.ToModel();
                _HomeChefOrderMealRepository.Add(orderMeal);

                return ServiceResult.SuccessResult("OrderMeal added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrderMeal(AddHomeChefOrderMealVM vm)
        {
            try
            {
                var orderMeal = vm.ToModel();
                _HomeChefOrderMealRepository.Update(orderMeal);

                return ServiceResult.SuccessResult("OrderMeal Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeleteOrderMeal(AddHomeChefOrderMealVM vm)
        {
            try
            {
                var orderMeal = vm.ToModel();
                _HomeChefOrderMealRepository.Delete(orderMeal);

                return ServiceResult.SuccessResult("OrderMeal Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }

        #endregion



        #region PaymentHomeChefOrder 
        public ServiceResult AddPayment(AddPaymentHomeChefOrderVM vm)
        {
            try
            {
                var payment = vm.ToModel();
                _PaymentHomeChefOrderRepasitory.Add(payment);

                return ServiceResult.SuccessResult("Payment added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdatePayment(AddPaymentHomeChefOrderVM vm)
        {
            try
            {
                var payment = vm.ToModel();
                _PaymentHomeChefOrderRepasitory.Update(payment);

                return ServiceResult.SuccessResult("Payment Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeletePayment(AddPaymentHomeChefOrderVM vm)
        {
            try
            {
                var payment = vm.ToModel();
                _PaymentHomeChefOrderRepasitory.Delete(payment);

                return ServiceResult.SuccessResult("Payment Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }

        #endregion



        #region ReviewHomeChefOrder


        public ServiceResult AddReview(AddReviewHomeChefOrderVM vm)
        {
            try
            {
                var review = vm.ToModel();
                _ReviewHomeChefOrderRepository.Add(review);

                return ServiceResult.SuccessResult("Review added successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }


        public ServiceResult UpdateOrder(AddReviewHomeChefOrderVM vm)
        {
            try
            {
                var review = vm.ToModel();
                _ReviewHomeChefOrderRepository.Update(review);

                return ServiceResult.SuccessResult("Review Updated successfully.");
            }
            catch (Exception ex)
            {

                return ServiceResult.FailureResult($"Error: {ex.Message}");
            }
        }



        public ServiceResult DeleteOrder(AddReviewHomeChefOrderVM vm)
        {
            try
            {
                var review = vm.ToModel();
                _ReviewHomeChefOrderRepository.Delete(review);

                return ServiceResult.SuccessResult("Review Deleted Successfully!.");
            }

            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Error : {ex.Message}");
            }

        }

        #endregion

    }







}

