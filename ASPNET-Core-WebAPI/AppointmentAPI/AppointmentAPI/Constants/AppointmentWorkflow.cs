namespace AppointmentAPI.Constants;

public static class AppointmentWorkflow
{
    public static readonly Dictionary<string, List<string>> AllowedTransitions = new()
    {
        {
            AppointmentStatus.Booked,
            new List<string>
            {
                AppointmentStatus.Confirmed,
                AppointmentStatus.Cancelled
            }
        },
        {
            AppointmentStatus.Confirmed,
            new List<string>
            {
                AppointmentStatus.Completed,
                AppointmentStatus.Cancelled
            }
        },
        {
            AppointmentStatus.Completed,
            new List<string>()
        },
        {
            AppointmentStatus.Cancelled,
            new List<string>()
        }
    };

    public static bool CanTransition(string currentStatus, string newStatus)
    {
        if (!AllowedTransitions.ContainsKey(currentStatus))
            return false;

        return AllowedTransitions[currentStatus].Contains(newStatus);
    }
}