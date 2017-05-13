using System.Linq;
using BookingApi.Models.Data;
using BookingApi.Models.Domain;

namespace BookingApi.Models.Services
{
    public interface IMaitre
    {
        int? TryAccept(Reservation reservation);
    }

    public class MaitreComposition : IMaitre
    {
        private readonly int _capacity;
        private readonly IReservartionRepository _reservationsRepository;

        public MaitreComposition(int capacity, IReservartionRepository reservationsRepository)
        {
            _capacity = capacity;
            _reservationsRepository = reservationsRepository;
        }

        public int? TryAccept(Reservation reservation)
        {
            var reservedSeats = _reservationsRepository
                  .ReadReservations(reservation.Date)
                  .Sum(r => r.Quantity);


            if (reservedSeats + reservation.Quantity <= _capacity)
            {
                reservation.IsAccepted = true;
                return _reservationsRepository.Create(reservation);
            }

            return null;
        }
    }
}