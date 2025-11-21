public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    //constructor
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;

    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;

    }
    // New Getters methods for file storage
    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public string GetVerses()
    {
        if (_verse == _endVerse)
        {
            return _verse.ToString();
        }

        return $"{_verse}-{_endVerse}";

    }

    public int GetStartVerse()
    {
        return _verse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }

    }
   

}