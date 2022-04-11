using PaymentGateway.Application.DTO;

namespace PaymentGateway.Application.Services.Services
{
    public interface ICardInfoService
    {
        Task Delete(Guid id, CancellationToken token);
        Task<IEnumerable<CardInfoDto>> GetByUserId(Guid userId, CancellationToken token);
        Task<CardInfoDto> Insert(CardInfoDto cardInfo, CancellationToken token);
    }
}