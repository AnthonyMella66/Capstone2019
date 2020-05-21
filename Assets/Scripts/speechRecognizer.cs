using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using FrostweepGames.Plugins.GoogleCloud.TextToSpeech;
using UnityEngine.Analytics;
using System.Globalization;

// Anthony Mella and Jakub Pawlikowski
public class speechRecognizer : MonoBehaviour
{
    //public Canvas displayResponse;
    KeywordRecognizer keywordRecognizer;

    // Google cloud text to speech object
    public GCTextToSpeech _gcTextToSpeech;

    // Audiosource that is attached to the myAssistanceBot
    public AudioSource botVoice;

    // Voice configuration options
    public VoiceConfig botVoiceConfig;

    // Provides culture information and context regarding the voice option
    private CultureInfo _provider;

    // Array of different voices
    private Voice[] _voices;

    // Current chosen voice
    private Voice _currentVoice = new Voice();

    // read the json file of responses here then create a dictionary
    Dictionary<string, System.Action> phrases = new Dictionary<string, System.Action>();

    //record the time of simulation start, to be used for log file naming
    private String simulationStart = DateTime.Now.ToString("MM_dd_yyyy hh_mm");

    // Start is called before the first frame update
    void Start()
    {
        // Create a new Google cloud instance
        _gcTextToSpeech = GCTextToSpeech.Instance;

        // Add success and failure event methods to the current instance
        _gcTextToSpeech.SynthesizeSuccessEvent += _gcTextToSpeech_SynthesizeSuccessEvent;
        _gcTextToSpeech.SynthesizeFailedEvent += _gcTextToSpeech_SynthesizeFailedEvent;

        // Add the culture info and number format to the provider
        _provider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        _provider.NumberFormat.NumberDecimalSeparator = ".";

        // Add the chosen voice configuration to _currentVoice
        String[] myTypes = { Enumerators.LanguageCode.en_US.ToString() };
        _currentVoice.languageCodes = myTypes;
        _currentVoice.name = "en-US-Wavenet-A";
        _currentVoice.naturalSampleRateHertz = 24000.0;
        _currentVoice.ssmlGender = Enumerators.SsmlVoiceGender.MALE;

        using (StreamWriter responsesOutput = new StreamWriter(@"Assets/OutputData/responsesLog" + simulationStart + ".txt", true))
        {
            responsesOutput.WriteLine("--- Log of Keywords and responses in current simulation ---\n");
        }

        //Create instance of myAssistanceBot
        assistanceBot myAssistanceBot = new assistanceBot();

        //Create BotConfig which is object containing new dictionary with key-responses from input JSON file
        BotConfig assistanceBotJSON = myAssistanceBot.ConfParser();

        // Defining a list of keys to iterate over
        List<string> keys = new List<string>(assistanceBotJSON.keywordDict.Keys);

        // loop over each key in the responses dictionary
        foreach (string key in keys)
        {
            // add each key and response to the phrases dictionary
            string response = assistanceBotJSON.keywordDict[key];

            phrases.Add(key, () => { speakResponse(response); });
        }

        // initialize a new keyword recognizer and populate with phrases
        keywordRecognizer = new KeywordRecognizer(phrases.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += phraseRecognized;
        keywordRecognizer.Start();
    }

    // Method that is called when the keywordRecognizer recognizes a keyword said by the user
    // Invokes a system action that calls the speakResponse method
    void phraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        using (StreamWriter responsesOutput = new StreamWriter(@"Assets/OutputData/responsesLog" + simulationStart + ".txt", true))
        {
            responsesOutput.WriteLine("Keyword : " + DateTime.Now.ToString("hh:mm tt") + " --> " + args.text);
        }

        if (phrases.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    // Methods for successful speech synthesis
    // Automatically invoked when speakResponse is called and the synthesis is successful
    private void _gcTextToSpeech_SynthesizeSuccessEvent(PostSynthesizeResponse response)
    {
        botVoice.clip = _gcTextToSpeech.GetAudioClipFromBase64(response.audioContent, Constants.DEFAULT_AUDIO_ENCODING);
        botVoice.Play();
    }

    // Method that is called when the speech synthesis has failed, logs the error in the console
    private void _gcTextToSpeech_SynthesizeFailedEvent(string error)
    {
        Debug.Log(error);
    }

    // speakResponse method plays the synthesized phrase to the user through the audiosource on the bot
    void speakResponse(string response)
    {
        Debug.Log("Assistance response : " + response);
       
        // Synthesize the bot response to an audio format using the configurations in _currentvoice and _provider
        _gcTextToSpeech.Synthesize(response, new VoiceConfig()
        {
            gender = _currentVoice.ssmlGender,
            languageCode = _currentVoice.languageCodes[0],
            name = _currentVoice.name
        },
        true,
        double.Parse("1.0", _provider),
        double.Parse("1.0", _provider),
        _currentVoice.naturalSampleRateHertz);

        using (StreamWriter responsesOutput = new StreamWriter(@"Assets/OutputData/responsesLog" + simulationStart + ".txt", true))
        {
            responsesOutput.WriteLine("Response : " + DateTime.Now.ToString("hh:mm tt") + " --> " + response + "\n");
        }

    } 

}

//Object with Dictionary element to be returned by ConfigParser once populated from.json input file
class BotConfig
{
    public Dictionary<string, string> keywordDict { get; set; }
}

//Object with function with returns BotConfig with populated dictionary
class assistanceBot
{
    //If .json file found, populate BotConfig dictionary, otherwise return an empty BotConfig with an dictionary
    public BotConfig ConfParser()
    {
        BotConfig myBot = new BotConfig();
        try
        {
            StreamReader reader = new StreamReader("Assets/InputData/bot_config.json");
            string jsonStr = reader.ReadToEnd();
            Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr);
            myBot.keywordDict = jsonDict;
            Debug.Log("Dictionary populated");
            return myBot;
        }
        catch (ArgumentException e)
        {
            Debug.Log(e.ToString());
            Dictionary<string, string> emptyDict = new Dictionary<string, string>();
            myBot.keywordDict = emptyDict;
            return myBot;
        }
    }
}