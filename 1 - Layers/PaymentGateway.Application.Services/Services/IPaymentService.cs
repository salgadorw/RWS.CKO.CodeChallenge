using PaymentGateway.Application.DTO;

namespace PaymentGateway.Application.Services.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetPayment(Guid id, CancellationToken token);
        Task<IEnumerable<PaymentDto>> GetPayments(Guid merchantId, Guid? userId, CancellationToken token);
        Task<PaymentDto> ProcessPayment(PaymentDto payment, CancellationToken token, bool saveCardInfo = false);
    }
}