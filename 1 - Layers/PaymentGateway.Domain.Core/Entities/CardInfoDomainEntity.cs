using PaymentGateway.Domain.Core.Repositories;
using PaymentGateway.Domain.Core.Services;
using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Core.Entities
{
    public class CardInfoDomainEntity : ICardInfoDomainEntity
    {
        private readonly ICardInfoRepository cardInfoRepository;
        public CardInfoDomainEntity(ICardInfoRepository cardInfoRepository)
        {
            this.cardInfoRepository = cardInfoRepository;
        }

        public async Task<IEnumerable<CardInfoModel>> GetByUserId(Guid userId, CancellationToken token)
        {
            return await cardInfoRepository.GetByUserId(userId, token);
        }

        public async Task<CardInfoModel> Insert(CardInfoModel cardInfo, CancellationToken token)
        {

            if (cardInfo.Validate())
                return await cardInfoRepository.Insert(cardInfo, token);
            else
                throw new InvalidOperationException("CardDataIsInvalid");
        }


        public async Task Delete(Guid Id, CancellationToken token)
        {
            ///Could have some validation such as: if card is preferred it cannot be deleted | if the prefered card were implemented 

            await cardInfoRepository.Delete(Id, token);
        }
    }
}
