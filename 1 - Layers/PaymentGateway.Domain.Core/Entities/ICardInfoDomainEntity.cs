using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Core.Entities
{
    public interface ICardInfoDomainEntity
    {
        Task Delete(Guid Id, CancellationToken token);
        Task<IEnumerable<CardInfoModel>> GetByUserId(Guid userId, CancellationToken token);
        Task<CardInfoModel> Insert(CardInfoModel cardInfo, CancellationToken token);
    }
}