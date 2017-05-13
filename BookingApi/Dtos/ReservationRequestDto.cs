using System;
namespace BookingApi.Dtos
{
    public class ReservationRequestDto
    {

        public DateTime Date { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Quantity { get; set; }
    }
}
