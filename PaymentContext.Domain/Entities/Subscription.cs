namespace PaymentContext.Domain.Entities
{
  public class Subscription
  {
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public DateTime? ExireDate { get; set; }
    public bool Active { get; set; }
    public List<Payment> Payments { get; set; }
  }
}