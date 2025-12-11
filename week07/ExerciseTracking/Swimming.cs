public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    // Convert laps to miles (50 meters per lap)
    public override double GetDistance()
    {
        // 50 meters per lap, convert to miles
        // 50 meters = 0.0310686 miles
        return _laps * 0.0310686;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return LengthInMinutes / distance;
    }

    // Override GetSummary for Swimming with lap information
    public override string GetSummary()
    {
        return $"{Date:dd MMM yyyy} Swimming ({LengthInMinutes} min) - " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile, " +
               $"Laps: {_laps}";
    }
}