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
    public Dictionary<string, string> keywordDict { get; set; }
}

public class butterflyBotExample : MonoBehaviour
{
    public Transform butterflyBotTransform;
    public MeshRenderer butterflyMeshRendererLeftWingUp;
    public MeshRenderer butterflyMeshRendererLeftWingDown;
    public MeshRenderer butterflyMeshRendererRightWingUp;
    public MeshRenderer butterflyMeshRendererRightWingDown;
    public Material butterflyBlueMaterial;
    public Material butterflyGreenMaterial;

    public BotConfig ConfParser()
    {

        //string myJson = @"{'hello' : 'Heard you say hello', 'bucket' : 'the bucket is over here'}";
        BotConfig myBot = new BotConfig();
        StreamReader reader = new StreamReader("Assets/InputData/bot_config.json");
        string jsonStr = reader.ReadToEnd();
        Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr);
        myBot.keywordDict = jsonDict;
        return myBot;
    }

    // Start is called before the first frame update
    void Start()
    {
        BotConfig ourBot = ConfParser();
        //Debug.Log("new dictionary stuff " + ourBot.keywordDict["hello"]);

        List<string> keyList = new List<string>(ourBot.keywordDict.Keys);
        keyList.ForEach(item => Debug.Log(item));

        List<string> valueList = new List<string>(ourBot.keywordDict.Values);
        valueList.ForEach(item => Debug.Log(item));


    }

    // Update is called once per frame
    void Update()
    {

    }
}

