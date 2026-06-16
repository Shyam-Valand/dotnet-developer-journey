using AppointmentEF.Data;
using AppointmentEF.Models;

using AppDbContext context = new AppDbContext();

// Create Customer
Customer customer = new Customer
{
    Name = "Shyam",
    Email = "shyam@test.com",
    Phone = "7672666567"
};

// Create Service
Service service = new Service
{
    Name = "Hair Cut",
    DurationMinutes = 30,
    Price = 50.00m
};

// Create Appointment
Appointment appointment = new Appointment
{
    Customer = customer,
    Service = service,
    AppointmentDate = new DateTime(2026, 6, 28, 10, 30, 0),
    Status = "Booked"
};

// Save data
context.Appointments.Add(appointment);
context.SaveChanges();

Console.WriteLine("Appointment saved successfully");