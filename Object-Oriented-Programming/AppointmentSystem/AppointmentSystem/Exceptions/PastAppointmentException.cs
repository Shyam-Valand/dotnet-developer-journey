namespace AppointmentSystem.Exceptions;

public class PastAppointmentException : Exception
{
    public PastAppointmentException()
        : base("Cannot book appointment in the past")
    {

    }
}