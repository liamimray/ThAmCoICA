using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public ICollection<MenuFoodItem> MenuFoodItems { get; set; }

        public FoodItem() {
            Description = string.Empty;
            UnitPrice = 0f;
        }

        public FoodItem(
            int id,
            string description,
            float unitPrice
          )
        {
            FoodItemId = id;
            Description = description;
            UnitPrice = unitPrice;
        }


    }
}
