namespace PaymentGateway.Application.DTO
{
    public class PaymentDto
    {
        public Guid? MerchantId { get; set; }

        public Guid? Id { get; set; }        

        public CardInfoDto CardInfo { get; set; }

        public double PaymentValue { get; set; }

        public string Currency { get; set; }

        public string? Status { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}