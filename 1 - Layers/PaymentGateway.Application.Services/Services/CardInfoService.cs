using AutoMapper;
using PaymentGateway.Application.DTO;
using PaymentGateway.Domain.Core.Entities;
using PaymentGateway.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application.Services.Services
{
    public class CardInfoService : ICardInfoService
    {
        private readonly ICardInfoDomainEntity cardInfoDomainEntity;
        private readonly IMapper mapper;
        public CardInfoService(ICardInfoDomainEntity cardInfoDomainEntity, IMapper mapper)
        {

            this.cardInfoDomainEntity = cardInfoDomainEntity;
            this.mapper = mapper;
        }

        public async Task Delete(Guid id, CancellationToken token)
        {
            await this.cardInfoDomainEntity.Delete(id, token);
        }

        public async Task<IEnumerable<CardInfoDto>> GetByUserId(Guid userId, CancellationToken token)
        {
            var cardInfoModels = await this.cardInfoDomainEntity.GetByUserId(userId, token);

            var cardInfoDtos = mapper.Map<IEnumerable<CardInfoDto>>(cardInfoModels);

            return cardInfoDtos;
        }

        public async Task<CardInfoDto> Insert(CardInfoDto cardInfo, CancellationToken token)
        { 
            ///validation for data can be add here.
            cardInfo.Id = Guid.NewGuid();
            var cardInfoModel = mapper.Map<CardInfoModel>(cardInfo);
            return mapper.Map<CardInfoDto>( await this.cardInfoDomainEntity.Insert(cardInfoModel, token));
        }
    }
}
