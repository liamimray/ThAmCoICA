using ThAmCo.Catering.Data;

public class FoodBooking
{
    public int FoodBookingId { get; set; }
    public int ClientReferenceId { get; set; }
    public int NumberOfGuests { get; set; }
    public int MenuId { get; set; }  // Foreign Key to Menu
    public Menu Menu { get; set; }
}
