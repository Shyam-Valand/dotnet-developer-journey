using AppointmentSystem.Models;
using AppointmentSystem.Services;
using AppointmentSystem.Storage;


Console.WriteLine("Appointment System V2");
Console.WriteLine("----------------");

Customer customer = new Customer(1,"Shyam","shyam@test.com","9999");

Service service = new Service(1,"Hair Cut",30,25);

Appointment appointment = new Appointment(1,customer,service,DateTime.Now.AddDays(1));

AppointmentService appointmentService = new AppointmentService();

JsonStorage storage = new JsonStorage();

// Load JSON data
appointmentService.Appointments = storage.Load();

try
{
    appointmentService.CreateAppointment(appointment);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("----------------");
appointmentService.ShowAppointments();
Console.WriteLine("----------------");
appointmentService.CancelAppointment(1);
appointmentService.ShowAppointments();

// Save JSON data
storage.Save(appointmentService.Appointments);