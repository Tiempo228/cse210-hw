public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();  // Changed to return int (points earned)
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    // Getter for points (used by RecordEvent in GoalManager)
    public int GetPoints()
    {
        return _points;
    }

    public string GetShotName()
    {
        return _shortName;
    }
}