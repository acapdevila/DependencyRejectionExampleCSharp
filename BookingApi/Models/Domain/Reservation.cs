﻿using System;

namespace BookingApi.Models.Domain
{
    public class Reservation
    {
        public Reservation(DateTime date, string name, string email, int quantity)
        {
            // Validate inputs and throw exception if are not valid

            Date = date;
            Name = name;
            Email = email;
            Quantity = quantity;
        }

        public DateTime Date { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public int Quantity { get; private set; }
        public bool IsAccepted { get; set; }
    }
}
