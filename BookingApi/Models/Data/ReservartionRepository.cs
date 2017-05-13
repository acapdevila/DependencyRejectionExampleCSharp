using System;
using System.Collections.Generic;
using BookingApi.Models.Domain;

namespace BookingApi.Models.Data
{
    public interface IReservartionRepository
    {
        List<Reservation> ReadReservations(DateTime date);
        int? Create(Reservation reservation);
    }

    public class ReservartionRepository : IReservartionRepository
    {
        public List<Reservation> ReadReservations(DateTime date)
        {
            throw new NotImplementedException();
        }

        public int? Create(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}