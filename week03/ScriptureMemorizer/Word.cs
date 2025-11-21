public class Word
{
    private string _text;
    private bool _isHidden;

    // constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }


    public void Hide()
    {
        _isHidden = true;

    }

    public void Show()
    {
        _isHidden = false;

    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenWord = new string('_', _text.Length);
            return hiddenWord;

        }
        else
        {
            return _text;
        }

    }
}