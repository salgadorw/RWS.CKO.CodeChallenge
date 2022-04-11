using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Domain.Model
{
    public class CardInfoModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string CardHolderName { get; set; }

    }
}