using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = default!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
}