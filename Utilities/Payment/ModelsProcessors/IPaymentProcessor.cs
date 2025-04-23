
namespace Utilities
{
    public interface IPaymentProcessor<T>
    {
        ServiceResult ProcessPayment(T payment);
    }
}
