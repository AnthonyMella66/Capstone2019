using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using Microsoft.CognitiveServices.Speech;
using Newtonsoft.Json;
using System.IO;

public class speechRecognizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;

    // Azure API key and endpoint stored in a seperate text file
    // string[] keyFile;

    // read the json file of responses here then create a dictionary
    Dictionary<string, System.Action> phrases = new Dictionary<string, System.Action>();

    // Adding phrases to the testing dictionary - will change once the json file is added

    // Start is called before the first frame update
    void Start()
    {
        
        // var config = SpeechConfig.FromSubscription("61b49ca565ac41489f7bff06f128a22d", "https://eastus.api.cognitive.microsoft.com/");

        butterflyBotExample jsonFile = new butterflyBotExample();

        BotConfig mina = jsonFile.ConfParser();

        List<string> keys = new List<string>(mina.keywordDict.Keys);

        // loop over each key in the responses dictionary
        foreach(string key in keys)
        {
            // add each key and response to the phrases dictionary
            string response = mina.keywordDict[key];

            phrases.Add(key, () => { speakResponse(response); });
        }

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

    void speakResponse(string response)
    {
        //print("SHOULD SPEAK NOW!");
        Debug.Log(response);
        //print(response);
    }

    // Update is called once per frame
    ////////////void Update()
    ////////////{
        
    ////////////}
}
