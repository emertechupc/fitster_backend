namespace Fitster.API.Shopping.Resources;

public class OrderResource
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
}