using System.Text.Json;
using AppointmentSystem.Models;


namespace AppointmentSystem.Storage;


public class JsonStorage
{
    private readonly string filePath = "appointments.json";


    public void Save(
        List<Appointment> appointments)
    {
        string json =
            JsonSerializer.Serialize(
                appointments,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });


        File.WriteAllText(
            filePath,
            json);


        Console.WriteLine("Appointments saved");
    }


    public List<Appointment> Load()
    {
        if (!File.Exists(filePath))
        {
            return new List<Appointment>();
        }


        string json =
            File.ReadAllText(filePath);


        return JsonSerializer
            .Deserialize<List<Appointment>>(json)
            ?? new List<Appointment>();
    }
}