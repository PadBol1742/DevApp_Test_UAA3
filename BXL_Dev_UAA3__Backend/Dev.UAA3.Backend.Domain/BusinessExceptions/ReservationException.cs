namespace Dev.UAA3.Backend.Domain.BusinessExceptions
{
    public class ReservationException : Exception
    {
        public ReservationException(string? message)
            : base(message)
        { }
    }

    public class ReservationAlreadyExistsException : ReservationException
    {
        public ReservationAlreadyExistsException()
            : base("Reservation already exists !")
        { }
    }

    public class ReservationNotFoundException : ReservationException
    {
        public ReservationNotFoundException()
            : base("Reservation not found !")
        { }
    }

    public class ReservationInvalidException : ReservationException
    {
        public ReservationInvalidException()
            : base("Reservation not valid !")
        { }
    }
}
