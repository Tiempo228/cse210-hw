using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // For core requirements: hide any random words (even already hidden ones)
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = _random.Next(_words.Count);
            _words[randomIndex].Hide();
        }

        // STRETCH CHALLENGE: only hide words that aren't already hidden

        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }

    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}