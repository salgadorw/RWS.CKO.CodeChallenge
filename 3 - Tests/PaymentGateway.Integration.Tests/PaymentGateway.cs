using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PaymentGateway.Application.DTO;
using PaymentGateway.Integration.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace PaymentGateway.Integration.Tests
{
    public class PaymentGateway : IClassFixture<FixtureData>
    {
        private readonly FixtureData dataGenerator;
        private readonly string baseDirectoryPayment;
        private readonly Guid merchantId;
        private const string BASECARDINFOPATH = "api/CardInfo/";
        public PaymentGateway(FixtureData dataGenerator)
        {

            this.dataGenerator = dataGenerator;
            this.merchantId = Guid.NewGuid();
            this.baseDirectoryPayment = $"api/{merchantId}/Payment";
            

        }

        [Fact]
        public async Task ProcessPayment_InsertCardInfoTrueValidData_ReturnCardId()
        {
            // arrrange
             var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
            });
            var data = dataGenerator.GeneratePaymentDataByCounter().First();
            var client= application.CreateClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
           

            //act

            var paymentResult = await (await client.PostAsync(this.baseDirectoryPayment+"?saveCardInfo=true",content)).Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PaymentDto>(paymentResult);

            //assert


            Assert.True(result.CardInfo.Id != Guid.Empty);   

        }

        [Fact]
        public async Task ProcessPayment_InsertCardInfoFalseValidData_CardDataIsInvalid()
        {
            // arrrange
            var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
            });

            //act
            var client = application.CreateClient();
            var data = dataGenerator.GeneratePaymentDataByCounter(isValid: false).First();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var paymentResult = await (await client.PostAsync($"api/{Guid.NewGuid()}/Payment?saveCardInfo=true", content)).Content.ReadAsStringAsync();

            
            //assert
            Assert.True(paymentResult.Equals("CardDataIsInvalid"));
        }

        [Fact]
        public async Task ProcessPayment_GetCardInfoValidData_NotReturnCardId()
        {

            // arrrange
            var application = new WebApplicationFactory<Program>()
               .WithWebHostBuilder(builder =>
               {
               });
            var data = dataGenerator.GeneratePaymentDataByCounter().First();
            var client = application.CreateClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


            //act

            var paymentResult = await (await client.PostAsync(this.baseDirectoryPayment + "?saveCardInfo=false", content)).Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PaymentDto>(paymentResult);

            //assert


            Assert.True(result.CardInfo.Id== Guid.Empty);
        }

        [Fact]
        public async Task GetCardInfo_WithUserId_ReturnPersistedCardInfo()
        {

            // arrrange
            var application = new WebApplicationFactory<Program>()
               .WithWebHostBuilder(builder =>
               {
               });
            var data = dataGenerator.GeneratePaymentDataByCounter(2);
            var dataLast = data.First();
            var dataFirst = data.Last();
            var client = application.CreateClient();
            HttpContent contentFirst = new StringContent(JsonConvert.SerializeObject(dataFirst), Encoding.UTF8, "application/json");
            HttpContent contentLast = new StringContent(JsonConvert.SerializeObject(dataLast), Encoding.UTF8, "application/json");
            var paymentResultFirst = await (await client.PostAsync(this.baseDirectoryPayment + "?saveCardInfo=true", contentFirst)).Content.ReadAsStringAsync();
            var arrangeResultFirst = JsonConvert.DeserializeObject<PaymentDto>(paymentResultFirst);
            var paymentResultLast = await (await client.PostAsync(this.baseDirectoryPayment + "?saveCardInfo=true", contentLast)).Content.ReadAsStringAsync();
            var arrangeResultLast = JsonConvert.DeserializeObject<PaymentDto>(paymentResultLast);
            //act

            var responseFirst = await ((await client.GetAsync(BASECARDINFOPATH + $"{arrangeResultFirst.CardInfo.UserId}")).Content.ReadAsStringAsync());
            var responseLast = await ((await client.GetAsync(BASECARDINFOPATH + $"{arrangeResultLast.CardInfo.UserId}")).Content.ReadAsStringAsync());

            var resultFirst = JsonConvert.DeserializeObject<IEnumerable<CardInfoDto>>(responseFirst);
            var resultLast = JsonConvert.DeserializeObject<IEnumerable<CardInfoDto>>(responseLast);

            //assert
            Assert.True(resultFirst.First().CardHolderName == dataFirst.CardInfo.CardHolderName);
            Assert.True(resultLast.Last().CardHolderName == dataLast.CardInfo.CardHolderName);
        }
    }
}