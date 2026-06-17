using AppointmentEF.Models;
using AppointmentEF.Services;

AppointmentService appointmentService = new AppointmentService();

Appointment appointment = new Appointment
{
    CustomerId = 1,
    ServiceId = 1,
    AppointmentDate = new DateTime(2026, 7, 1, 15, 30, 0),
    Status = "Booked"
};

// CREATE
appointmentService.CreateAppointment(appointment);

// READ ALL
appointmentService.ShowAppointments();

// FIND BY ID
var result = appointmentService.GetAppointmentById(1);

if (result != null)
{
    Console.WriteLine(
        $"Found: {result.Customer.Name} - {result.Service.Name}"
    );
}


// UPDATE TEST
// appointmentService.CancelAppointment(1);


// DELETE TEST
// appointmentService.DeleteAppointment(1);