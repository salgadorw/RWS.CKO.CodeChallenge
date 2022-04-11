using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Core.Entities
{
    public interface IPaymentDomainEntity
    {
        Task<PaymentModel> GetPayment(Guid id, CancellationToken token);
        Task<IEnumerable<PaymentModel>> GetPayments(Guid merchantId, Guid? userId, CancellationToken token);
        Task<PaymentModel> ProcessPayment(PaymentModel model, CancellationToken token);
    }
}