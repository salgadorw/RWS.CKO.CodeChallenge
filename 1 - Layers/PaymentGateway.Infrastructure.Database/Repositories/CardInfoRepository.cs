using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Core.Repositories;
using PaymentGateway.Domain.Model;


namespace PaymentGateway.Infrastructure.Database.Repositories
{
    public class CardInfoRepository : ICardInfoRepository
    {
        private readonly Context dbContext;
        public CardInfoRepository(Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CardInfoModel>> GetByUserId(Guid userId, CancellationToken token)
        {

            return await dbContext.CardInfos.Where(w => w.UserId == userId).ToListAsync(token);
        }

        public async Task<CardInfoModel> Insert(CardInfoModel cardInfo, CancellationToken token)
        {
           

            dbContext.CardInfos.Add(cardInfo);

            await dbContext.SaveChangesAsync(token);

            return cardInfo;

        }

        public async Task Delete(Guid id, CancellationToken token)
        {
            var cardInfo = dbContext.CardInfos.First(w => w.Id == id);
            dbContext.CardInfos.Remove(cardInfo);
            await dbContext.SaveChangesAsync(token);

        }
    }
}
