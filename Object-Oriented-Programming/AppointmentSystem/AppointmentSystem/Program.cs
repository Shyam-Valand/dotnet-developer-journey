using AppointmentSystem.Models;
using AppointmentSystem.Services;


Console.WriteLine("Appointment System V1");
Console.WriteLine("----------------");


Customer customer = new Customer(1,"Shyam","shyam@test.com","9999999999");

Service service = new Service(1,"Hair Cut",30,25);

Appointment appointment = new Appointment(1,customer,service,DateTime.Now.AddDays(1));

AppointmentService appointmentService = new AppointmentService();

appointmentService.CreateAppointment(appointment);
appointmentService.ShowAppointments();
appointmentService.CancelAppointment(1);
appointmentService.ShowAppointments();