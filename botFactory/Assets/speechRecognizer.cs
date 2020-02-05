using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class speechRecognizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;

    // read the json file of responses here then create a dictionary
    Dictionary<string, System.Action> phrases = new Dictionary<string, System.Action>();

    // Adding phrases to the testing dictionary - will change once the json file is added

    // Start is called before the first frame update
    void Start()
    {
        phrases.Add("hello", () => { speakResponse(); });

        // initialize a new keyword recognizer
        keywordRecognizer = new KeywordRecognizer(phrases.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += phraseRecognized;
        keywordRecognizer.Start();
        
    }

    void phraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if(phrases.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void speakResponse()
    {
        print("I heard you say hello!");
    }

    // Update is called once per frame
    ////////////void Update()
    ////////////{
        
    ////////////}
}
