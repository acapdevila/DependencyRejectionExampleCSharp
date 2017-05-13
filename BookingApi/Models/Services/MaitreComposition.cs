using System.Linq;
using BookingApi.Models.Data;
using BookingApi.Models.Domain;
using CSharpFunctionalExtensions;

namespace BookingApi.Models.Services
{
    public interface IMaitre
    {
        int? TryAccept(Reservation reservation);
    }

    public class MaitreComposition : IMaitre
    {
        private readonly int _capacity;
        private readonly Maitre _maitre;
        private readonly IReservartionRepository _reservationsRepository;

        public MaitreComposition(int capacity, IReservartionRepository reservationsRepository)
        {
            _capacity = capacity;
            _reservationsRepository = reservationsRepository;
            _maitre = new Maitre();
        }

        public int? TryAccept(Reservation reservation)
        {
            // Non pure
            var reservations = _reservationsRepository
                  .ReadReservations(reservation.Date);

            // Pure
            Maybe<Reservation> resultReservation = _maitre.TryAccept(_capacity, reservations, reservation);

            // Non pure
            if(resultReservation.HasValue)
                return _reservationsRepository.Create(reservation);

            return null;
        }
    }
}