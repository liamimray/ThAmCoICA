namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public required int FoodItemId { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }

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
