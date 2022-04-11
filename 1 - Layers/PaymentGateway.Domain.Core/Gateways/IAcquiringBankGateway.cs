using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Core.Gateways
{
    public interface IAcquiringBankGateway
    {
        public Task<IEnumerable<PaymentModel>> GetPayments(Guid merchantId, Guid? userId, CancellationToken tokken);

        public Task<PaymentModel> GetPayment(Guid id, CancellationToken tokken);


        public Task<PaymentModel> ProcessPayment(PaymentModel model, CancellationToken tokken);
        
    }
}
