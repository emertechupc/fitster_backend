namespace Fitster.API.Shopping.Resources;

public class WishListResource
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int Quantity { get; set; }
}