using UnityEngine;
using System.IO;
using System.Collections.Generic;
using TMPro;

public class QuotesLoader : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private TextMeshProUGUI quotes_txt;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private List<string> quotes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadQuotes();
        DisplayAQuote();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayAQuote()
    {
        quotes_txt.text = GetRandomQuote();
    }
    private void LoadQuotes()
    {
        // Load the text file from Resources folder
       // TextAsset textAsset = Resources.Load<TextAsset>("Quotes.rtf");

        if (textAsset != null)
        {
            // Read all lines from the text file
            string[] lines = textAsset.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

            // Store lines in the quotes list
            quotes = new List<string>(lines);

            Debug.Log("Quotes loaded successfully.");
        }
        else
        {
            Debug.LogError("Could not find the quotes file in Resources.");
        }
    }

    private string GetRandomQuote()
    {
        if (quotes != null && quotes.Count > 0)
        {
            int randomIndex = Random.Range(0, quotes.Count);
            return quotes[randomIndex];
        }
        else
        {
            return "No quotes available.";
        }
    }
}
