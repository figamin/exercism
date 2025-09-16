using System.Globalization;
using System.Runtime.InteropServices;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime givenDate = DateTime.Parse(appointmentDateDescription);
        if (location == Location.NewYork)
        {
            return TimeZoneInfo.ConvertTime(givenDate, getZone(location)).AddHours(8);
        }
        else if (location == Location.London)
        {
            return TimeZoneInfo.ConvertTime(givenDate, getZone(location)).AddHours(-2);
        }
        return TimeZoneInfo.ConvertTime(givenDate, getZone(location)).AddHours(-4);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105);
            default:
                return appointment.AddMinutes(-30);
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo currentZone = getZone(location);
        bool isDaylightSaving = currentZone.IsDaylightSavingTime(dt);
        bool isDaylightSavingBefore = currentZone.IsDaylightSavingTime(dt.AddDays(-7));
        return isDaylightSaving != isDaylightSavingBefore;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string formatting = String.Empty;
        switch (location)
        {
            case Location.NewYork:
                formatting = "MM/dd/yyyy HH:mm:ss";
                break;
            default:
                formatting = "dd/MM/yyyy HH:mm:ss";
                break;
        }
        DateTime givenDate;
        bool didParseWork = DateTime.TryParseExact(s: dtStr, format: formatting, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out givenDate);
        if (didParseWork)
        {
            return givenDate;
        }
        return new DateTime(1, 1, 1);
    }
    
    public static TimeZoneInfo getZone(Location location)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            switch (location)
            {
                case Location.NewYork:
                    return TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                case Location.London:
                    return TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                default:
                    return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            }
        }
        else
        {
            switch (location)
            {
                case Location.NewYork:
                    return TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
                case Location.London:
                    return TimeZoneInfo.FindSystemTimeZoneById("Europe/London");
                default:
                    return TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris");
            }
        }
    }
}
