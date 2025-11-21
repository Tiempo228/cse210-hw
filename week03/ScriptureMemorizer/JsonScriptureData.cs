public class JsonScriptureData
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private string _text;
    private JsonScriptureData()
    {
        
    }

    public JsonScriptureData(string book, int chapter, int startVerse, int endVerse, string text)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _text = text;
    }

    public string GetBook()
    {
        return _book;

    }

    public int GetChapter()
    {
        return _chapter;

    }

    public int GetStartVerse()
    {
        return _startVerse;

    }

    public int GetEndVerse()
    {
        return _endVerse;

    }
    
    public string GetText()
    {
        return _text;
        
    }

}