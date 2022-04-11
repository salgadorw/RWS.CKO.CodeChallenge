namespace PaymentGateway.Application.DTO
{
    public class CardInfoDto
    {
        public Guid? UserId { get; set; }

        public Guid? Id { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string CardHolderName { get; set; }


    }
}
