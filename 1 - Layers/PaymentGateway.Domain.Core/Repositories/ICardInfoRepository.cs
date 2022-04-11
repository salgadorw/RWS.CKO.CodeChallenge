using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Core.Repositories
{
    public interface ICardInfoRepository
    {
        Task Delete(Guid id, CancellationToken token);
        Task<IEnumerable<CardInfoModel>> GetByUserId(Guid userId, CancellationToken token);
        Task<CardInfoModel> Insert(CardInfoModel cardInfo, CancellationToken token);
    }
}