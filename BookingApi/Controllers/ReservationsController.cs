using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookingApi.Dtos;
using BookingApi.Models;

namespace BookingApi.Controllers
{
    public class ReservationsController : ApiController
    {
        private readonly IValidator _validator;
        private readonly IMaitre _maîtreD;

        public ReservationsController(IValidator validator, IMaitre maîtreD)
        {
            _validator = validator;
            _maîtreD = maîtreD;
        }

        public IHttpActionResult Post(ReservationRequestDto dto)
        {
            var validationMsg = _validator.Validate(dto);
            if (validationMsg != "")
                return this.BadRequest(validationMsg);

            var r = new Reservation(dto.Date, dto.Name, dto.Email, dto.Quantity);
            var id = _maîtreD.TryAccept(r);
            if (id == null)
                return this.StatusCode(HttpStatusCode.Forbidden);

            return this.Ok();
        }
    }
}
