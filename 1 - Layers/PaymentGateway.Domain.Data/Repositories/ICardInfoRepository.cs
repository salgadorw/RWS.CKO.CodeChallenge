using PaymentGateway.Domain.Model;

namespace PaymentGateway.Domain.Data.Repositories
{
    public interface ICardInfoRepository
    {
        Task Delete(Guid id, CancellationToken token);
        Task<IEnumerable<CardInfoModel>> GetByUserId(Guid userId, CancellationToken token);
        Task Insert(CardInfoModel cardInfo, CancellationToken token);
    }
}