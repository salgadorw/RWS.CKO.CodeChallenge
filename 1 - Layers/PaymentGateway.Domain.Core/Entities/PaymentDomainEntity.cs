using PaymentGateway.Domain.Core.Gateways;
using PaymentGateway.Domain.Core.Services;
using PaymentGateway.Domain.Model;


namespace PaymentGateway.Domain.Core.Entities
{
    public class PaymentDomainEntity : IPaymentDomainEntity
    {
        private readonly IAcquiringBankGateway acquiringBankGateway;
        public PaymentDomainEntity(IAcquiringBankGateway acquiringBankGateway)
        {
            this.acquiringBankGateway = acquiringBankGateway;
        }
        public async Task<PaymentModel> GetPayment(Guid id, CancellationToken token)
        {
            return await this.acquiringBankGateway.GetPayment(id, token);
        }

        public async Task<IEnumerable<PaymentModel>> GetPayments(Guid merchantId, Guid? userId, CancellationToken token)
        {
            return await this.acquiringBankGateway.GetPayments(merchantId, userId, token);
        }

        public Task<PaymentModel> ProcessPayment(PaymentModel model, CancellationToken token)
        {
            model.Validate();
            model.Id =  Guid.NewGuid();
            return this.acquiringBankGateway.ProcessPayment(model, token);
        }
    }
}
