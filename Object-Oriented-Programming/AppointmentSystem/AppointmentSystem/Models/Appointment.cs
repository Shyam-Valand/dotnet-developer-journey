namespace AppointmentSystem.Models;

public class Appointment
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public Service Service { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; }

    public Appointment(int id,Customer customer,Service service,DateTime appointmentDate)
    {
        Id = id;
        Customer = customer;
        Service = service;
        AppointmentDate = appointmentDate;
        Status = "Booked";
    }
}