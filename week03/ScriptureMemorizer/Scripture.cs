public class Scripture
{
    private Reference _reference;
    private List<Word> _word;
    private string _originalText;
    private Random _random;

    // the constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _word = new List<Word>();
        _random = new Random();
        _originalText = text;

        string[] textArray = text.Split(' ');

        foreach (string word in textArray)
        {
            _word.Add(new Word(word));

        }

    }

    public void HideRandomWords(int numberToHide)
    {
        // Empty List of all visible words 
        List<Word> visibleWords = new List<Word>();

        // filling the List with visible words
        foreach (Word word in _word)
        {
            // if there is visible words
            if (!word.IsHidden())
            {
                visibleWords.Add(word);

            }

        }

        // if there is no words in the visible words list
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Minimum words to hide
        int wordsToHide = Math.Min(numberToHide, _word.Count);


        // hide words randomly
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            _word[randomIndex].Hide();
        }

    }


    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText();
        foreach (Word w in _word)
        {
            string displayWord = w.GetDisplayText();
            displayText += " " + displayWord + " ";
        }

        return displayText.Trim();

    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _word)
        {
            if (w.IsHidden())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    // Creation of New method for file storage
    public string GetReferenceDetails()
    {
        return $"{_reference.GetBook()}|{_reference.GetChapter()}|{_reference.GetVerses()}";
    }

    public string GetText()
    {
        return _originalText;
    }

    // Method for JSON serialization
    public JsonScriptureData GetScriptureData()
    {
        return new JsonScriptureData(
            _reference.GetBook(),
            _reference.GetChapter(),
            _reference.GetStartVerse(),
            _reference.GetEndVerse(),
            _originalText
        );
    }

}