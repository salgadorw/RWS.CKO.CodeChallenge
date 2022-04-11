using PaymentGateway.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Integration.Tests.Fixtures
{
    public class FixtureData : IDisposable
    {
        public IEnumerable<PaymentDto> GeneratePaymentDataByCounter(int counter = 1, bool isValid = true)
        {
            var random = new Random();
            for(var i = 0; i <= counter; i++)
            {
                var value= random.Next() / random.NextDouble();

                yield return new PaymentDto
                {
                    Id = null,
                    CardInfo = GenerateCardInfoDataByCounter(counter,isValid).First(),
                    Currency = "BRL",
                    LastUpdate = DateTime.Now,
                    PaymentValue = value

                };
            }

        }

        public IEnumerable<CardInfoDto> GenerateCardInfoDataByCounter(int counter=1, bool isValid= true)
        {
            var random = new Random();
            for (var i = 0; i <= counter; i++)
            {
                yield return new CardInfoDto()
                {
                    CardNumber = (isValid ? String.Empty : "A") + GetNextIntValue(true).ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() +
                                      "-" + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() +
                                      "-" + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() +
                                      "-" + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString(),
                    CardHolderName = "RWS "+GetRandomName(int.Parse(GetNextIntValue(true).ToString())),
                    ExpirationDate = DateTime.Now.AddYears(3).ToString("MM/yyyy"),
                    CVV = int.Parse(GetNextIntValue(true).ToString() + GetNextIntValue().ToString() + GetNextIntValue().ToString()),
                    Id = null,
                    UserId = Guid.NewGuid()
                };
            }

        }

        public void Dispose()
        {
           
        }


        public String GetRandomName(int lenght)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            var stringChars = new char[lenght];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        private static char GetNextIntValue(bool isFirst=false)
        {
            var random = new Random();
            if(isFirst)
                return random.Next(1, 9).ToString().First();
            else
                return random.Next(0, 9).ToString().First();

        }
    }
}
