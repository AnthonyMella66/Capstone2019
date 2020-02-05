using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;

public class BotConfig
{
    public int position { get; set; }
    public int scale { get; set; }
    public int model { get; set; }
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

    private BotConfig ConfParser()
    {
        

        //input file is a : separated flat text, take all integers (rhs of :) into array
        //StreamReader reader = File.OpenText("Assets/InputData/bot_config.txt");
        StreamReader reader = new StreamReader("Assets/InputData/bot_config.json");
        string json = reader.ReadToEnd();
        BotConfig butterflyBot = JsonConvert.DeserializeObject<BotConfig>(json);
        //dynamic botArr = JsonConvert.DeserializeObject(json);
        Debug.Log("number for json array : " + butterflyBot.position);
        //string line;
        //int myInteger = 0;
        //int counter = 0;
        //int[] configInts = new int[3];  //NOTE: number of parameters in bot_config must match here
        //while ((line = reader.ReadLine()) != null)
        //{
        //    string[] items = line.Split(':');
        //    myInteger = int.Parse(items[1]);
        //    configInts[counter] = myInteger;

        //    Debug.Log(myInteger);
        //    counter = counter + 1;
        //}
        //reader.Close();
  
        return butterflyBot;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
        {
            file.WriteLine("--- Butterfly bot information below ---");
        }

        //array of configuration parameters from ConfParser function converted into element changes
        BotConfig butterflyBot = ConfParser();

        //bot position
        if (butterflyBot.position != 0)
        {
            if (butterflyBot.position == 1)
            {
                butterflyBotTransform.position = new Vector3(385, 34, 464);
                Debug.Log("Butterfly Bot position updated to : (385, 34, 464)");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot position updated to: (385, 34, 464)");
                }
            }
            if (butterflyBot.position == 2)
            {
                butterflyBotTransform.position = new Vector3(391, 34, 457);
                Debug.Log("Butterfly Bot position updated to : (391, 34, 457)");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot position updated to: (391, 34, 457)");
                }
            }
        }

        //bot scale
        if (butterflyBot.scale != 0)
        {
            if (butterflyBot.scale == 1)
            {
                //butterflyBotTransform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                Debug.Log("Butterfly Bot scale updated to : (0.05, 0.05, 0.05)");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot scale updated to: (0.05, 0.05, 0.05)");
                }
            }
            if (butterflyBot.scale == 2)
            {
                //butterflyBotTransform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
                Debug.Log("Butterfly Bot scale updated to : (0.07, 0.07, 0.07)");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot scale updated to: (0.07, 0.07, 0.07)");
                }
            }
        }

        //bot material
        if (butterflyBot.model != 0)   //if set to 0 then just use defaults
        {
            if (butterflyBot.model == 1)
            {
                butterflyMeshRendererLeftWingUp.material = butterflyBlueMaterial;
                butterflyMeshRendererLeftWingDown.material = butterflyBlueMaterial;
                butterflyMeshRendererRightWingUp.material = butterflyBlueMaterial;
                butterflyMeshRendererRightWingDown.material = butterflyBlueMaterial;
                Debug.Log("Butterfly bot material set to : " + butterflyMeshRendererLeftWingUp.material);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot material set to : " + butterflyMeshRendererLeftWingUp.material);
                }
            }
            if (butterflyBot.model == 2)
            {
                butterflyMeshRendererLeftWingUp.material = butterflyGreenMaterial;
                butterflyMeshRendererLeftWingDown.material = butterflyGreenMaterial;
                butterflyMeshRendererRightWingUp.material = butterflyGreenMaterial;
                butterflyMeshRendererRightWingDown.material = butterflyGreenMaterial;
                Debug.Log("Butterfly bot material set to : " + butterflyMeshRendererLeftWingUp.material);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
                {
                    file.WriteLine("Butterfly bot material set to : " + butterflyMeshRendererLeftWingUp.material);
                }
            }
        }

        //end section in output file
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
        {
            file.WriteLine("--- --- \n");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

