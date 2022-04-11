using PaymentGateway.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Data.Gateways
{
    public interface IAcquiringBankGateway
    {
        public Task<IEnumerable<PaymentModel>> GetPayments(Guid merchantId, Guid? UserId);

        public Task<PaymentModel> GetPayment(Guid merchantId, Guid paymentId);

        public Task<PaymentModel> ProcessPayment(PaymentModel model);
        
    }
}
