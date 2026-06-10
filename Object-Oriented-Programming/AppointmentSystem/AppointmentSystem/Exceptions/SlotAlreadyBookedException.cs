namespace AppointmentSystem.Exceptions;

public class SlotAlreadyBookedException : Exception
{
    public SlotAlreadyBookedException()
        : base("This appointment slot is already booked")
    {

    }
}