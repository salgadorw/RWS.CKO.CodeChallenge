using PaymentGateway.Domain.Core.Gateways;
using PaymentGateway.Domain.Model;

namespace AcquiringBank.Infrastructure.Abstraction
{
    public class AcquiringBankGatewayDummyImplementation : IAcquiringBankGateway
    {
        private volatile static List<PaymentModel> payments = new List<PaymentModel>();

        private const string STATUSINVALIDATION = "INVALIDATION";

        private const string STATUSINVALID = "INVALID";

        private const string STATUSVALID = "VALID";

        private const string STATUSPAID = "PAID";

        private const double transactionValidMinValue = 0.3;

        private static DateTime LastUpdate;


        public AcquiringBankGatewayDummyImplementation()
        {
            LastUpdate = DateTime.Now;
            Thread.Sleep(3000);
        }

        public async Task<PaymentModel> GetPayment(Guid id, CancellationToken tokken)
        {
            return await Task.Run(() =>
              {
                  return payments.FirstOrDefault(w => w.Id.Equals(id));
              }, tokken);
        }

        public async Task<IEnumerable<PaymentModel>> GetPayments(Guid merchantId, Guid? userId, CancellationToken tokken)
        {
            return await Task.Run(() =>
            {

                return payments.Where(w => w.MerchantId.Equals(merchantId) && (userId == null || userId.Value.Equals(w.CardInfo.UserId)));
            }, tokken);
        }

        public async Task<PaymentModel> ProcessPayment(PaymentModel model, CancellationToken tokken)
        {
            return await Task.Run(() =>
             {
                 model.Status = STATUSINVALIDATION;
                 payments.Add(model);

                 if (DateTime.Now.Subtract(LastUpdate).TotalSeconds >= 3)
                 {
                     var thread = new Thread(PaymentStateChange);
                     thread.Start();
                 }

                 return model;
             });
        }

        protected void PaymentStateChange()
        {

            Thread.Sleep(1000);

            var random = new Random();
            var paymentsInValidation = payments.Where(w => w.Status.Equals(STATUSINVALIDATION));
            var isValidTransaction = random.NextDouble();

            if (isValidTransaction >= transactionValidMinValue)
                paymentsInValidation.ToList().ForEach(payment =>
                {
                    payment.Status = STATUSINVALID;
                    payment.LastUpdate = DateTime.Now;
                });
            else
                paymentsInValidation.ToList().ForEach(payment =>
                {
                    payment.Status = STATUSVALID;
                    payment.LastUpdate = DateTime.Now;
                });

            Thread.Sleep(1000);

            var paymentsValid = payments.Where(w => w.Status.Equals(STATUSVALID));
            paymentsValid.ToList().ForEach(payment =>
            {
                payment.Status = STATUSPAID;
                payment.LastUpdate = DateTime.Now;
            });
        }
    }
}
