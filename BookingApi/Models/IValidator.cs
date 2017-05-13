using BookingApi.Dtos;

namespace BookingApi.Models
{
    public interface IValidator
    {
        string Validate(ReservationRequestDto dto);
    }
}