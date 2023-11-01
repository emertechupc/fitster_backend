using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public List<OrderItem> OrderItems { get; set; } = new();
}