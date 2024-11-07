using ThAmCo.Catering.Data;

public class MenuFoodItem
{
    public int MenuId { get; set; }      // Foreign Key to Menu
    public int FoodItemId { get; set; }   // Foreign Key to FoodItem

    public Menu Menu { get; set; }
    public FoodItem FoodItem { get; set; }
}
