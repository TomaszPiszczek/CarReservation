namespace CarResercation.Models
{
    public class CarReservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CarModel { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
