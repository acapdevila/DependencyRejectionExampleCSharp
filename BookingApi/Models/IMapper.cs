using BookingApi.Dtos;

namespace BookingApi.Models
{
    public interface IMapper
    {
        Reservation Map(ReservationRequestDto dto);
    }
}