using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace BookingApi.Models.Domain
{
    public class Maitre
    {
        public Maybe<Reservation> TryAccept(int capacity, List<Reservation> reservations, Reservation reservation)
        {
            var reservedSeats = reservations.Sum(r => r.Quantity);

            if (reservedSeats + reservation.Quantity <= capacity)
            {
                reservation.IsAccepted = true;
                return reservation;
            }

            return null;
        }

    }
}