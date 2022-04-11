using AutoMapper;
using PaymentGateway.Application.DTO;
using PaymentGateway.Domain.Core.Entities;
using PaymentGateway.Domain.Model;


namespace PaymentGateway.Application.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentDomainEntity paymentDomainEntity;
        private readonly ICardInfoService cardInfoService;
        private readonly IMapper mapper;
        public PaymentService(IPaymentDomainEntity paymentDomainEntity,ICardInfoService cardInfoService, IMapper mapper)
        {
            this.paymentDomainEntity = paymentDomainEntity;
            this.cardInfoService = cardInfoService;
            this.mapper = mapper;
        }
        public async Task<PaymentDto> GetPayment(Guid id, CancellationToken token)
        {
            var paymentModel = await paymentDomainEntity.GetPayment(id, token);
            var payment = mapper.Map<PaymentDto>(paymentModel);
            return payment;
        }

        public async Task<IEnumerable<PaymentDto>> GetPayments(Guid merchantId, Guid? userId, CancellationToken token)
        {
            var paymentModels = await paymentDomainEntity.GetPayments(merchantId, userId, token);
            var payments = mapper.Map<IEnumerable<PaymentDto>>(paymentModels);
            return payments;
        }

        public async Task<PaymentDto> ProcessPayment(PaymentDto payment, CancellationToken token, bool saveCardInfo = false)
        {
            //Application validation could be implemented
            var paymentModel = mapper.Map<PaymentModel>(payment);
            if (saveCardInfo)
              paymentModel.CardInfo = mapper.Map<CardInfoModel>(await cardInfoService.Insert(payment.CardInfo, token));

           
            paymentModel = await paymentDomainEntity.ProcessPayment(paymentModel, token);
            return mapper.Map<PaymentDto>(paymentModel);

        }
    }
}
