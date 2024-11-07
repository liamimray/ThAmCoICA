using ThAmCo.Catering.Data;

public class Menu
{
    public int MenuId { get; set; }
    public string MenuName { get; set; }

    public ICollection<MenuFoodItem> MenuFoodItems { get; set; }
    public ICollection<FoodBooking> FoodBookings { get; set; }
}
