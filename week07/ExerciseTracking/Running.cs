public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / _distance;
    }

    // Override GetSummary to include Running-specific information
    public override string GetSummary()
    {
        return $"{Date:dd MMM yyyy} Running ({LengthInMinutes} min) - " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}