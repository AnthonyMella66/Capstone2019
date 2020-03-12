using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class BotConfig
{
    public Dictionary<string, string> KeywordDict { get; set; }
}

public class ButterflyBotExample : MonoBehaviour
{
    public Transform butterflyBotTransform;
    public MeshRenderer butterflyMeshRendererLeftWingUp;
    public MeshRenderer butterflyMeshRendererLeftWingDown;
    public MeshRenderer butterflyMeshRendererRightWingUp;
    public MeshRenderer butterflyMeshRendererRightWingDown;
    public Material butterflyBlueMaterial;
    public Material butterflyGreenMaterial;

    private BotConfig ConfParser()
    {

        //string myJson = @"{'hello' : 'Heard you say hello', 'bucket' : 'the bucket is over here'}";
        BotConfig myBot = new BotConfig();
        StreamReader reader = new StreamReader("Assets/InputData/new_config.json");
        string jsonStr = reader.ReadToEnd();
        Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr);
        myBot.KeywordDict = jsonDict;
        return myBot;
    }

    // Start is called before the first frame update
    void Start()
    {
        BotConfig ourBot = ConfParser();
        Debug.Log("new dictionary stuff " + ourBot.KeywordDict["hello"]);
        List<string> keyList = new List<string>(ourBot.KeywordDict.Keys);
        List<string> valueList = new List<string>(ourBot.KeywordDict.Values);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

