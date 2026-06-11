using AppointmentSystem.Models;
using AppointmentSystem.Services;
using AppointmentSystem.Storage;


Console.WriteLine("Appointment Management System");
Console.WriteLine("-----------------------------");

AppointmentService appointmentService = new AppointmentService();

JsonStorage storage = new JsonStorage();

// Load data
appointmentService.Appointments = storage.Load();
bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("1. Create Appointment");
    Console.WriteLine("2. View Appointments");
    Console.WriteLine("3. Cancel Appointment");
    Console.WriteLine("4. Search Appointment");
    Console.WriteLine("5. Exit");
    Console.WriteLine("-----------------------------");

    Console.Write("Enter choice: ");
    string choice = Console.ReadLine() ?? "";
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            try
            {
                int newId = appointmentService.Appointments.Any() ? appointmentService.Appointments.Max(x => x.Id) + 1 : 1;

                Console.WriteLine($"Creating Appointment Id: {newId}");

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter Email: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine() ?? "";

                Customer customer = new Customer(1,name,email,phone);

                Console.Write("Enter Service Name: ");
                string serviceName = Console.ReadLine() ?? "";

                Service service = new Service(1,serviceName,30,25);

                Console.Write("Enter Appointment Date and Time (yyyy-MM-dd HH:mm): ");
                DateTime date =DateTime.Parse(Console.ReadLine() ??"");

                

                Appointment appointment = new Appointment(newId,customer,service,date);
                appointmentService.CreateAppointment(appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;

        case "2":
            appointmentService.ShowAppointments();

            break;


        case "3":
            Console.Write("Enter Appointment Id: ");

            int id = Convert.ToInt32(Console.ReadLine());

            appointmentService.CancelAppointment(id);

            break;

        case "4":
            Console.Write("Enter Appointment Id: ");

            int searchId = Convert.ToInt32(Console.ReadLine());
            Appointment? result = appointmentService.SearchAppointment(searchId);

            if (result == null)
            {
                Console.WriteLine("Appointment not found");
            }
            else
            {
                Console.WriteLine($"Customer: {result.Customer.Name}");
                Console.WriteLine($"Service: {result.Service.Name}");
                Console.WriteLine($"Date: {result.AppointmentDate}");
                Console.WriteLine($"Status: {result.Status}");
            }

            break;

        case "5":
            storage.Save(appointmentService.Appointments);
            running = false;
            Console.WriteLine("Application Closed");

            break;

        default:
            Console.WriteLine("Invalid choice");

            break;
    }
}