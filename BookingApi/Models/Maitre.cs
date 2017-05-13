using System.Linq;

namespace BookingApi.Models
{
    public interface IMaitre
    {
        int? TryAccept(Reservation reservation);
    }

    public class Maitre : IMaitre
    {
        private readonly int _capacity;
        private readonly IReservartionRepository _reservationsRepository;

        public Maitre(int capacity, IReservartionRepository reservationsRepository)
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