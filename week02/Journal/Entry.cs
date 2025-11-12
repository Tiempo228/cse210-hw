public class Entry
{
    public string _question;
    public string _response;
    public string _date;


    //constructor
    public Entry(string question, string response, string date)
    {
        _question = question;
        _response = response;
        _date = date;

    }
    
    
    public void displayEntryData()
    {
        Console.WriteLine($"{_question}\n{_response}\n{_date}");
    }
}